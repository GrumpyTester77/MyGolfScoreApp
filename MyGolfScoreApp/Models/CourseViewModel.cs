using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGolfScoreApp.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        //[ForeignKey("Hole")]
        //public int HoleId { get; set; }
        //public virtual HoleViewModel Hole { get; set; }


    }
}