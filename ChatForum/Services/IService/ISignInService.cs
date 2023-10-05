using Model;

namespace Services.IService
{
    public interface ISignInService
    {
        User SignIn(string emailOrUsername, string password);
    }
}

