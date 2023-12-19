using Airport.Services;

namespace Airport.Logic
{
    public class Simulator
    {
        private readonly ILogicService _service;
        
        public Simulator(ILogicService service)
        {
            _service = service;
        }

        public async Task AddPlanes()
        {
            Random arrivelRandom = new Random();
            Random departureRandom = new Random();
            if (arrivelRandom.Next(0, 3) == 0)
            {
                await _service.AddPlane(false);
            }
            if (departureRandom.Next(0, 3) == 0)
            {
                await _service.AddPlane(true);
            }
        }
    }
}
