using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using receiptAPI.Data;
using receiptAPI.Dtos;
using receiptAPI.Models;

namespace receiptAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceiptsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReceipt([FromForm] ReceiptDto receiptDto, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required.");
            }

            // Saving the file to wwwroot/uploads
            var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsDir))
            {
                Directory.CreateDirectory(uploadsDir);
            }
            var filePath = Path.Combine(uploadsDir, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Creating and saving the receipt entity
            var receipt = new Receipt
            {
                Date = receiptDto.Date,
                Amount = receiptDto.Amount,
                Description = receiptDto.Description,
                FilePath = filePath,
                Create_Date = DateTime.Now
            };

            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Receipt submitted successfully." });
        }

        [HttpGet("test-db")]
        public IActionResult TestDatabase()
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();
                return Ok("Database connection successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Database connection failed: {ex.Message}");
            }
        }
    }




}
