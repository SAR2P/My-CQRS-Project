using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.User.Commands;
using Store.Entities.BuisnessEntities.User.Entitites;

namespace Store.Core.Entities.User.Commands
{
    public class CreateUserHandler : UserApplicationServiceHandler<CreateUser, Users>
    {
        public CreateUserHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {

        }

        protected override async Task HandleRequest(CreateUser request, CancellationToken cancellationToken)
        {
            Users user = new()
            {
                Email = request.Email,
                FirstName = request.FirstName!,
                LastName = request.LastName!,
                UserName = request.UserName,

            };
            IdentityResult result = await _UserManager.CreateAsync(user, request.Password!);
            if (result.Succeeded)
            {
                AddStatus(user.Id);
                
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    AddError(item.Description);
                }
            }
        }


    }
}
