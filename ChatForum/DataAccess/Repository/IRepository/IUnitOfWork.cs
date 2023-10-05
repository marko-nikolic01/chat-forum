namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICommentRepository CommentRepository { get; }

        void Save();
    }
}

