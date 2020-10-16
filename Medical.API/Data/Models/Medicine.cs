using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.API.Data.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public string Text { get; set; }
    }
}
