using CS_Console.Model;
using BondConsoleApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BondConsoleApp.Models;
using CS_Console.EquityRepo;

namespace CS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquityController : ControllerBase
    {
        private readonly IEquity _equityOperations;

        public EquityController(IEquity equityOperations)
        {
            _equityOperations = equityOperations;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Optionally check file type if needed
            if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only CSV files are allowed.");
            }

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    _equityOperations.ImportDataFromCsv(stream);
                }

                return Ok("File processed successfully.");
            }
            catch (Exception ex)
            {
                // Log the error (optional)
                // _logger.LogError(ex, "Error occurred while processing the file");

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteEquity(int id)
        {
            try
            {
                _equityOperations.DeleteSecurityData(id);
                return Ok(new { message = "Bond successfully marked as inactive." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        [HttpPut("edit")]
        public IActionResult UpdateEquity([FromBody] EditEquityModel equity)
        {
            if (equity == null || equity.SecurityID <= 0)
            {
                return BadRequest(new { message = "Invalid bond data." });
            }

            try
            {
                _equityOperations.UpdateSecurityData(equity);
                return Ok(new { message = "Equity data updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }


        [HttpGet]
        public IActionResult GetEditEquitiesData()
        {
            try
            {
                var equities = _equityOperations.GetSecurityData(); // Call the method to get equity data
                if (equities == null || !equities.Any())
                {
                    return NotFound(new { message = "No equity data found." });
                }

                return Ok(equities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }



    }
}
