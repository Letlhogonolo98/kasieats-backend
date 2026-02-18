using KasiEats.Server.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;
    public OrdersController(AppDbContext context) => _context = context;

    [HttpGet("vendor/{vendorId}")]
    public IActionResult GetVendorOrders(int vendorId)
    {
        var orders = _context.Orders
            .Where(o => o.VendorId == vendorId)
            .OrderByDescending(o => o.CreatedAt)
            .ToList();
        return Ok(orders);
    }

    [HttpPut("{id}/status")]
    public IActionResult UpdateOrderStatus(int id, [FromBody] string newStatus)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();

        order.Status = newStatus;
        _context.SaveChanges();
        return Ok(order);
    }
}