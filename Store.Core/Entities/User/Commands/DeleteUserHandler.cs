using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.User.Commands;
using Store.Entities.BuisnessEntities.User.Entitites;

namespace Store.Core.Entities.User.Commands
{
    public class DeleteUserHandler : UserApplicationServiceHandler<DeleteUser, Users>
    {
        public DeleteUserHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {
        }

        protected override async Task HandleRequest(DeleteUser request, CancellationToken cancellationToken)
        {
            var identityUser = await _UserManager.FindByIdAsync(request.UserId);

            if(identityUser != null)
            {
                var result = await _UserManager.DeleteAsync(identityUser);
                if(result.Succeeded)
                {
                    AddStatus("User Deleted");
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
}
