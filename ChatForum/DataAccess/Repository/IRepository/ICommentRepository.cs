using Model;

namespace DataAccess.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Update(Comment Comment);
    }
}
