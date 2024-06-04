using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.Roles.Commands;

namespace Store.Core.Entities.Rols.Commands
{
    public class UpdateUserRoleHandler : UserRoleApplicationServiceHandler<UpdateUserRole, IdentityRole>
    {
        public UpdateUserRoleHandler(RoleManager<IdentityRole> roleManager) : base(roleManager)
        {
        }

        protected override async Task HandleRequest(UpdateUserRole request, CancellationToken cancellationToken)
        {
            var identityRole = await _RoleManager.FindByIdAsync(request.RoleId);
            if (identityRole != null)
            {
                identityRole.Name = request.RoleName;

                var result = await _RoleManager.UpdateAsync(identityRole);
                if(result.Succeeded)
                {
                    AddResult(identityRole);
                    AddStatus("User Role Updated");
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
