using DataAccess.Repository.IRepository;
using Model;
using Services.IService;

namespace Services
{
    public class SignInService : ISignInService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignInService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public User SignIn(string emailOrUsername, string password)
        {
            User user = _unitOfWork.UserRepository.GetFirstOrDefault(u =>
                (u.Email == emailOrUsername || u.Username == emailOrUsername) && u.Password == password);
            return user;
        }
    }
}
