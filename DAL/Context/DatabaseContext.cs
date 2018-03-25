using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using Models;

namespace DAL
{

    /// <summary>
    /// Database context
    /// </summary>
    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="connectionString">Database сonnection string</param>
        public DatabaseContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Genre> Genges { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }
    }

    /// <summary>
    /// Database initialization
    /// </summary>
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        /// <summary>
        /// Database initialization data
        /// </summary>
        /// <param name="db">DB context</param>
        protected override void Seed(DatabaseContext db)
        {
            db.PlatformTypes.Add(new PlatformType() { Type = "browser" });
            db.PlatformTypes.Add(new PlatformType() { Type = "mobile" });
            db.PlatformTypes.Add(new PlatformType() { Type = "desktop" });
            db.PlatformTypes.Add(new PlatformType() { Type = "console" });

            List<Genre> genres = new List<Genre>()
            {
                new Genre(){Name = "Strategy",Childs = new List<Genre>()
                {
                    new Genre(){Name = "RTS"},
                    new Genre(){Name = "TBS"},
                }},
                new Genre(){Name = "RPG"},
                new Genre(){Name = "Sport"},
                new Genre(){Name = "Races",Childs = new List<Genre>()
                {
                    new Genre(){Name = "rally"},
                    new Genre(){Name = "arcade"},
                    new Genre(){Name = "formula"},
                    new Genre(){Name = "off-road"},
                }},
                new Genre(){Name = "Action", Childs = new List<Genre>()
                {
                    new Genre(){Name = "FPS"},
                    new Genre(){Name="TPS"},
                    new Genre(){Name = "Misc"}
                }},
                new Genre(){Name = "Adventure"},
                new Genre(){Name = "Puzzle&Skill"},
                new Genre(){Name = "Misc"},
            };

            db.Genges.AddRange(genres);
        }
    }
}