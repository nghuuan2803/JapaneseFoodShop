namespace JapaneseFoodShop.Entities
{
    public class User : BaseEntity<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public DateTime? UnLocked { get; set; }
        public int LoginFailedAttempt { get; set; }
        public Role Role { get; set; }
    }
}
