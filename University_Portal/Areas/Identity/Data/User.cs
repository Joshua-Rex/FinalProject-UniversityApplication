using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace University_Portal.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    [ForeignKey("Universities")]
    public uint uniId { get; set; }
    public string name { get; set; }
}

