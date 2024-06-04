using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.Roles.Commands;

namespace Store.Core.Entities.Rols.Commands
{
    public class AddUserRoleHandler : UserRoleApplicationServiceHandler<AddUserRole, IdentityRole>
    {
        public AddUserRoleHandler(RoleManager<IdentityRole> roleManager) : base(roleManager)
        {
        }

        protected override async Task HandleRequest(AddUserRole request, CancellationToken cancellationToken)
        {
            var identityRole = new IdentityRole(request.RoleName!);
            var result = await _RoleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                AddStatus("Role Created");
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
