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

        public string QuantityPerUnit { get; set; } = null!;

        [Column(TypeName="money")]
        public decimal UnitPrice { get; set; }

        public int UnitsOnOrder { get; set; }

        public bool Discontinued { get; set; } 

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual Supplier Supplier { get; set; } = null!;
    }
}
