using System.ComponentModel.DataAnnotations;

namespace JapaneseFoodShop.Entities
{
    public class Permission
    {
        [Key]
        public string Id { get; set; }
        public string Function { get; set; }
        public PermissionType Type { get; set; }
    }

    public enum PermissionType
    {
        Create,
        Update,
        Delete,
        View
    }
}
