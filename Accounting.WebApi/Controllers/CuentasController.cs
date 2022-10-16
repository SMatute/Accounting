using Accounting.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Accounting.WebApi.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController: ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public CuentasController(UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            SignInManager<IdentityUser>signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }
        [HttpPost("registrar")]
        public async Task<ActionResult<RespuestaAutenticacion>> Registrar(CredencialesUsuarios credencialesUsuarios)
        {
            var usuario = new IdentityUser
            {
                UserName = credencialesUsuarios.Email,
                Email = credencialesUsuarios.Email
            };
            var resultado = await userManager.CreateAsync(usuario, credencialesUsuarios.Password);
            
            if (resultado.Succeeded)
            {
                return ConstruirToken(credencialesUsuarios);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        
        }

        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login(CredencialesUsuarios credencialesUsuarios)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuarios.Email,
                credencialesUsuarios.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return ConstruirToken(credencialesUsuarios);
            }
            else
            {
                return BadRequest("Login incorecto");
            }
        }

        private RespuestaAutenticacion ConstruirToken(CredencialesUsuarios credencialesUsuarios)
        {
            var claims = new List<Claim>()
            {
               new Claim("Email", credencialesUsuarios.Email),
               new Claim("lo que quiera", "Cualquier Valor")
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMinutes(20);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null,
                claims: claims, expires:expiracion, signingCredentials: creds);

            return new RespuestaAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion
            };
        }
    }
}
