using CRMSystem.DataAccess.Repository.IRepository;

namespace CRMSystem.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Criminal = new CriminalRepository(_db);
        }
        public IUserRepository User { get; private set; }
        public ICriminalRepository Criminal { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
