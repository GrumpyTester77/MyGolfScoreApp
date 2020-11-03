using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyGolfScoreApp.Data
{
    public class MyGolfScoreAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyGolfScoreAppContext() : base("name=MyGolfScoreAppContext")
        {
        }

        public System.Data.Entity.DbSet<MyGolfScoreApp.Models.CourseViewModel> CourseViewModels { get; set; }

        public System.Data.Entity.DbSet<MyGolfScoreApp.Models.HoleViewModel> HoleViewModels { get; set; }
    }
}
