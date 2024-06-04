



using MediatR;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.Common.ApplicationResponse;

namespace Store.Entities.BuisnessEntities.User.Commands
{
    public class UpdateUserBasic : IRequest<ApplicationServiceResponse<Users>>
    {
        public string? Id { get; set; }

        public string? FirsName { get; set; }

        public string? LastName { get; set; }

        public bool Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? UserName { get; set; }

    }
}
