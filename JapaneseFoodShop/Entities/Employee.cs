namespace JapaneseFoodShop.Entities
{
    public class Employee : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Position { get; set; } = EmployeePosition.Staff;
        public double Salary { get; set; } = 3000000;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public string? IdentityCard { get; set; }
        public bool IsWorking { get; set; } = true;

        public string? UserId { get; set; }
        public User User { get; set; }
    }

    public static class EmployeePosition
    {
        public const string Manager = "Quản lý";
        public const string Director = "Giám đốc";
        public const string Staff = "Nhân viên";
        public const string Guard = "Bảo vệ";
    }
}
