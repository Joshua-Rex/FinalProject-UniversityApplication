﻿using System.ComponentModel.DataAnnotations.Schema;

namespace University_Portal.Models
{
    public class TutorEvents
    {
        public uint id { get; set; }
        [ForeignKey("Tutors")]
        public uint tutorId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
    }
}
