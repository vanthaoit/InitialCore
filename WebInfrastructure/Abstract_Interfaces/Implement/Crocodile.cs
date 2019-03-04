using System;
using WebInfrastructure.Abstract_Interfaces.Abstracts;
using WebInfrastructure.AccessModifiers;

namespace WebInfrastructure.Abstract_Interfaces.Implement
{
	public class Crocodile : Reptile
	{
		public override void SleepAbstract()
		{
			AccessModifierInstance instanceAcc = new AccessModifierInstance
			{
				RedBookInternal = false
			};
			throw new NotImplementedException();
		}
	}
}