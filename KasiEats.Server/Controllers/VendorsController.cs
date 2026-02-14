using BCrypt.Net; // Import BCrypt
using KasiEats.Server.Data;
using KasiEats.DTOs;
using KasiEats.Models;
using Microsoft.AspNetCore.Mvc;

namespace KasiEats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // 1. Check if email is already taken
            if (_context.Vendors.Any(v => v.Email == request.Email))
            {
                return BadRequest(new { message = "Email is already registered." });
            }

            // 2. Hash the password before saving
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newVendor = new Vendor
            {
                ShopName = request.ShopName,
                Email = request.Email,
                Password = hashedPassword, 
                Description = request.Description
            };

            _context.Vendors.Add(newVendor);
            _context.SaveChanges();

            return Ok(new { message = "Registration successful!" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var vendor = _context.Vendors.FirstOrDefault(v => v.Email == request.Email);
            // BCrypt.Verify compares the plain text password with the stored hash
            if (vendor == null || !BCrypt.Net.BCrypt.Verify(request.Password, vendor.Password))
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            return Ok(new { id = vendor.Id, name = vendor.ShopName, email = vendor.Email });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, [FromBody] VendorUpdateDto updateDto)
        {
            var vendor = _context.Vendors.Find(id);
            if (vendor == null) return NotFound();

            vendor.ShopName = updateDto.ShopName;
            vendor.Description = updateDto.Description;
            vendor.LogoUrl = updateDto.LogoUrl;

            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendor(int id)
        {
            var vendor = _context.Vendors.Find(id);
            if (vendor == null) return NotFound();
            return Ok(vendor);
        }
    }
}