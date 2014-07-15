using System.IO;

namespace ContactDemo.Model
{
    public class PostContact
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string FileName { get; set; }
        public Stream FileContents { get; set; }
    }
}