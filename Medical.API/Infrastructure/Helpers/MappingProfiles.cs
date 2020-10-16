using AutoMapper;
using Medical.API.Data.Models;
using Medical.API.Features.Medicine.Models;

namespace Medical.API.Infrastructure.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Medicine, CreateMedicineRequestModel>();
        }
    }
}
