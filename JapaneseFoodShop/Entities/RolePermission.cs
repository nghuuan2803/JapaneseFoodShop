namespace JapaneseFoodShop.Entities
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public string PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
