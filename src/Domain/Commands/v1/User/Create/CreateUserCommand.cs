using MediatR;

namespace Domain.Commands.v1.User.Create
{
    public class CreateUserCommand : IRequest
    {
        public long Id { get; set; }
        public string? Nome { get; set; } 
        public string? Sobrenome { get; set; } 
        public string? Email { get; set; } 
        public string? Password { get; set; }
    }
}
