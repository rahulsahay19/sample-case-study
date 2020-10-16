using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.API.Data;
using Medical.API.Features.Medicine.Models;
using Microsoft.EntityFrameworkCore;

namespace Medical.API.Features.Medicine
{
    public class MedicineService : IMedicineService
    {
        private readonly MedicineDbContext _dbContext;

        public MedicineService(MedicineDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(CreateMedicineRequestModel createMedicineRequestModel)
        {
            var medicine = new Data.Models.Medicine
            {
                Brand = createMedicineRequestModel.Brand,
                ExpiryDate = createMedicineRequestModel.ExpiryDate,
                Name = createMedicineRequestModel.Name,
                Quantity = createMedicineRequestModel.Quantity,
                Price = createMedicineRequestModel.Price,
                Text = createMedicineRequestModel.Text
            };
            _dbContext.Add(medicine);
            await _dbContext.SaveChangesAsync();
            return medicine.Id;
        }

        public async Task<IEnumerable<MedicineListServiceModel>> GetMedicines()
        {
           return await _dbContext.Medicines.Select(m => new MedicineListServiceModel
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                Brand = m.Brand
            }).ToListAsync();
        }

        public async Task<MedicineDetailServiceModel> GetMedicineById(int id)
        {
            return await _dbContext.Medicines.Where(m => m.Id == id)
                .Select(med => new MedicineDetailServiceModel
                {
                    Id = med.Id,
                    Name = med.Name,
                    Brand = med.Brand,
                    ExpiryDate = med.ExpiryDate,
                    Price = med.Price,
                    Quantity = med.Quantity,
                    Text = med.Text
                }).FirstOrDefaultAsync();
        }

        public async Task<MedicineDetailServiceModel> GetMedicineByName(string name)
        {
            return await _dbContext.Medicines.Where(m => m.Name.ToLower().Contains(name))
                .Select(med => new MedicineDetailServiceModel
                {
                    Id= med.Id,
                    Name = med.Name,
                    Brand = med.Brand,
                    ExpiryDate = med.ExpiryDate,
                    Price = med.Price,
                    Quantity = med.Quantity,
                    Text = med.Text
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMedicine(UpdateMedicineRequestModel updateMedicineRequestModel)
        {
            var medicine = await FetchMedicineByName(updateMedicineRequestModel.Name);
            if (medicine is null)
            {
                return false;
            }

            medicine.Name = updateMedicineRequestModel.Name;
            medicine.Brand = updateMedicineRequestModel.Brand;
            medicine.ExpiryDate = updateMedicineRequestModel.ExpiryDate;
            medicine.Quantity = updateMedicineRequestModel.Quantity;
            medicine.Price = updateMedicineRequestModel.Price;
            medicine.Text = updateMedicineRequestModel.Text;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMedicine(string name)
        {
            var medicine = await FetchMedicineByName(name);
            if (medicine is null)
            {
                return false;
            }

            _dbContext.Medicines.Remove(medicine);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMedicine(int id)
        {
            var medicine = await FetchMedicineById(id);
            if (medicine is null)
            {
                return false;
            }

            _dbContext.Medicines.Remove(medicine);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MedicineListServiceModel>> GetMedicinesByBrandName(string brand)
        {
            return await _dbContext.Medicines.Where(m => m.Brand.ToLower().Contains(brand))
                .Select(med => new MedicineListServiceModel
                {
                    Id = med.Id,
                    Name = med.Name,
                    Brand = med.Brand,
                    Price = med.Price
                }).ToListAsync();

        }

        public async Task<IEnumerable<BrandRequestModel>> GetBrands()
        {
            return await _dbContext.Medicines.Select(m => new BrandRequestModel
            {
                Brand = m.Brand
            }).ToListAsync();
        }

        public async Task<IEnumerable<MedicineListServiceModel>> GetMedicineBySearchTerm(string searchTerm)
        {
            return await _dbContext.Medicines.Where(m => m.Name.ToLower().Contains(searchTerm) || m.Brand.ToLower().Contains(searchTerm))
                .Select(med => new MedicineListServiceModel
                {
                    Id = med.Id,
                    Name = med.Name,
                    Brand = med.Brand,
                    Price = med.Price
                }).ToListAsync();
        }


        private async Task<Data.Models.Medicine> FetchMedicineByName(string name)
        {
            return await _dbContext.Medicines.Where(m => m.Name == name).FirstOrDefaultAsync();
        }

        private async Task<Data.Models.Medicine> FetchMedicineById(int id)
        {
            return await _dbContext.Medicines.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
