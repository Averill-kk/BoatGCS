using BoatGCS.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGCS.Entities
{
    public class GpsDataContext : DbContext
    {
        public GpsDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
        public DbSet<GpsData> GpsDatas { get; set; }

 
    }
}
