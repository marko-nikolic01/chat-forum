using DataAccess.Repository.IRepository;
using Model;
using Services.IService;

namespace Services
{
    public class CommentSubmissionService: ICommentSubmissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentSubmissionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Submit(int userId, Comment comment)
        {
            User user = _unitOfWork.UserRepository.GetFirstOrDefault(u => u.Id == userId);
            comment.User = user;
            _unitOfWork.CommentRepository.Add(comment);
            _unitOfWork.Save();
        }
    }
}
