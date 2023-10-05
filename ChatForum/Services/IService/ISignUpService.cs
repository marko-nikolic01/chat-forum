using Model;

namespace Services.IService
{
    public interface ISignUpService
    {
        bool IsUsernameOrEmailTaken(string username, string email);
        void SignUp(User user);
    }
}
