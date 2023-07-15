using ApiTemplate.Application.Commands.Common;
using ApiTemplate.Application.Common;
using ApiTemplate.Application.Requests.Login;
using ApiTemplate.Application.Responses.Login;
using ApiTemplate.Domain.Entities;
using ApiTemplate.Domain.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OneOf;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiTemplate.Application.Commands.Login
{
    public class LoginHandler : ICommandHandler<LoginRequest, LoginResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ValidationResult _validationResult;

        public LoginHandler(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _validationResult = new ValidationResult();
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<LoginResponse, ValidationResult>> Handle(LoginRequest request)
        {
            var user = _unitOfWork.DbSet<User>().FirstOrDefault(x => x.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return _validationResult.Add("Invalid Login", ValidationResult.ValidationErrorCode.Conflict);

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt:Key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaims(user),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            var loginResponse = new LoginResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = jwtToken
            };

            return loginResponse;
        }

        private static ClaimsIdentity GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
                //new Claim(ClaimTypes., user.Nome),
                //new Claim(ClaimTypes.Email, user.Email),
            };

            return new ClaimsIdentity(claims);
        }
    }
}
