using System.ComponentModel.DataAnnotations;

namespace JapaneseFoodShop.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public double Points { get; set; }
        public double CumulativePoints { get; set; }
        public int TypeId { get; set; }
        public CustomerType Type { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
    }

    public class CustomerType : BaseEntity<int>
    {
        public string Name { get; set; }
        public double MinPointRequired { get; set; }
    }
}
