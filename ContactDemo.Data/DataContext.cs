using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using ContactDemo.Data.ModelConfiguration;
using ContactDemo.Model;

namespace ContactDemo.Data
{
    /// <summary>
    /// Accesspoint for retrieving and modifying data in the data store.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Gets or sets a collection of <c>Contact</c> entities.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Initializes a new instance of the <c>DataContext</c> class.
        /// </summary>
        public DataContext()
        {
            /* We don't use these EF features, so turn them off for a performance gain.
             * See: http://stackoverflow.com/a/11923527 */
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.AutoDetectChangesEnabled = false;
            base.Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// Handles the <c>ModelCreating</c> event by setting up model configuration.
        /// </summary>
        /// <param name="modelBuilder">The model builder to add configuration to.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* Prefer singular table names. */
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /* Add models. */
            modelBuilder.Configurations.Add(new ContactConfiguration());
        }
    }
}