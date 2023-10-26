using System.ComponentModel.DataAnnotations.Schema;

namespace University_Portal.Models
{
    public class Tutors
    {
        public uint id { get; set; }
        [ForeignKey("Universities")]
        public uint uniId {  get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
    }
}
