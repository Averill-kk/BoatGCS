using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGCS.Entities
{
    public class GpsData
    {
        public int Id { get; set; }
        public double Latitude { get; set; }

        public double Lontitude { get; set; }

        public int Satellite { get; set; }
    }
}
