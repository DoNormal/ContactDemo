using System.Data.Entity;

namespace ContactDemo.Data.Initializers
{
    /// <summary>
    /// Defines an initializer for the ContactDemo application that migrates the data
    /// store to the latest version.
    /// </summary>
    public class MigrateInitializer : MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>
    {
    }
}