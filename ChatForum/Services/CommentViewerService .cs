using DataAccess.Repository.IRepository;
using Model;
using Services.IService;

namespace Services
{
    public class CommentViewerService: ICommentViewerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentViewerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ICollection<Comment> View()
        {
            ICollection<Comment> comments = _unitOfWork.CommentRepository.GetAll(includedProperties: "User").ToList();
            return comments;
        }
    }
}
