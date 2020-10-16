using System;

namespace Medical.API.Features.Medicine.Models
{
    public class MedicineListServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

    }
}
