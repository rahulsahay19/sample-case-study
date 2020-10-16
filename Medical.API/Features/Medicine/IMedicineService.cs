using System.Collections.Generic;
using System.Threading.Tasks;
using Medical.API.Features.Medicine.Models;

namespace Medical.API.Features.Medicine
{
    public interface IMedicineService
    {
        Task<int> Create(CreateMedicineRequestModel createMedicineRequestModel);
        Task<IEnumerable<MedicineListServiceModel>> GetMedicines();
        Task<MedicineDetailServiceModel> GetMedicineById(int id);
        Task<MedicineDetailServiceModel> GetMedicineByName(string name);
        Task<bool> UpdateMedicine(UpdateMedicineRequestModel updateMedicineRequestModel);
        Task<bool> DeleteMedicine(string name);
        Task<bool> DeleteMedicine(int id);
        Task<IEnumerable<MedicineListServiceModel>> GetMedicinesByBrandName(string brand);
        Task<IEnumerable<BrandRequestModel>> GetBrands();
        Task<IEnumerable<MedicineListServiceModel>> GetMedicineBySearchTerm(string searchTerm);
    }
}
