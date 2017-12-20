using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Sinaf.WebApi.Api.Provider
{
    public class SimplesAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.Response.Headers.Add("Acess-Control-Allow-Origin",new string[] { "*" });
            if (context.UserName != "sinaf" || context.Password != "sinaf123")
            {
                context.SetError("invalido_usuario_ou_senha", "Usuário e/ou Senha incorretor");
                return;
            }

            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identity);

        }
    }
}