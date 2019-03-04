using System;
using System.Collections.Generic;
using System.Text;
using WebInfrastructure.AccessModifiers;

namespace InitialCore.MSTest.AccessModifiders
{
	public class AccessModifierImplement
	{
		public void Immlement() {
			AccessModifierInstance ami = new AccessModifierInstance();
			ami.RedBookPublic = false;
		}
	}
}
