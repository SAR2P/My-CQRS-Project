
using MediatR;
using Store.Entities.BuisnessEntities.Products.Entities;
using Store.Entities.Common.ApplicationResponse;
using System.ComponentModel.DataAnnotations;

namespace Store.Entities.BuisnessEntities.Products.Commands
{
    public class CreateProduct : IRequest<ApplicationServiceResponse<Product>>
    {
        [Length(3,200 , ErrorMessage = "Product Name Charecters Is between 3 and 200")]
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;




    }
}
