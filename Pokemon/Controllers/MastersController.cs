using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;
using Pokemon.Services;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MastersController : ControllerBase
    {
        private readonly MasterService _masterService;

        public MastersController(MasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMaster(Master master)
        {
            var createdMaster = await _masterService.AddMasterAsync(master);
            return Ok(createdMaster);
        }

        [HttpGet]
        public async Task<IActionResult> GetMasters()
        {
            var masters = await _masterService.GetMastersAsync();
            return Ok(masters);
        }
    }
}
