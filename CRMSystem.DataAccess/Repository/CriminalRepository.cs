using CRMSystem.DataAccess.Repository.IRepository;
using CRMSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DataAccess.Repository
{
 
    public class CriminalRepository : Repository<Criminal>, ICriminalRepository
    {
        private ApplicationDbContext _db;
        public CriminalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Criminal criminal)
        {
            _db.Criminals.Update(criminal);
        }
    }
}
