using System;
using System.Collections.Generic;
using System.Text;

namespace InitialCore.Infrastructure.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
		void Commit();
    }
}
