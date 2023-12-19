using Airport.Logic;

namespace Airport.Services
{
    public class SimulatorService : ISimulatorService
    {
        private readonly Simulator _simulator;

        public SimulatorService(Simulator simulator)
        {
            _simulator = simulator;
        }

        public async Task Run()
        {
            await _simulator.AddPlanes();
        }
    }
}
