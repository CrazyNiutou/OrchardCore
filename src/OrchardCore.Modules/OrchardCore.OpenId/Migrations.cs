using System;
using OrchardCore.Data.Migration;
using OrchardCore.OpenId.YesSql.Indexes;

namespace OrchardCore.OpenId
{
    public class Migrations : DataMigration
    {
        public int Create()
        {
            SchemaBuilder.CreateMapIndexTable(nameof(OpenIdApplicationIndex), table => table
                .Column<string>(nameof(OpenIdApplicationIndex.ApplicationId), column => column.WithLength(48))
                .Column<string>(nameof(OpenIdApplicationIndex.ClientId), column => column.Unique()));

            SchemaBuilder.CreateReduceIndexTable(nameof(OpenIdApplicationByPostLogoutRedirectUriIndex), table => table
                .Column<string>(nameof(OpenIdApplicationByPostLogoutRedirectUriIndex.PostLogoutRedirectUri))
                .Column<int>(nameof(OpenIdApplicationByPostLogoutRedirectUriIndex.Count)));

            SchemaBuilder.CreateReduceIndexTable(nameof(OpenIdApplicationByRedirectUriIndex), table => table
                .Column<string>(nameof(OpenIdApplicationByRedirectUriIndex.RedirectUri))
                .Column<int>(nameof(OpenIdApplicationByPostLogoutRedirectUriIndex.Count)));

            SchemaBuilder.CreateReduceIndexTable(nameof(OpenIdApplicationByRoleNameIndex), table => table
                .Column<string>(nameof(OpenIdApplicationByRoleNameIndex.RoleName))
                .Column<int>(nameof(OpenIdApplicationByRoleNameIndex.Count)));

            SchemaBuilder.CreateMapIndexTable(nameof(OpenIdAuthorizationIndex), table => table
                .Column<string>(nameof(OpenIdAuthorizationIndex.AuthorizationId), column => column.WithLength(48))
                .Column<string>(nameof(OpenIdAuthorizationIndex.ApplicationId), column => column.WithLength(48))
                .Column<string>(nameof(OpenIdAuthorizationIndex.Status))
                .Column<string>(nameof(OpenIdAuthorizationIndex.Subject))
                .Column<string>(nameof(OpenIdAuthorizationIndex.Type)));

            SchemaBuilder.CreateMapIndexTable(nameof(OpenIdScopeIndex), table => table
                .Column<string>(nameof(OpenIdScopeIndex.Name))
                .Column<string>(nameof(OpenIdScopeIndex.ScopeId), column => column.WithLength(48)));

            SchemaBuilder.CreateMapIndexTable(nameof(OpenIdTokenIndex), table => table
                .Column<string>(nameof(OpenIdTokenIndex.TokenId), column => column.WithLength(48))
                .Column<string>(nameof(OpenIdTokenIndex.ApplicationId), column => column.WithLength(48))
                .Column<string>(nameof(OpenIdTokenIndex.AuthorizationId), column => column.WithLength(48))
                .Column<DateTimeOffset>(nameof(OpenIdTokenIndex.ExpirationDate))
                .Column<string>(nameof(OpenIdTokenIndex.ReferenceId))
                .Column<string>(nameof(OpenIdTokenIndex.Status))
                .Column<string>(nameof(OpenIdTokenIndex.Subject)));

            return 1;
        }
    }
}
