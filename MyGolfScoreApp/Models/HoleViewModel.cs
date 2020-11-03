using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGolfScoreApp.Models
{
    public class HoleViewModel
    {
        [Key]
        public int HoleId { get; set; }

        public int HoleNumber { get; set; }

        public int Par { get; set; }

        public int Length { get; set; }

        public int StrokeIndex { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public IEnumerable<SelectListItem> CourseNamesDropdownList { get; set; }

        public virtual CourseViewModel Course { get; set; }
    }
}