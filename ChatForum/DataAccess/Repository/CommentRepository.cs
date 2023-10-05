using DataAccess.Context;
using DataAccess.Repository.IRepository;
using Model;

namespace DataAccess.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comment Comment)
        {
            _db.Comments.Update(Comment);
        }
    }
}
