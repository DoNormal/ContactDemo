using System.Data.Entity.Migrations;

namespace ContactDemo.Data.Migrations
{
    /// <summary>
    /// Configures settings for all data store migrations.
    /// </summary>
    public class Configuration : DbMigrationsConfiguration<DataContext>
    {
        /// <summary>
        /// Initializes a new instance of the <c>Configuration</c> class.
        /// </summary>
        public Configuration()
        {
            base.AutomaticMigrationsEnabled = true;
            base.AutomaticMigrationDataLossAllowed = false;
        }
    }
}