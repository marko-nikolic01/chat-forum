using DataAccess.Repository.IRepository;
using Model;
using Services.IService;

namespace Services
{
    public class SignUpService : ISignUpService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignUpService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool IsUsernameOrEmailTaken(string username, string email)
        {
            User conflictedUser = _unitOfWork.UserRepository.GetFirstOrDefault(u => u.Username == username || u.Email == email);
            return conflictedUser != null;
        }

        public void SignUp(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
        }
    }
}
