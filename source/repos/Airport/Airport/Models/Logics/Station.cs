using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models.Logics
{
    public class Station
    {
        public int Id { get; set; }
        public Plane? Plane { get; set; }
        public bool IsOccupied { get { return Plane != null; } }
        public Station? NextStation { get; set; }

        public Station(int id, Plane? plane)
        {
            Id = id;
            Plane = plane;
        }

        public void MovePlane()
        {
            if (Plane != null)
            {
                if (NextStation == null)
                {
                    Plane = null;
                }
                else if (!NextStation.IsOccupied)
                {
                    NextStation.Plane = Plane;
                    Plane = null;
                }
            }
        }
    }
}
