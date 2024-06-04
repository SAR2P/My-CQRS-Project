using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.Roles.Commands;

namespace Store.Core.Entities.Rols.Commands
{
    public class DeleteUserRoleHandler : UserRoleApplicationServiceHandler<DeleteUserRole, IdentityRole>
    {
        public DeleteUserRoleHandler(RoleManager<IdentityRole> roleManager) : base(roleManager)
        {
        }

        protected override async Task HandleRequest(DeleteUserRole request, CancellationToken cancellationToken)
        {
            var identityRole = await _RoleManager.FindByIdAsync(request.RoleId);
            if (identityRole != null)
            {
                var result = await _RoleManager.DeleteAsync(identityRole);
                if(result.Succeeded)
                {
                    AddStatus("Role Deleting successed");
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
