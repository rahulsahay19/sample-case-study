using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medical.API.Features.Medicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.API.Features.Medicine
{
    public class MedicineController : ApiController
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public MedicineController(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        /// <summary>
        /// Method to create a Medicine, takes model of type CreateMedicineRequestModel.
        /// <param name="model"></param>
        /// </summary>
        [HttpPost("createMedicine", Name = "Create a Medicine")]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        public async Task<ActionResult> Create([FromBody]CreateMedicineRequestModel model)
        {
            var id = await _medicineService.Create(model);
            return CreatedAtAction("Create", id);
        }
        /// <summary>
        /// Method to get all Medicines
        /// </summary>
        /// <returns></returns>

        [HttpGet(Name = "Get list of all medicines")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        // public async Task<IEnumerable<MedicineListServiceModel>> GetMedicines([FromQuery]MedicineParams medicineParams)
        public async Task<ActionResult<Pagination<MedicineListServiceModel>>> GetMedicines([FromQuery] MedicineParams medicineParams)
        {
            IEnumerable<MedicineListServiceModel> medicines;
            medicines = await _medicineService.GetMedicines();
            var totalItems = medicines.Count();
            var result = await ApplyPagination(medicineParams, medicines);
            return Ok(new Pagination<MedicineListServiceModel>(medicineParams.PageIndex, medicineParams.PageSize,
                totalItems, result));
        }

        /// <summary>
        /// Get Medicine by search term
        /// </summary>
        /// <param name="medicineParams"></param>
        /// <returns></returns>
        [HttpGet(template:"bySearchTerm", Name = "Search by search term.")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        // public async Task<IEnumerable<MedicineListServiceModel>> GetMedicines([FromQuery]MedicineParams medicineParams)
        public async Task<ActionResult<Pagination<MedicineListServiceModel>>> SearchByTerm([FromQuery] MedicineParams medicineParams)
        {
            IEnumerable<MedicineListServiceModel> medicines;
            medicines = await _medicineService.GetMedicineBySearchTerm(medicineParams.Search);
            var totalItems = medicines.Count();
            var result = await ApplyPagination(medicineParams, medicines);
            return Ok(new Pagination<MedicineListServiceModel>(medicineParams.PageIndex, medicineParams.PageSize,
                totalItems, result));
        }

        /// <summary>
        /// Get medicines by brand name
        /// </summary>
        /// <param name="medicineParams"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpGet(template: "byBrandName/{name}", Name = "Get list of all medicines by brand name")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<MedicineListServiceModel>>> GetMedicinesByBrandName([FromQuery] MedicineParams medicineParams, string name)
        {
            return await FilterMedicinesByBrandName(medicineParams, name);
        }

        /// <summary>
        /// Get all brand names
        /// </summary>
        /// <returns></returns>

        [HttpGet(template: "getBrands", Name = "Get list of all brand names")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BrandRequestModel>>> GetBrands()
        {
            return Ok(await _medicineService.GetBrands());
        }

        /// <summary>
        /// Method to get Medicine detail by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpGet("byName/{name}", Name = "Get medicine details by name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicineDetailServiceModel>> GetMedicineDetail(string name)
        {
            return await _medicineService.GetMedicineByName(name);
        }
        /// <summary>
        /// Method to get Medicine detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("byId/{id}", Name = "Get medicine details by id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicineDetailServiceModel>> GetMedicineDetailById(int id)
        {
            return await _medicineService.GetMedicineById(id);
        }

        /// <summary>
        /// Method to update Medicine by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPut("modifyMedicine", Name = "Method to update medicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(UpdateMedicineRequestModel model)
        {
            var updated = await _medicineService.UpdateMedicine(model);
            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Method to delete Medicine
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete(template: "deleteByName/{name}", Name = "Delete medicine by name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteMedicine(string name)
        {
            var deleted = await _medicineService.DeleteMedicine(name);
            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete(template:"deleteById/{id}", Name = "Delete medicine by id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteMedicine(int id)
        {
            var deleted = await _medicineService.DeleteMedicine(id);
            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        private async Task<ActionResult<Pagination<MedicineListServiceModel>>> FilterMedicinesByBrandName([FromQuery] MedicineParams medicineParams, string? name)
        {
            List<MedicineListServiceModel> result = null;
            if (name == "All")
            {
                var items = await _medicineService.GetMedicines();
                var totalCount = items.Count();
                result = await ApplyPagination(medicineParams, items);
                return Ok(new Pagination<MedicineListServiceModel>(medicineParams.PageIndex, medicineParams.PageSize,
                    totalCount, result));
            }

            var medicines = await _medicineService.GetMedicinesByBrandName(name);
            var totalItems = medicines.Count();
            result = await ApplyPagination(medicineParams, medicines);
            return Ok(new Pagination<MedicineListServiceModel>(medicineParams.PageIndex, medicineParams.PageSize,
                totalItems, result));
        }

        private async Task<List<MedicineListServiceModel>> ApplyPagination(MedicineParams medicineParams, IEnumerable<MedicineListServiceModel> items)
        {
            IEnumerable<MedicineListServiceModel> medicines = null;
            int currentPage = medicineParams.PageIndex;
            int pageSize = medicineParams.PageSize;
            var result = items.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return result;
        }
    }
}
