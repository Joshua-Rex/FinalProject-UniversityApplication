using System.ComponentModel.DataAnnotations.Schema;

namespace University_Portal.Models
{
    public class Modules
    {
        public uint id { get; set; }
        [ForeignKey("Courses")]
        public uint courseId { get; set; }
        public string name { get; set; }
    }
}
