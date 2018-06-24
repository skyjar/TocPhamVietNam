namespace Infrastructure.Identity.Adapter
{
    using System;
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Transactions;
    using Core.ApplicationServices.Database.Identity;
    using Core.ApplicationServices.IdentityServices;
    using Core.ObjectModels.Identities;
    using Infrastructure.Identity.Models;
    using Infrastructure.Identity.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class IdentityAdapter : IIdentityService
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        

        public IdentityAdapter(IIdentity context)
        {
            DbContext dbContext = context.GetContext as DbContext;
            _userService = new UserService(new UserStore<User>(dbContext));
            _roleService = new RoleService(new RoleStore<Role>(dbContext));
        }

        public async Task<IdentityResultTHP> ChangePassword(string userId, string currentPassword, string newPassword)
        {
            IdentityResultTHP result = new IdentityResultTHP();

            var user = await this._userService.ChangePasswordAsync(userId, currentPassword, newPassword);
            if (!user.Succeeded)
                result.Errors.AddRange(user.Errors);

            return result;
        }

        public async Task<IdentityResultTHP> Login(string username, string password)
        {
            IdentityResultTHP result = new IdentityResultTHP();
            try
            {
                User user = await _userService.FindAsync(username, password);
                if (user == null)
                {
                    result.Errors.Add("Tên đăng nhập hoặc mật khẩu không đúng");
                } else
                {
                    ClaimsIdentity claimsIdentity = await _userService.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    result.Data = claimsIdentity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IdentityResultTHP> Register(UserRegisterForm user, params string[] roles)
        {
            IdentityResultTHP result = new IdentityResultTHP();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required,
                TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    IdentityResult createUser = await _userService.CreateAsync(new User {
                        UserName = user.Username,
                        PhoneNumber = user.Phone,
                        Address = user.Address,
                        FullName = user.FullName,
                        DateOfBirth = user.DateOfBirth
                    }, user.Password);

                    if (!createUser.Succeeded)
                        result.Errors.AddRange(createUser.Errors);
                    else
                    {
                        foreach (var roleName in roles)
                        {
                            if (!_roleService.RoleExists(roleName))
                            {
                                IdentityResult createRole = await this._roleService.CreateAsync(new Role { Name = roleName });

                                if (!createRole.Succeeded)
                                    result.Errors.AddRange(createRole.Errors);
                            }

                            User currentUser = await _userService.FindByNameAsync(user.Username);
                            if (!_userService.IsInRole(currentUser.Id, roleName))
                            {
                                await _userService.AddToRoleAsync(currentUser.Id, roleName);
                            }
                        }
                        scope.Complete();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
    }
}
