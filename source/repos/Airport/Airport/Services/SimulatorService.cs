using Airport.Models.Logics;

namespace Airport.Services
{
    public class SimulatorService : ISimulatorService
    {
        private readonly Simulator _simulator;

        public SimulatorService(Simulator simulator)
        {
            _simulator = simulator;
        }

        public void Start()
        {
            _simulator.Start();
        }

        public void Stop()
        {
            _simulator.Stop();
        }
    }
}
