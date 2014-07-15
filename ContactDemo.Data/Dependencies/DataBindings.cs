using Ninject.Modules;

namespace ContactDemo.Data.Dependencies
{
    /// <summary>
    /// Defines the bindings for the data layer.
    /// </summary>
    public class DataBindings : NinjectModule
    {
        /// <summary>
        /// Loads the data objects into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<DataContext>().ToSelf();
        }
    }
}