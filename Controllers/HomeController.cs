using Microsoft.AspNetCore.Mvc;
using Pubinno.Auth;
using Pubinno.Business;
using Pubinno.Models;

namespace Pubinno.Controllers
{
    [ApiController]
    [ApiKeyAuth]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LocationBusiness _locationBusiness;

        public HomeController(ILogger<HomeController> logger, LocationBusiness locationBusiness)
        {
            _logger = logger;
            _locationBusiness = locationBusiness;
        }

        [HttpPost("NewLocation")]
        public async Task<IActionResult> NewLocation([FromBody] LocationViewModel location)
        {
            var res = await _locationBusiness.NewLocation(location);
            if (res.Success) return Ok(res);
            else
            {
                _logger.LogError(res?.FirstError?.Description);
                return NotFound();
            }
        }

        [HttpPut("EditLocation")]
        public async Task<IActionResult> EditLocation([FromBody] LocationUpdateViewModel location)
        {
            var res = await _locationBusiness.EditLocation(location);
            if (res.Success) return Ok(res);
            else
            {
                _logger.LogError(res?.FirstError?.Description);
                return NotFound();
            }
        }

        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation([FromQuery] int id)
        {
            var res = await _locationBusiness.DeleteLocation(id);
            if (res.Success) return Ok(res);
            else
            {
                _logger.LogError(res?.FirstError?.Description);
                return NotFound();
            }
        }

        [HttpGet("GetLocation")]
        public async Task<IActionResult> GetLocation([FromQuery] int id)
        {
            var res = await _locationBusiness.GetLocation(id);
            if (res.Success) return Ok(res);
            else
            {
                _logger.LogError(res?.FirstError?.Description);
                return NotFound();
            }
        }

        [HttpGet("GetAllLocation")]
        public async Task<IActionResult> GetAllLocation()
        {
            var res = await _locationBusiness.GetAllLocation();
            if (res.Success) return Ok(res);
            else
            {
                _logger.LogError(res?.FirstError?.Description);
                return NotFound();
            }
        }
    }
}
