using System.ComponentModel.DataAnnotations.Schema;

namespace University_Portal.Models
{
    public class Events
    {
        public uint id { get; set; }
        [ForeignKey("Users")]
        public uint userId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
    }
}
