using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KasiEats.Server.Models;

namespace KasiEats.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext _context;

        // The constructor: This pulls in the database connection
        public FoodController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoods()
        {
            // This pulls directly from the Database
            return await _context.FoodItems.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFood(FoodItem food)
        {
            _context.FoodItems.Add(food);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFoods), new { id = food.Id }, food);
        }
    }
}