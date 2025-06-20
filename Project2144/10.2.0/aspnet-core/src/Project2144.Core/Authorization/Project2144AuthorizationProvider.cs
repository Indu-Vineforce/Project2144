using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Project2144.Authorization;

public class Project2144AuthorizationProvider : AuthorizationProvider
{
    public override void SetPermissions(IPermissionDefinitionContext context)
    {
        context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
        context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
        context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
        context.CreatePermission(PermissionNames.Pages_Products, L("Products"), multiTenancySides: MultiTenancySides.Host);
        context.CreatePermission(PermissionNames.Pages_Interns, L("Interns"), multiTenancySides: MultiTenancySides.Host);
        context.CreatePermission(PermissionNames.Pages_Departments, L("Departments"), multiTenancySides: MultiTenancySides.Host);
        context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
    }

    private static ILocalizableString L(string name)
    {
        return new LocalizableString(name, Project2144Consts.LocalizationSourceName);
    }
}
