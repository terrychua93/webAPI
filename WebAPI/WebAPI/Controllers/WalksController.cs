using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        public WalksController(IWalkRepository walkRespository)
        {
            this.walkRepository =walkRespository;
        }

        [HttpGet]
        public IActionResult GetAllWalk()
        {
            var regions = walkRepository.GetAll();
            return Ok(regions);

        }
    }
}
