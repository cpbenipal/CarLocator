using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CLIMFinders.Web.ServiceExtension
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
            {
                if (!AttachUserToContext(context, token))
                {
                    context.Response.Redirect("/Unauthorized"); // ✅ Redirect to Unauthorized Page
                    return;
                }
            }


            await _next(context);
        }

        private bool AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                var tokenHandler = new JwtSecurityTokenHandler();
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                var principal = tokenHandler.ValidateToken(token, parameters, out var validatedToken);
                var identity = (ClaimsIdentity)principal.Identity;

                if (identity.IsAuthenticated)
                {
                    context.User = principal;
                    return true;
                }
            }
            catch
            {
                // Token is invalid
            }
            return false;
        }
    }
}
