namespace CLIMFinders.Application.Interfaces
{
    public interface IUserService
    {
        int GetUserId();
        int GetBusinessId();
        string GetClaimByType(string type);
        string GeneratePassword(int length);
    }
}
