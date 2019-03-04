using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebInfrastructure.AccessModifiers;

namespace WebInfrastructure.Abstract_Interfaces.Abstracts
{
	public abstract class Amphibians:Animal
	{
		//Animal an = new Animal(); // error

		protected void Implement() {
			AccessModifierInstance ami = new AccessModifierInstance();
			ami.RedBookInternal = false;
		}

	}
}
