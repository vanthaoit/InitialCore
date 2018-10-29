using InitialCore.Data.Settings.Settings;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Infrastructure.SharedKernel;
using InitialCore.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver.V1;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InitialCore.Data.EF
{
    public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
    {
        private readonly ApplicationDbContext _context;

        //private INeo4JDbInitializer _neo4jContext;
        private IGraphClient _client;

        private ISession _globalSession;

        public class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            Initial();
        }

        public void Initial()
        {
      
            var initialConnection = new Neo4JDbInitializer(ConnectionSettings.CreateBasicAuth());

            _client = initialConnection.CreateBasicAuth();
            _client.Connect();

            //var client = new GraphClient(new Uri("http://localhost:7474/db/data"), SystemConstants.USER_NAME, SystemConstants.PASSWORD);
            //client.Connect();

            //var data = client.Cypher
            //            .Match("(pc:User)")
            //            //.Where((T pc) => pc.Description == "IphoneX")
            //            .Return(pc => new
            //            {
            //                User = pc.As<User>()
            //            })
            //            .Results.ToList();
            //var productCategoryResponse = client.Cypher
            //                                    .Match("(pc:ProductCategories)")
            //                                    //.Where((ProductCategoryViewModel pcv) => pcv.Name == "Iphone")
            //                                    .Return(pc => new
            //                                    {
            //                                        ProductCategory = pc.As<ProductCategoryViewModel>()
            //                                    }).Results.ToList();

            // _client = new GraphClient(new Uri("http://localhost:7474/db/data"), SystemConstants.USER_NAME, SystemConstants.PASSWORD);



        }

        public virtual T Add(T entity)
        {
            //var newProduct = new ProductViewModel
            //{
            //    Name = "Iphone 9",
            //    CategoryId = 1,
            //    Image = "",
            //    Price = 1000,
            //    PromotionPrice = 1000,
            //    OriginalPrice = 1000,
            //    Description = "be introduced in 1999",
            //    Content = "Iphone 9",
            //    HomeFlag = false,
            //    HotFlag = false,
            //    ViewCount = 0,
            //    Tags = "Iphone",
            //    Unit = "",
            //    SeoPageTitle = "",
            //    SeoAlias = "",
            //    SeoKeywords = "",
            //    SeoDescription = "",
            //    DateCreated = new DateTime(),
            //    DateModified = new DateTime(),
            //    Status = 0
            //};
            _client.Cypher
                .Create("(product:Product {inputProduct})")
                .WithParam("inputProduct", entity)
                .ExecuteWithoutResults();

            //_context.Add(entity);

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

            string[] entitySplit = typeof(T).Name.Split("ViewModel");

            var entityName = entitySplit[0];

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
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
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
    }
}