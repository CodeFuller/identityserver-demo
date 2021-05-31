using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer
{
	public static class Config
	{
		public static IEnumerable<IdentityResource> IdentityResources =>
			new IdentityResource[]
			{
				new IdentityResources.OpenId(),
			};

		public static IEnumerable<ApiScope> ApiScopes
		{
			get
			{
				yield return new ApiScope("SomeApi", "Some API");
			}
		}

		public static IEnumerable<Client> Clients
		{
			get
			{
				yield return new Client
				{
					ClientId = "Some Confidential Client",
					ClientSecrets = { new Secret("Some Secret".Sha256()) },

					AllowedGrantTypes = GrantTypes.ClientCredentials,

					AllowedScopes =
					{
						"SomeApi",
					},
				};
			}
		}
	}
}
