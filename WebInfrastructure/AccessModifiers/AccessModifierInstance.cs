namespace WebInfrastructure.AccessModifiers
{
	public class AccessModifierInstance
	{
		public AccessModifierInstance()
		{
		}

		private bool RedBookPrivate = true;

		internal bool RedBookInternal = true;

		protected bool RedBookProtected = true;

		public bool RedBookPublic = true;
	}
}