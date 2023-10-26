using System.ComponentModel.DataAnnotations.Schema;

namespace University_Portal.Models
{
    public class StudentEvents
    {
        public uint id { get; set; }
        [ForeignKey("Students")]
        public uint studentId { get; set; }
        public string name { get; set; }
        public string description {  get; set; }
        public DateTime dateCreated { get; set; }
    }
}
