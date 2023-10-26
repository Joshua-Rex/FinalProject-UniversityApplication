using System.ComponentModel.DataAnnotations.Schema;

namespace University_Portal.Models
{
    public class Students
    {
        public uint id { get; set; }
        [ForeignKey("Universities")]
        public uint uniId { get; set; }
        [ForeignKey("Courses")]
        public uint courseId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
