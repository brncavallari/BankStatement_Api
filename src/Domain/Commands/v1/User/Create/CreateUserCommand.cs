using MediatR;

namespace Domain.Commands.v1.User.Create
{
    public class CreateUserCommand : IRequest
    {
        public long Id { get; set; }
        public string? Name { get; set; } 
        public string? LastName { get; set; } 
        public string? Email { get; set; } 
        public string? Password { get; set; }
    }
}
