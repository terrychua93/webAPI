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
    }
}
