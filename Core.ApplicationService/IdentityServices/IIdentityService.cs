namespace Core.ApplicationServices.IdentityServices
{
    using Core.ObjectModels.Identities;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        Task<IdentityResultTHP> Login(string username, string password);

        Task<IdentityResultTHP> Register(UserRegisterForm user, params string[] roles);

        Task<IdentityResultTHP> ChangePassword(string userId, string currentPassword, string newPassword);

    }
}
