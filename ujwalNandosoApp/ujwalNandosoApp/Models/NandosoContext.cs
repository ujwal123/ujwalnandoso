//swagger not working
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ujwalNandosoApp.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class NandosoContext : DbContext
    {
        public DbSet<Comments> user_comments { get; set; }


        public class MyConfiguration : DbMigrationsConfiguration<NandosoContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(NandosoContext context)
            {
                List<Comments> comments_to_add = new List<Comments>()
                {
                    new Comments {name = "Sam", comment = "Great job guys keep it up" },
                    new Comments {name = "Harry", comment = "Stale food, too cold, service is not good" },
                    new Comments {name = "Matt", comment = "Do you guys sell kids meals" },
                    new Comments {name = "Jessica", comment = "What are your opening hours for christmas holidays" },
                };

                comments_to_add.ForEach(s => context.user_comments.Add(s));
                context.SaveChanges();

            }
        }

        public NandosoContext() : base("name=NandosoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NandosoContext, MyConfiguration>());
        }

    }
}
