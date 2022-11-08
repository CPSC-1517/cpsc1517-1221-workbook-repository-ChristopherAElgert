using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestwindSystem.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        //[Column(TypeName="money")]
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}