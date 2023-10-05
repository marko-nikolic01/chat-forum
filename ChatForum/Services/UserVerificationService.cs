using DataAccess.Repository.IRepository;
using Model;
using Services.IService;

namespace Services
{
    public class UserVerificationService : IUserVerificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserVerificationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool UserExists(int id)
        {
            User user = _unitOfWork.UserRepository.GetFirstOrDefault(u => u.Id == id);
            return user != null;
        }
    }
}
