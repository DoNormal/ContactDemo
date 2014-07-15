using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ContactDemo.Model;

namespace ContactDemo.Data.ModelConfiguration
{
    /// <summary>
    /// Defines data store configuration for the Contact entity.
    /// </summary>
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        /// <summary>
        /// Initializes a new instance of the <c>ContactConfiguration</c> class.
        /// </summary>
        public ContactConfiguration()
        {
            /* Primary key */
            base.HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.Property(c => c.Name)
                .IsRequired();

            base.Property(c => c.EmailAddress)
                .IsRequired();

            base.Property(c => c.WhenCreated)
                .IsRequired();
        }
    }
}