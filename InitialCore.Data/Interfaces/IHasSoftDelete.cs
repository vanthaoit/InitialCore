﻿namespace InitialCore.Data.Interfaces
{
	public interface IHasSoftDelete
	{
		bool IsDeleted { set; get; }
	}
}