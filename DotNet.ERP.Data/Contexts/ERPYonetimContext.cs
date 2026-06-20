using DotNet.ERP.Data.ERPYonetimMigration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Data.Contexts
{
    public class ERPYonetimContext : BaseDbContext<ERPYonetimContext, ERPYonetimConfiguration>
    {

        public ERPYonetimContext()
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public ERPYonetimContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }

        public DbSet<Kurum> Kurum { get; set; }

    }
}
