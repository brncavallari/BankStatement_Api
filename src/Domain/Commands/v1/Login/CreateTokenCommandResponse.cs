namespace Domain.Commands.v1.Login
{
    public class CreateTokenCommandResponse
    {
        public CreateTokenCommandResponse(string token) => Token = token;
        public string Token { get; set; }
    }
}
