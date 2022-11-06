using Microsoft.EntityFrameworkCore;
using MECEList.Entities.Models;

namespace MECEList.DatabaseContext
{
    public class MECEListContext : DbContext
    {
        public DbSet<Root> Roots { get; set; }

        public DbSet<List> Lists { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Celebrity> Celebrities { get; set; }

        public DbSet<Anniversary> Anniversaries { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Datearrrib> Datearrribs { get; set; }

        public DbSet<DeadlineKind> DeadlineKinds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Attrib> Attribs { get; set; }

        public DbSet<DataChange> DataChanges { get; set; }

        public DbSet<Entities.Models.Image> Images { get; set; }

        private const string DatabaseName = "MECEListV2.db3";

        public MECEListContext()
        {
            SQLitePCL.Batteries_V2.Init();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabaseName}");
        }
    }
}
