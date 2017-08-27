using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace OrderProcessingSystem.IdP
{
    /// <summary>
    ///     Stores Configurations
    /// </summary>
    public static class Config
    {
        /// <summary>
        ///     Test users for debugging purpose
        /// </summary>
        /// <returns>List of Users</returns>
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(),
                    Username = "Admin",
                    Password = "admin",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "Abhishek"),
                        new Claim(JwtClaimTypes.FamilyName, "Goenka"),
                        new Claim(JwtClaimTypes.Name, "Abhishek Goenka"),
                        new Claim(JwtClaimTypes.Role, "administrator")
                    }
                }
            };
        }

        /// <summary>
        ///     Get Identity Resources
        /// </summary>
        /// <returns>List of IdentityResources</returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "Your Role(s)", new List<string> { JwtClaimTypes.Role })
            };
        }

        /// <summary>
        ///     Get Clients
        /// </summary>
        /// <returns>List of Clients</returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Order Processing System",
                    ClientId = "OrderProcessingSystemCORE",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<String>
                    {
                        "https://localhost:44369/signin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:44369/signout-callback-oidc"
                    }
                    //AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }
    }
}