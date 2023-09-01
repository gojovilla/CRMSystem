using CRMSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DataAccess.Repository.IRepository
{
  
    public interface ICriminalRepository : IRepository<Criminal>
    {
        void Update(Criminal criminal);
    }
}
