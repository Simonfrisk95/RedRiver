using Microsoft.AspNetCore.Mvc;
using BookQuotes.Api.DTOs;
using BookQuotes.Api.Services;
using BookQuotes.Api.Data;

namespace BookQuotes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly JwtService _jwt;

        public AuthController(ApplicationDbContext db, JwtService jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginRequest req)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == req.UserName && u.Password == req.Password);
            if (user is null) return Unauthorized();

            var token = _jwt.GenerateToken(user.UserName);
            return Ok(new LoginResponse(token));
        }
    }
}
