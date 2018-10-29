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
    class GpsDataContext : DbContext
    {
        public GpsDataContext(): base(CreateConnectionString())
        {

        }
        public DbSet<GpsData> GpsDatas { get; set; }

        static public string CreateConnectionString()
        {
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder();
            entityConnectionStringBuilder.Provider = "System.Data.SqlClient";
            entityConnectionStringBuilder.ProviderConnectionString = ConnectionString.Current.Connection;
            entityConnectionStringBuilder.Metadata = "res://*";
            return entityConnectionStringBuilder.ToString();
        }
    }
}
