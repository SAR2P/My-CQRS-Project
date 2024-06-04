using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Api.comman;
using Store.Entities.BuisnessEntities.Products.Commands;
using Store.Entities.BuisnessEntities.Products.Queries;

namespace Store.Api.Controllers.ProductControllers
{


    public class ProductController : BaseController
    {
        public ProductController(IMediator MediatR) : base(MediatR)
        {

        }

        [HttpGet("getProduct/{PId}")]
        public async Task<IActionResult> getProductByName([FromRoute]ProductQueryFilterById ProductId)
        {
            var response = await _MediatR.Send(ProductId);
            return response.IsSucces ? Ok(response.Result) : BadRequest(response.Errors);
        }

        [HttpGet("getAllProducts")]
        public async Task<IActionResult> getAllProducts([FromQuery]ProductQueryFilterGetAll Product)
        {
            var response = await _MediatR.Send(Product);
            return response.IsSucces ? Ok(response.Result) : BadRequest(response.Errors);
        }

        [HttpPost("getProductByName")]
        public async Task<IActionResult> GetProduct([FromBody]ProductQueriFilterByProductName ProductInput)
        {
            var response = await _MediatR.Send(ProductInput);
            return response.IsSucces ? Ok(response.Result) : BadRequest(response.Errors);
        }


        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(CreateProduct createProduct)
        {
            var response = await _MediatR.Send(createProduct);
            return response.IsSucces ? Ok(response.Result) : BadRequest(response.Errors);
        }
    }
}
