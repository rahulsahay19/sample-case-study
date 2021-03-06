﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Medical.API.Features.Medicine.Models
{
    public class CreateMedicineRequestModel
    {
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public string Text { get; set; }
    }
}
