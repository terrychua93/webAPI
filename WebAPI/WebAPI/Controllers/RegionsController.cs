using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        public RegionsController(IRegionRepository regionRespository,IMapper mapper)
        {
            this.regionRepository = regionRespository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ActionName("GetAllRegions")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            // return DTO regions

            //var regionsDTO = new List<Models.DTO.Region>();
            //foreach (var region in regions)
            //{
            //   var regionDTO = new Models.DTO.Region()
            //    {
            //        RegionId = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,

            //   };

            //   regionsDTO.Add(regionDTO);
            //}

            // return with mapper
            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);

        }
        [HttpGet("{id:guid}")]
        [ActionName("GetRegionByIdAsync")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            var regionsDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            /* Request to Domain model */
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population,
            };

            /* Pass details to Repository */

            region = await regionRepository.AddAsync(region);

            /* Convert back to DTO */

            var regionDTO = new Models.DTO.Region
            {
                RegionId = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetAllRegions), new { id = regionDTO.RegionId },regionDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = new Models.DTO.Region {
                RegionId = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return Ok(regionDTO);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            /*Covert DTO to Domain model*/
            var region = new Models.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Population = updateRegionRequest.Population,
            };

            region = await regionRepository.UpdateAsync(id, region);

            if(region == null)
            {
                return NotFound();
            }

            /*Covert Domain back to DTO model*/
            var regionDTO = new Models.DTO.Region
            {
                RegionId = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return Ok(regionDTO);
        }

    }
}
