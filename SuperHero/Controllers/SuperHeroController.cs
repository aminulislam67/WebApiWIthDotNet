using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Services.SuperHero1Service;

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHero1Service _superHero1Service;

        public SuperHeroController(ISuperHero1Service superHero1Service)
        {
            _superHero1Service = superHero1Service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero1>>> GetAllHeroes()
        {
            return await _superHero1Service.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero1>> GetSingleHero(int id)
        {
            var result = await _superHero1Service.GetSingleHero(id);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero1>>> AddHero(SuperHero1 hero)
        {
            var result = await _superHero1Service.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero1>>> UpdateHero(int id, SuperHero1 request)
        {
            var result = await _superHero1Service.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero1>>> DeleteHero(int id)
        {
            var result = await _superHero1Service.DeleteHero(id);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }
    }
}
