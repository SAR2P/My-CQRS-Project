using MediatR;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.Common.ApplicationResponse;
using System.ComponentModel.DataAnnotations;


namespace Store.Entities.BuisnessEntities.User.Commands
{
    public class CreateUser : IRequest<ApplicationServiceResponse<Users>>
    {
        [Required]
        [Length(2, 170, ErrorMessage = "Type FirstName between 2 and 170 charecter")]
        public string? FirstName { get; set; }

        [Required]
        [Length(2, 170, ErrorMessage = "Type LastName between 2 and 170 charecter")]
        public string? LastName { get; set; }

        [Required]
        [Length(2, 170, ErrorMessage = "Type User Name between 2 and 170 charecter")]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Type your Email currectly")]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Password { get; set; }



    }
}
