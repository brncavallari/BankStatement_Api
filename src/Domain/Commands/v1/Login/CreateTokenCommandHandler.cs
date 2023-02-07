using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Commands.v1.Login
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, CreateTokenCommandResponse>
    {
        public async Task<CreateTokenCommandResponse> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", false, true).Build();


                var issuer = configuration.GetSection("Jwt").GetValue<string>("Issuer");
                var audience = configuration.GetSection("Jwt").GetValue<string>("Audience");
                var configKey = configuration.GetSection("Jwt").GetValue<string>("Key");
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
