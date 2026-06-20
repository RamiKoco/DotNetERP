using System.Data.Entity.Migrations;
using DotNet.ERP.Data.Contexts;

namespace DotNet.ERP.Data.ERPMigration
{
   public class ERPConfiguration:DbMigrationsConfiguration<ERPContext>
    {
        public ERPConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
