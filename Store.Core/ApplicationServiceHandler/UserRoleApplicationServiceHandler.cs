using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Entities.Common.ApplicationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.ApplicationServiceHandler
{
    public abstract class UserRoleApplicationServiceHandler<TRequest, TResult>
              : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
                where TRequest : IRequest<ApplicationServiceResponse<TResult>>
    {
        protected readonly RoleManager<IdentityRole> _RoleManager;
        private ApplicationServiceResponse<TResult> _response = new ApplicationServiceResponse<TResult>();

        public UserRoleApplicationServiceHandler(RoleManager<IdentityRole> roleManager )
        {
            _RoleManager = roleManager;
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

        public void AddStatus(string status)
        {
            _response.StatusMessage = status;
        }





    }


}
