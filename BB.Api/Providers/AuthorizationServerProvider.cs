using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace BB.Api
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                context.Validated(identity);identity.AddClaim(new Claim(ClaimTypes.Name, "Paul Komarnytskyy"));
                context.Validated(identity);
            }
            else if (context.UserName == "test" && context.Password == "test")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "test"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Test User"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Invalid grant", "Provided username and password are incorrect");
            }
        }
    }
}