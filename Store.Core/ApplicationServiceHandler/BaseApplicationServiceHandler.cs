using MediatR;
using Store.DataAccessLayer.Repositories;
using Store.Entities.Common.ApplicationResponse;
using Store.Entities.Common.baseEntity;

namespace Store.Core.ApplicationServiceHandler
{
    public abstract class BaseApplicationServiceHandler<TRequest, TResult, TEntity>
              : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
                where TEntity: BaseEntity 
                where TRequest : IRequest<ApplicationServiceResponse<TResult>>
    {

        protected readonly IGenericRepository<TEntity> _genericRepository;
        private ApplicationServiceResponse<TResult> _response = new ApplicationServiceResponse<TResult>();


        public BaseApplicationServiceHandler(IGenericRepository<TEntity> genericRepositori)
        {
            this._genericRepository = genericRepositori;
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

    }
}
