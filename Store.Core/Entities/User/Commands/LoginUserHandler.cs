using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.User.Commands;
using Store.Entities.BuisnessEntities.User.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities.User.Commands
{
    public class LoginUserHandler : UserApplicationServiceHandler<LoginUser, Users>
    {
        public LoginUserHandler(UserManager<Users> UserManager, Microsoft.AspNetCore.Identity.SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {
        }

        protected override async Task HandleRequest(LoginUser request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.EmailAddress) && !string.IsNullOrEmpty(request.Password))
            {
                var result = await _signInManager.PasswordSignInAsync(request.EmailAddress, request.Password, request.IsPersistent, false);
                if (result.Succeeded)
                {
                    AddStatus(result.Succeeded.ToString());

                }
                else if (result.IsNotAllowed)
                {
                    AddStatus(result.IsNotAllowed.ToString());
                }
                else
                {
                    AddError("Email and password is not valid");
                }
            }
        }
    }
}
