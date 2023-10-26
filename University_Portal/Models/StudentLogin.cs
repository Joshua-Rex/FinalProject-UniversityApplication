using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace University_Portal.Models
{
    public class StudentLogin
    {
        [Required]
        public int id { get; set; }
        [Required]
        [PasswordPropertyText]
        public string password { get; set; }
    }
}
