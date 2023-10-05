using Model;

namespace Services.IService
{
    public interface ICommentSubmissionService
    {
        void Submit(int userId, Comment comment);
    }
}
