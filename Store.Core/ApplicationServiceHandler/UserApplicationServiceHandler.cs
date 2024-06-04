using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.DataAccessLayer.Repositories;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.Common.ApplicationResponse;
using Store.Entities.Common.baseEntity;


namespace Store.Core.ApplicationServiceHandler
{
    public abstract class UserApplicationServiceHandler<TRequest, TResult>
              : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
                where TRequest : IRequest<ApplicationServiceResponse<TResult>>
    {
        protected readonly UserManager<Users> _UserManager;
        protected readonly SignInManager<Users> _signInManager;
        private ApplicationServiceResponse<TResult> _response = new ApplicationServiceResponse<TResult>();

        public UserApplicationServiceHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager)
        {
            _UserManager = UserManager;
            _signInManager = signInManager;
        }


        public async Task<ApplicationServiceResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request, cancellationToken);
            return _response;
        }


        protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

        public void AddError(string error)
        {
            _response.AddError(error);
        }

        public void AddResult(TResult result)
        {
            _response.Result = result;

        }

        public void AddStatus( string status)
        {
            _response.StatusMessage = status;
        }

    


        
    }
}
