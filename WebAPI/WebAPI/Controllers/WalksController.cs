using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;
        public WalksController(IWalkRepository walkRespository, IMapper mapper)
        {
            this.walkRepository = walkRespository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalk()
        {
            var walks = await walkRepository.GetAllAsync();
            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walks);
            return Ok(walksDTO);

        }

        [HttpGet("{id:guid}")]
        [ActionName("GetWalkById")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walks = await walkRepository.GetAsync(id);
            if(walks == null)
            {
                return NotFound();
            }

            var walksDTO = mapper.Map<Models.DTO.Walk>(walks);

            return Ok(walksDTO);


        }

        [HttpPost]
        public async Task<IActionResult> AddWalk(Walk walk)
        {
            /* Request to Domain model */
            walk = mapper.Map<Walk>(walk);
            if(walk == null)
            {
                return NotFound();
            }


            /* Pass details to Repository */
            walk = await walkRepository.AddAsync(walk);

            /* Convert back to DTO */
            var walkDTO = new Models.DTO.Walk() {
                Id = walk.Id,
                Name = walk.Name,
                Length = walk.Length,
            
            };

            return CreatedAtAction(nameof(GetWalkById), new { id = walkDTO.Id }, walkDTO);

        }
        
    }
}
