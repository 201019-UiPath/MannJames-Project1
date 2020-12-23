using System.ComponentModel.DataAnnotations;

namespace StoreWeb.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
    }
}