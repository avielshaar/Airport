using Airport.Services;
using System.Timers;

namespace Airport.Models.Logics
{
    public class Simulator
    {
        private readonly ILogicService _service;
        private readonly Random _random;
        private bool _active;

        public Simulator(ILogicService service)
        {
            _service = service;
            _random = new Random();
            _active = false;
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (_active)
                    {
                        AddArrivel();
                        AddDeparture();
                    }
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
        }

        public void Start()
        {
            _active = true;
        }

        public void Stop() 
        {
            _active = false;
        }

        public void AddArrivel()
        {
            if (_random.Next(0, 5) == 0)
            {
                _service.AddPlane(false);
            }
        }

        public void AddDeparture()
        {
            if (_random.Next(0, 5) == 0)
            {
                _service.AddPlane(true);
            }
        }
    }
}
