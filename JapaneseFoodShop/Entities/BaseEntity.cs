using System.ComponentModel.DataAnnotations;

namespace JapaneseFoodShop.Entities
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string?  CreatedBy {  get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public string?  LastUpdateBy {  get; set; }
    }
}
