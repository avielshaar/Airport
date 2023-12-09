using Airport.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_logicService.GetPlaneDTOs());
        }

        [HttpPost]
        public IActionResult Start()
        {
            _logicService.Start();
            _simulatorService.Start();
            return Ok();
        }

        [HttpPost]
        public IActionResult Stop()
        {
            _logicService.Stop();
            _simulatorService.Stop();
            return Ok();
        }
    }
}
