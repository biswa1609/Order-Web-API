using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApi.Models
{
    [Table("Order", Schema ="dbo")]
    public class Order
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Item")]
        public string Item { get; set; }

        [Column("Price")]
        public decimal  Price { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }
    }
}
