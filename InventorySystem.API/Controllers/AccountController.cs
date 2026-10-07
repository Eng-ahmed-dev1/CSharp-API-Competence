using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InventorySystem.BLL.DTOs.AccountDTOs;
using InventorySystem.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManger;
        public AccountController(UserManager<ApplicationUser> user)
        {
            _userManger = user;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDTO dto)
        {
            var user = new ApplicationUser
            {
                department = dto.department,
                Email = dto.Email,
                UserName = dto.UserName,
                PhoneNumber = dto.Phone
            };
            var result = await _userManger.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    errors = result.Errors.Select(e => new
                    {
                        e.Code,
                        e.Description
                    })
                });
            }
            return Ok("The User Created Sucessfully .!");
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO dto)
        {
            var UserName = await _userManger.FindByNameAsync(dto.UserName);
            if (UserName is null)
                return NotFound();
            var Password = await _userManger.CheckPasswordAsync(UserName, dto.Password);
            if (!Password)
                return Unauthorized();

            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , UserName.Id.ToString()),
                new Claim(ClaimTypes.Email , UserName.Email),
                new Claim("Department" , UserName.department)
            };
            var secretkey = "AhmedAlaaAhmedAliKassemAlHais1256687981981651981968lkdshfsdlkfsdfl";
            var keyInAscil = Encoding.UTF8.GetBytes(secretkey);
            var key = new SymmetricSecurityKey(keyInAscil);
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: "http://localhost:5235",
            audience: "Frontend",
            signingCredentials: signIn,
            claims: Claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(15)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }
    }
}