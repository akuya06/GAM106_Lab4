using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _config;
    public AuthController(ApplicationDbContext db, IConfiguration config) { _db = db; _config = config; }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        var user = _db.Users.SingleOrDefault(u => u.UserName == dto.UserName && u.OTP == dto.Password);
        if (user == null) return Unauthorized();

        var jwt = _config.GetSection("Jwt");
        var keyString = jwt["Key"];
        if (string.IsNullOrEmpty(keyString))
            throw new InvalidOperationException("JWT Key is not configured; please set 'Jwt:Key' in configuration.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim("username", user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Role, user.RoleId?.ToString() ?? string.Empty)
        };

        // use only "ExpireMinutes" from configuration (default 60)
        var minutesStr = jwt["ExpireMinutes"] ?? "60";
        if (!double.TryParse(minutesStr, out var minutes)) minutes = 60;

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(minutes),
            signingCredentials: creds
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expires = token.ValidTo });
    }
}

public record LoginDto(string UserName, string Password);