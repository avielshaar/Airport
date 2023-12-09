using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models.Logics
{
    public class Plane
    {
        public int Id { get; set; }
        public bool Type { get; set; } // false for arrivel, true for departure

        public Plane(int planeId, bool type)
        {
            Id = planeId;
            Type = type;
        }
    }
}
