using System;

namespace ContactDemo.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTimeOffset WhenCreated { get; set; }
    }
}