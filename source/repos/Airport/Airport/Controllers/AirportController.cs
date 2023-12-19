using Airport.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly ILogicService _logicService;
        private readonly ISimulatorService _simulatorService;

        public AirportController(ILogicService logicService, ISimulatorService simulatorService)
        {
            _logicService = logicService;
            _simulatorService = simulatorService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _logicService.GetPlaneDTOs());
        }

        [HttpPost("Run")]
        public async Task<IActionResult> Run()
        {
            await _logicService.Run();
            await _simulatorService.Run();
            return Ok();
        }
    }
}
