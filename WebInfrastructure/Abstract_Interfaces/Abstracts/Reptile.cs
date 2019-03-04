using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebInfrastructure.Abstract_Interfaces.Interfaces;

namespace WebInfrastructure.Abstract_Interfaces.Abstracts
{
	public abstract class Reptile : Animal, ITaste
	{
		public void Drink()
		{
			throw new NotImplementedException();
		}
	}
}
