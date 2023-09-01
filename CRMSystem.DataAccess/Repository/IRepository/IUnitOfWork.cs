using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        ICriminalRepository Criminal { get; }
        void Save();

    }
}
