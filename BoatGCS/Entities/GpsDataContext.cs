using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGCS.Entities
{
    class GpsDataContext : DbContext
    {
        public GpsDataContext(): base("DefaultConnection")
        {

        }
        public DbSet<GpsData> GpsDatas { get; set; }
    }
}
