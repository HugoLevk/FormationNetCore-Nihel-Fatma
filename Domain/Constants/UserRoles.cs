namespace Regies.Domain.Constants
{
    public static class UserRoles
    {
        public static readonly (string Name, string NormalizedName) s_Admin = ("Admin", "ADMIN");
        public static readonly (string Name, string NormalizedName) s_Manager = ("Manager", "MANAGER");
        public static readonly (string Name, string NormalizedName) s_User = ("User", "USER");
    }
}
