namespace ContactDemo.Web.Infrastructure
{
    /// <summary>
    /// Class for holding shared values for the transfering of date between
    /// the model state and the temp data.
    /// </summary>
    public class ModelStateTempDataTransfer
    {
        /// <summary>
        /// The key that is used in the TempData to hold the errors.
        /// </summary>
        protected static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
    }
}