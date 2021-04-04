using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(90)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductType { get; set; }
    }
}
