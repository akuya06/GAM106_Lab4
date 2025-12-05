using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Services;
using System.Threading.Tasks;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] // only authenticated users can access
public class EmailController : ControllerBase
{
    private readonly IEmailService _email;
    public EmailController(IEmailService email) => _email = email;

    [HttpPost("send")]
    public async Task<IActionResult> Send([FromBody] EmailDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.To))
            return BadRequest(new { error = "Invalid payload" });

        await _email.SendEmailAsync(dto.To, dto.Subject, dto.Body);
        return Ok(new { status = "sent" });
    }

    public record EmailDto(string To, string Subject, string Body);
}