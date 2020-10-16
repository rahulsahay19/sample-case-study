using System;
using System.ComponentModel.DataAnnotations;

namespace Medical.API.Features.Medicine.Models
{
    public class MedicineDetailServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Text { get; set; }
    }
}
