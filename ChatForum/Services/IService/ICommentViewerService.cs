using Model;

namespace Services.IService
{
    public interface ICommentViewerService
    {
        ICollection<Comment> View();
    }
}
