using MediatR;

namespace Domain.Commands.v1.Login
{
    public class CreateTokenCommand : IRequest<CreateTokenCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
