using System.IO;

namespace ContactDemo.Services
{
    /// <summary>
    /// Defines a contract for storing files.
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Save a file to the storage.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="fileContents">The contents of the file.</param>
        void Save(string fileName, Stream fileContents);
    }
}