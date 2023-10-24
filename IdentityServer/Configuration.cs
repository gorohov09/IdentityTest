using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Configuration
    {
        /// <summary>
        /// Области, которые доступны клиентскому приложению
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("TestWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        /// <summary>
        /// Моделирование доступа к защищенном ресурсам
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("TestWebAPI", "Web API", new [] {JwtClaimTypes.Name})
                {
                    Scopes = { "TestWebAPI" }
                }
            };

        /// <summary>
        /// Список клиентов, которые могут использовать наши апишки
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                //Точно такая же конфигурация должна быть в React приложении
                new Client
                {
                    ClientId = "test",
                    ClientName = "test",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = new [] { new Secret("test".Sha512()) },
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://localhost:3000/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3000"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:3000/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "TestWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                },
                new Client //Использовать этого клиента
                {
                    ClientId = "test2",
                    ClientSecrets = new [] { new Secret("test2".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, "TestWebAPI" }
                }
            };
    }
}
