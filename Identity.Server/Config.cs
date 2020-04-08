using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Server
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            //return new List<ApiResource>
            //{
            //    new ApiResource
            //    {
            //        Name = "etrustdeed",
            //        Description = "ETrustDeed API",
            //        UserClaims = new List<string> {"role"},
            //        ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
            //        Scopes = new List<Scope>
            //        {
            //            new Scope("etrustdeed.read"),
            //            new Scope("etrustdeed.write")
            //        }
            //    }
            //};
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {  IdentityServerConstants.StandardScopes.OpenId,
                                       IdentityServerConstants.StandardScopes.Profile,
                                       "api1", "role",
                                    },
                    Claims = new Claim[] // Assign const roles 
                    {
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Role, "user")
                    }
                },
                //new Client
                //{
                //    ClientId = "ro.client",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = { "api1" }
                //},

                //new Client
                //{
                //    ClientId = "client",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = { "etrustdeed" }
                //},

                //new Client
                //{
                //    ClientId = "eTrustDeedAPI-1",
                //    ClientName = "eTrustDeed API",
                //    // no interactive user, use the clientid/secret for authentication
                //    AllowedGrantTypes = GrantTypes.ImplicitAndClientCredentials,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowAccessTokensViaBrowser = true,
                //    RequireConsent = true,

                //    RedirectUris = { $"{configuration["ClientAddress"]}/home" },
                //    PostLogoutRedirectUris = { $"{configuration["ClientAddress"]}/index.html" },
                //    AllowedCorsOrigins = { configuration["ClientAddress"] },
                                       
                //    // scopes that client has access to
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "etrustdeed.read",
                //        "etrustdeed.write"
                //    }
                //},
                // new Client
                //{
                //    ClientId = "eTrustDeedAPI",
                //    ClientName = "eTrustDeed API",
                //    // no interactive user, use the clientid/secret for authentication
                //    AllowedGrantTypes = GrantTypes.ImplicitAndClientCredentials,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowAccessTokensViaBrowser = true,
                //    RequireConsent = true,

                //    RedirectUris = { $"https://localhost:" },
                //    PostLogoutRedirectUris = { $"{configuration["ClientAddress"]}/index.html" },
                //    AllowedCorsOrigins = { configuration["ClientAddress"] },
                                       
                //    // scopes that client has access to
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "etrustdeed.read",
                //        "etrustdeed.write"
                //    }
                //}
            };
        }


        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "saad",
                    Password = "password"
                }

            };
        }
    }
}
