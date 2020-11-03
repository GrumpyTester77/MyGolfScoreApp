using MyGolfScoreApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyGolfScoreApp.Data
{
    public class MyGolfScoreAppDb : DbContext

    {

        public DbSet<RoundViewModel> Round { get; set; }

        public DbSet<CourseViewModel> Course { get; set; }

        public System.Data.Entity.DbSet<MyGolfScoreApp.Models.HoleViewModel> HoleViewModels { get; set; }
        public IEnumerable CourseViewModels { get; internal set; }
    }
}