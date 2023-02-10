using Domain.Extensions.v1;
using Domain.Interfaces.v1.User;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Domain.Commands.v1.Login
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, CreateTokenCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public CreateTokenCommandHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;

            _configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", false, true).Build();

        }

        public async Task<CreateTokenCommandResponse> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(
                    request.Email);

                if (user is null || user.Password != HashExtension.GetHash(request.Password)) 
                    throw new Exception("User or Password invalid");


                var issuer = _configuration.GetSection("Jwt").GetValue<string>("Issuer");
                var audience = _configuration.GetSection("Jwt").GetValue<string>("Audience");
                var configKey = _configuration.GetSection("Jwt").GetValue<string>("Key");
                var expiry = DateTime.Now.AddMinutes(60);

                var securityKey = new SymmetricSecurityKey
                                  (Encoding.UTF8.GetBytes(configKey));

                var credentials = new SigningCredentials
                                  (securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: issuer,
                                                 audience: audience,
                                                 expires: DateTime.Now.AddMinutes(120),
                                                 signingCredentials: credentials);

                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);

                return await Task.FromResult(new CreateTokenCommandResponse(stringToken));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
