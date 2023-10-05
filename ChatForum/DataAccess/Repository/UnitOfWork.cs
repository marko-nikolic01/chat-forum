using DataAccess.Context;
using DataAccess.Repository.IRepository;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IUserRepository UserRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UserRepository = new UserRepository(_db);
            CommentRepository = new CommentRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
