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
            if (walks == null)
            {
                return NotFound();
            }

            var walksDTO = mapper.Map<Models.DTO.Walk>(walks);

            return Ok(walksDTO);


        }

        [HttpPost]
        public async Task<IActionResult> AddWalk([FromBody] Models.DTO.AddWalkRequest addwalkquest)
        {

            /*Convert DTO to Domain Obj*/
            var walkDomain = new Models.Domain.Walk
            {
                Length = addwalkquest.Length,
                Name = addwalkquest.Name,
                RegionId = addwalkquest.RegionId,
                WalkDifficultyId = addwalkquest.WalkDifficultyId,

            };

            /*Pass domain object to repository to persist it*/
            walkDomain = await walkRepository.AddAsync(walkDomain);
            /*Convert to Domain object back to DTO*/
            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);
            /*SendFileFallback DTO response back to Client*/
            return CreatedAtAction(nameof(GetWalkById), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkRequest updatewalkquest)
        {

            /*Covert DTO to Domain model*/
            var walkDomain = new Models.Domain.Walk()
            {
                Name = updatewalkquest.Name,
                Length = updatewalkquest.Length,
                RegionId = updatewalkquest.RegionId,
                WalkDifficultyId = updatewalkquest.WalkDifficultyId,
            };

            walkDomain = await walkRepository.UpdateAsync(id, walkDomain);

            if (walkDomain == null)
            {
                return NotFound();
            }

            /*Covert Domain back to DTO model*/
            var walkDTO = new Models.DTO.Walk
            {
                Id = walkDomain.Id,
                Name = walkDomain.Name,
                Length = walkDomain.Length,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId,
            };

            return Ok(walkDTO);


        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walks = await walkRepository.DeleteAsync(id);
            if (walks == null)
            {
                return NotFound();
            }


            return Ok();
        }

    }
}
