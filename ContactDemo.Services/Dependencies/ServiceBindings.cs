using FluentValidation;
using Ninject.Modules;

using ContactDemo.Model;

namespace ContactDemo.Services.Dependencies
{
    /// <summary>
    /// Defines bindings for the service layer.
    /// </summary>
    public class ServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the service objects into ther kernel.
        /// </summary>
        public override void Load()
        {
            /* Services */
            this.Bind<IContactService>().To<ContactService>();
            this.Bind<IStorageService>().ToProvider<DiskStorageServiceProvider>();
            this.Bind<IEmailService>().ToProvider<EmailServiceProvider>();

            /* Validators */
            this.Bind<IValidator<PostContact>>().To<PostContactValidator>().InSingletonScope();
        }
    }
}