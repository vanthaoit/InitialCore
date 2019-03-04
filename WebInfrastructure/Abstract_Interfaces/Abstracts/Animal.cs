using WebInfrastructure.Abstract_Interfaces.Interfaces;

namespace WebInfrastructure.Abstract_Interfaces.Abstracts
{
	public abstract class Animal : OverrideClass
	{
		internal bool RedBookInternal = true;
		private bool RedBookPrivate = true;
		protected bool RedBookProtected = true;

		protected void Eat()
		{
		}

		public override void Breath()
		{
		}

		public abstract void SleepAbstract();

		public virtual void SleepVirtual()
		{
		}
	}
}