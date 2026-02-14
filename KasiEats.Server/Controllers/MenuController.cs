using KasiEats.Models;
using KasiEats.Server.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly AppDbContext _context;
    public MenuController(AppDbContext context) => _context = context;

    [HttpGet("vendor/{vendorId}")]
    public IActionResult GetVendorMenu(int vendorId)
    {
        var items = _context.MenuItems.Where(m => m.VendorId == vendorId).ToList();
        return Ok(items);
    }

    [HttpPost]
    public IActionResult AddMenuItem([FromBody] MenuItem item)
    {
        _context.MenuItems.Add(item);
        _context.SaveChanges();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMenuItem(int id)
    {
        var item = _context.MenuItems.Find(id);
        if (item == null) return NotFound();

        _context.MenuItems.Remove(item);
        _context.SaveChanges();

        return Ok(new { message = "Item deleted" });
    }
}