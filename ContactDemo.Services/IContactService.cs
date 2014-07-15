using ContactDemo.Model;

namespace ContactDemo.Services
{
    /// <summary>
    /// Defines a contract for services that handle the contact model.
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Processes a request to get in touch.
        /// </summary>
        /// <param name="item">The incoming contact request.</param>
        /// <returns>A new instance of the processed contact.</returns>
        Contact GetInTouch(PostContact item);
    }
}