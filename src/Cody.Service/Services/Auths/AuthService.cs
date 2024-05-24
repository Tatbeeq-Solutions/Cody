using AutoMapper;
using Cody.DataAccess.UnitOfWorks;
using Cody.Domain.Entities;
using Cody.Domain.Enums;
using Cody.Service.DTOs.Logins;
using Cody.Service.DTOs.Users;
using Cody.Service.Exceptions;
using Cody.Service.Helpers;
using Cody.Service.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Cody.Service.Services.Auths;

public class AuthService(IMapper mapper,
                         IOptions<JwtOptions> jwtOptions,
                         IOptions<SuperAdminOptions> superAdminOptions,
                         IUnitOfWork unitOfWork) : IAuthService
{
    private readonly JwtOptions jwtOption = jwtOptions.Value;
    private readonly SuperAdminOptions superAdminOption = superAdminOptions.Value;


    public async Task<LoginResultDto> LoginAsync(LoginDto loginDto)
    {
        if (loginDto.Phone == superAdminOption.Phone || loginDto.Password == superAdminOption.Password)
            return new LoginResultDto(superAdminOption, GenerateToken(superAdminOption));

        var user = await unitOfWork.Users.SelectAsync(u => u.Phone == loginDto.Phone);

        if (user is null || !PasswordHasher.Verify(loginDto.Password, user.PasswordHash))
            throw new ArgumentIsNotValidException("Phone or password is incorrect");

        var mappedUser = mapper.Map<UserResultDto>(user);
        var token = GenerateToken(user);
        return new LoginResultDto(mappedUser, token);
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(jwtOption.Key);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = jwtOption.Audience,
            Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(jwtOption.LifeTime)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            Issuer = jwtOption.Issuer,
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("Id", user.Id.ToString()),
                new("Phone", user.Phone),
                new(ClaimTypes.Role, user.Role.ToString())
            })
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private string GenerateToken(SuperAdminOptions options)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(jwtOption.Key);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = jwtOption.Audience,
            Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(jwtOption.LifeTime)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            Issuer = jwtOption.Issuer,
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("Id", "-111"),
                new("Phone", options.Phone),
                new(ClaimTypes.Role, Role.SuperAdmin.ToString())
            })
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}

