using System;

namespace InitialCore.Data.Interfaces
{
	public interface IDateTracking
	{
		DateTime DateCreated { set; get; }

		DateTime DateModified { set; get; }
	}
}