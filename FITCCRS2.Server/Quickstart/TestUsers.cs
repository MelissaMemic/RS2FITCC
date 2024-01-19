// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "Adresa1",
                    locality = "Mostar",
                    postal_code = 88000,
                    country = "BiH"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "meli",
                        Password = "Test123!",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Melissa Memic"),
                            new Claim(JwtClaimTypes.GivenName, "Melissa"),
                            new Claim(JwtClaimTypes.FamilyName, "Memic"),
                            new Claim(JwtClaimTypes.Email, "mellimostar@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://google.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "lamija",
                        Password = "Test123!",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Lamija Babovic"),
                            new Claim(JwtClaimTypes.GivenName, "Lamija"),
                            new Claim(JwtClaimTypes.FamilyName, "Babovic"),
                            new Claim(JwtClaimTypes.Email, "lamija.babovic@edu.fit.ba"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}