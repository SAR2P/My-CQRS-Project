using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Store.Api.comman
{
    [Route("[controller]")]
    [ApiController]

    public class BaseController : ControllerBase
    {
        protected readonly IMediator _MediatR;

        public BaseController(IMediator MediatR)
        {
            _MediatR = MediatR;
        }



    }
}
