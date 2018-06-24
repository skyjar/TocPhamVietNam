namespace Infrastructure.Identity.Services
{
    using System.Data.Entity;
    using Infrastructure.Identity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RoleService : RoleManager<Role>
    {
        public RoleService(IRoleStore<Role, string> store) : base(store)
        {
        }
    }
}
