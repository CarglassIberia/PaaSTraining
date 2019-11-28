namespace BuyCoffee.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeBuyersController : ControllerBase
    {
        private readonly CoffeeBuyersContext _context;

        public CoffeeBuyersController(CoffeeBuyersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhoBuyedCoffee>>> Get()
        {
            var buyers = await _context.CoffeeBuyers.ToListAsync();
            if (buyers.Any()) return Ok(buyers);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WhoBuyedCoffee>> Get(int id)
        {
            if (id == 0) return BadRequest();
            var buyer = await _context.CoffeeBuyers.FirstAsync(x => x.Id == id);
            if (buyer == null) return NotFound();
            return Ok(buyer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WhoBuyedCoffee value)
        {
            await _context.CoffeeBuyers.AddAsync(value);
            var affectedResults = await _context.SaveChangesAsync();
            if (affectedResults > 0) return Ok();
            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] WhoBuyedCoffee value)
        {
            return await Post(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var buyer = await _context.CoffeeBuyers.FirstAsync(x => x.Id == id);
            if (buyer == null) return NotFound();
            _context.CoffeeBuyers.Remove(buyer);
            var affectedResults = await _context.SaveChangesAsync();
            if (affectedResults > 0) return Ok();
            return BadRequest();
        }
    }
}