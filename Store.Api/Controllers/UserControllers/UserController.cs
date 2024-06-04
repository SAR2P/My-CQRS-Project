using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Api.comman;
using Store.Entities.BuisnessEntities.User.Commands;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.BuisnessEntities.User.Queries;

namespace Store.Api.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IMediator MediatR) : base(MediatR)
        {
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]CreateUser CreateUser)
        {
            var response = await _MediatR.Send(CreateUser);
            return response.IsSucces ? Ok(response.StatusMessage) : BadRequest(response.Errors);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> getAllUsers([FromQuery] UserQueryResultGetAll userInput)
        {
            var response = await _MediatR.Send(userInput);
            return response.IsSucces ? Ok(response.Result) : BadRequest(response.Errors);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> getUserById([FromQuery] UserQueryResultGetById userInput)
        {
            var response = await _MediatR.Send(userInput);
            return response.IsSucces ? Ok(response.Result) : BadRequest(response.Errors);
        }

    }
}
