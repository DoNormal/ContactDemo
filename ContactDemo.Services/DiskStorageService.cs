using System.IO;

namespace ContactDemo.Services
{
    /// <summary>
    /// Services for storing files on a local disk.
    /// </summary>
    public class DiskStorageService : IStorageService
    {
        /// <summary>
        /// The virtual directory to save to.
        /// </summary>
        protected readonly string UploadDirectory;

        /// <summary>
        /// Initializes a new instance of the <c>DiskStorageService</c> class with the specified
        /// upload directory.
        /// </summary>
        /// <param name="uploadDirectory">The virtual directory to save to.</param>
        public DiskStorageService(string uploadDirectory)
        {
            this.UploadDirectory = uploadDirectory;
        }

        /// <summary>
        /// Does the file exist?
        /// </summary>
        /// <param name="fileName">The name of the file to check.</param>
        /// <returns>True if the file exists; otherwise false</returns>
        public bool FileExist(string fileName)
        {
            string path = this.GetFullPath(fileName);
            return File.Exists(path);
        }

        /// <summary>
        /// Saves the file to local disk.
        /// </summary>
        /// <param name="fileName">The name of the file to save.</param>
        /// <param name="fileContents">The contents of the file to save.</param>
        public void Save(string fileName, Stream fileContents)
        {
            /* The file might have been already read in this request, which puts
             * the file pointer at the end of the file, which in turn leads to an
             * unreadable stream. Reset to the beginning of the stream. */
            fileContents.Seek(0, SeekOrigin.Begin);

            string path = this.GetFullPath(fileName);
            using (var destinationStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                fileContents.CopyTo(destinationStream);
            }
        }

        /// <summary>
        /// Helper method for generating a full path to the file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>A full path to the file.</returns>
        protected string GetFullPath(string fileName)
        {
            return Path.Combine(new string[] { this.UploadDirectory, fileName });
        }
    }
}