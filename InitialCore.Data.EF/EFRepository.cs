using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using InitialCore.Data.Settings.Settings;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Infrastructure.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver.V1;
using Neo4jClient;

namespace InitialCore.Data.EF
{
	public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
	{
		private readonly ApplicationDbContext _context;

		//private INeo4JDbInitializer _neo4jContext;
		private IGraphClient _client;
		private string entityName;

		public EFRepository(ApplicationDbContext context)
		{
			_context = context;
			Initial();
		}

		public void Initial()
		{
			var initialConnection = new Neo4JDbInitializer(ConnectionSettings.CreateBasicAuth());
			entityName = this.getEntityName(typeof(T).Name); 

			_client = initialConnection.CreateBasicAuth();
			_client.Connect();
		}

		public virtual T Add(T entity)
		{			
			_client.Cypher
				.Create("(p:{node} {inputProduct})")
				.WithParam("inputProduct", entity)
				.WithParam("node",this.entityName)
				.ExecuteWithoutResults();


			return entity.As<T>();
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
			}
		}

		public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();

			//var entityName = getEntityName(typeof(T).Name);

			var itemResponse = _client.Cypher
												.Match("(pc:" + entityName + ")")
												//.Where((T pc) => pc.As<T>)
												//.Return(pc => new { ProductCategory = pc.As<T>()}).Results.ToList();
												.Return(pc => pc.As<T>())
												.Results.ToList().AsQueryable();

			//var itemResponse = productCategoryResponse.AsQueryable();

			return itemResponse;
		}

		public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.Where(predicate);
		}

		public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
		{
			var response = FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
			return response;
		}

		public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			return FindAll(includeProperties).SingleOrDefault(predicate);
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void Remove(K id)
		{
			Remove(FindById(id));
		}

		public void RemoveMultiple(List<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}
		private string getEntityName(string entity) {
			string[] entitySplit = entity.Split("ViewModel");

			var entityName = entitySplit[0];
			return entityName;
		}
	}
}