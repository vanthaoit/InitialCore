namespace WebInfrastructure.AccessModifiers
{
	public class AccessModifierImplement : AccessModifierInstance
	{
		public void Implement()
		{
			AccessModifierImplement AccessModifiers = new AccessModifierImplement();

			AccessModifiers.RedBookProtected = false;
			AccessModifiers.RedBookInternal = false;
		}
	}
}