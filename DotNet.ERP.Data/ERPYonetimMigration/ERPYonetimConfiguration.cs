using System.Data.Entity.Migrations;
using DotNet.ERP.Data.Contexts;

namespace DotNet.ERP.Data.ERPYonetimMigration
{
    public class ERPYonetimConfiguration : DbMigrationsConfiguration<ERPYonetimContext>
    {

        public ERPYonetimConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }
    }
}
