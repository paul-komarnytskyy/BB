using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BB.Core;
using BB.Core.UtilityModel;
using Microsoft.Owin.Security.OAuth;

namespace BB.Api
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private BBEntities entities;

        public AuthorizationServerProvider()
        {
            entities = new BBEntities();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var user = entities.Users.FirstOrDefault(
                u => u.Username == context.UserName && u.Password == context.Password);

            if (user == null)
            {
                context.SetError("Invalid grant", "Provided username and password are incorrect");
                return;
            }

            if (user.Roles.Any(r => r.Name == Role.Admin))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, Role.Admin));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                context.Validated(identity);
            }
            else if (user.Roles.Any(r => r.Name == Role.Moderator))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, Role.Moderator));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                context.Validated(identity);
            }
            else if (user.Roles.Any(r => r.Name == Role.User))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, Role.User));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                context.Validated(identity);
            }
        }
    }
}