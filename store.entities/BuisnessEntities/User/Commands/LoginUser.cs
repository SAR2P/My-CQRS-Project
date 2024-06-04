using MediatR;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.Common.ApplicationResponse;
using System.ComponentModel.DataAnnotations;


namespace Store.Entities.BuisnessEntities.User.Commands
{
    public class LoginUser : IRequest<ApplicationServiceResponse<Users>>
    {
        [Required]
        [Length(5, 150, ErrorMessage = "Email Address Is Not Valid")]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        [Length(5, 150, ErrorMessage = "password is not crruct")]
        public string? Password { get; set; }

        public bool IsPersistent { get; set; }

    }
}
