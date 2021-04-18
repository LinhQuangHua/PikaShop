using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace PikaShop.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                  new ApiScope("pikashop.api", "PikaShop Shop API")
             };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "pikashop.api" }
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44357/signin-oidc" },

                    PostLogoutRedirectUris = { "https://localhost:44357/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "pikashop.api"
                    }
                },

                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris =           { $"https://localhost:44317/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"https://localhost:44317/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"https://localhost:44317" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "pikashop.api"
                    }
                },

                new Client
                {
                    ClientName = "react_code_client",
                    ClientId = "react_code_client",
                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,

                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris = new List<string>
                    {
                        $"{"http://localhost:3000"}/authentication/login-callback",
                        $"{"http://localhost:3000"}/silent-renew.html",
                        $"{"http://localhost:3000"}"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{"http://localhost:3000"}/unauthorized",
                        $"{"http://localhost:3000"}/authentication/logout-callback",
                        $"{"http://localhost:3000"}"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{"http://localhost:3000"}"
                    },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "pikashop.api"
                    }
                },
            };
    }
}