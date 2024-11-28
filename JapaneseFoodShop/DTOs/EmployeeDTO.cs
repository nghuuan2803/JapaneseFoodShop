namespace JapaneseFoodShop.DTOs
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string? IdentityCard { get; set; }
        public bool IsWorking { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string? LastUpdateBy { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
