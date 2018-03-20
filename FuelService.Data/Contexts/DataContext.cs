using FuelService.Data.Migrations;
using FuelService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FuelService.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }

        public DbSet<FuelEntity> FuelList { get; set; }
    }
}
