using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EscolaAPI.Configuration
{
    public static class TokenConfig
    {
        public static void AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string secretKeyConfig = configuration.GetSection("SecretKey").Value;
            byte[] secretKey = Encoding.ASCII.GetBytes(secretKeyConfig);
            
            services.AddAuthentication(opt =>
            {   
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
            } ).AddJwtBearer(opt => 
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };   
            });        
        }
    }
}