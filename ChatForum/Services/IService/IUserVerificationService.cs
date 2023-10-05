namespace Services.IService
{
    public interface IUserVerificationService
    {
        bool UserExists(int id);
    }
}
