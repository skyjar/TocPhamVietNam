namespace Infrastructure.Identity.Services
{
    using System.Data.Entity;
    using Infrastructure.Identity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserService : UserManager<User>
    {
        public UserService(IUserStore<User> store) : base(store)
        {
        }
    }
}
