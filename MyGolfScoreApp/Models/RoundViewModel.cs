using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGolfScoreApp.Models
{
    public class RoundViewModel
    {
        [Key]
        public int RoundId { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public virtual CourseViewModel Course { get; set; }

        public int HoleScore { get; set; }
    }
}