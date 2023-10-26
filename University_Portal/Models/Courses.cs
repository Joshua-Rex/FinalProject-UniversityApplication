using System.ComponentModel.DataAnnotations.Schema;

namespace University_Portal.Models
{
    public class Courses
    {
        public uint id { get; set; }
        [ForeignKey("Tutors")]
        public uint tutorId { get; set; }
        public string name { get; set; }
        public int moduleAmount { get; set; }
    }
}
