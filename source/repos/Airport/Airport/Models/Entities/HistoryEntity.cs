using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models.Entities
{
    public class HistoryEntity
    {
        public int Id { get; set; }
        public int PlaneId { get; set; }
        public int StationId { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
    }
}
