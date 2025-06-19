using Abp.Authorization;
using Project2144.Authorization.Roles;
using Project2144.Authorization.Users;

namespace Project2144.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
