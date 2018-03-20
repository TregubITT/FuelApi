using FuelService.Data.Migrations;
using FuelService.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


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
