using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyGolfScoreApp.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int HoleNumber { get; set; }
        public int Par { get; set; }
        
        public int Length { get; set; }

        public int StrokeIndex { get; set; }
    
    }
}