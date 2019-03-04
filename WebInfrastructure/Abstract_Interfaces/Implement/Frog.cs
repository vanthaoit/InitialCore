using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebInfrastructure.Abstract_Interfaces.Abstracts;
using WebInfrastructure.Abstract_Interfaces.Interfaces;

namespace WebInfrastructure.Abstract_Interfaces.Implement
{
	public class Frog : Amphibians /*implement*/,IWaterAnimal, ILandAnimal // actualize
	{
		public void Dive()
		{
			throw new NotImplementedException();
		}

		public void Jump()
		{
			throw new NotImplementedException();
		}

		public void Run() 
		{
			throw new NotImplementedException();
		}

		public override void SleepAbstract() // implement abstract method
		{
			throw new NotImplementedException();
		}

		public override void SleepVirtual() // override virual method
		{
			base.SleepVirtual();
		}
	}
}
