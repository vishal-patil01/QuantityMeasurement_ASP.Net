using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ModelLayer
{
   public class QuantityMeasurementDBContext : DbContext
    {
        public DbSet<MainUnits> MainUnits { get; set; }
        public DbSet<Subunit> Subunits { get; set; }


        public QuantityMeasurementDBContext(DbContextOptions<QuantityMeasurementDBContext> options):base(options)
        {}
    }
}
