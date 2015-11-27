using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ujwalNandosoApp.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ujwalNandosoAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public class MyConfiguration : DbMigrationsConfiguration<ujwalNandosoAppContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(ujwalNandosoAppContext context)
            {
                List<Comments> comments_to_add = new List<Comments>()
                {
                    new Comments {name = "Sam", comment = "Great job guys keep it up" },
                    new Comments {name = "Harry", comment = "Stale food, too cold, service is not good" },
                    new Comments {name = "Matt", comment = "Do you guys sell kids meals" },
                    new Comments {name = "Jessica", comment = "What are your opening hours for christmas holidays" },
                };

                comments_to_add.ForEach(s => context.Comments.Add(s));
                context.SaveChanges();

            }
        }


        public ujwalNandosoAppContext() : base("name=ujwalNandosoAppContext")
        {
        }



        public System.Data.Entity.DbSet<ujwalNandosoApp.Models.Comments> Comments { get; set; }
    }
}
