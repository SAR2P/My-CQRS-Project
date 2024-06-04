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
    public class UpdateUserBasicHandler : UserApplicationServiceHandler<UpdateUserBasic, Users>
    {
        public UpdateUserBasicHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {
        }

        protected override async Task HandleRequest(UpdateUserBasic request, CancellationToken cancellationToken)
        {
            var QueryResult = await _UserManager.FindByIdAsync(request.Id!);
            if(QueryResult != null)
            {
                QueryResult.FirstName = request.FirsName;
                QueryResult.LastName = request.LastName;
                QueryResult.Email = request.Email;
                QueryResult.Gender = request.Gender;
                QueryResult.PhoneNumber = request.PhoneNumber;
                QueryResult.UserName = request.UserName;
                var Result = await _UserManager.UpdateAsync(QueryResult);
                if(Result.Succeeded)
                {
                    AddStatus("Update Is Success");
                }
                else
                {
                    AddError("Update Is Fail");
                }
            }
            else
            {
                AddError($"User By Id {request.Id} Is Not Defind");
            }
        }
    }
}
