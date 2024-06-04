using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.User.DTOs;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.BuisnessEntities.User.Queries;
using Store.Entities.Common.ApplicationResponse;





namespace Store.Core.Entities.User.Queries
{
    public class UserQueryResultGetByUserNameHandler : UserApplicationServiceHandler<UserQueryResultGetByUserName, UserQueryResultGetByUserName_DTO>
    {
        public UserQueryResultGetByUserNameHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {
        }

        protected override async Task HandleRequest(UserQueryResultGetByUserName request, CancellationToken cancellationToken)
        {
            var result = await _UserManager.FindByNameAsync(request.UserName);
            if (result != null)
            {
                UserQueryResultGetByUserName_DTO userQueryResultGetByUserName_DTO = new UserQueryResultGetByUserName_DTO()
                {
                    FullName = $"{result.FirstName} {result.LastName}",
                    Email = result.Email!
                };
                AddResult(userQueryResultGetByUserName_DTO);
            }
            else
            {
                AddStatus($"User By UserName : {request.UserName} is not defind");
            }
        }
    }
}
