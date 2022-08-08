using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace InspireEdu.Models
{
    public partial class InspireModel : DbContext
    {
        public InspireModel()
            : base("name=InspireModel")
        {
        }

        public virtual DbSet<Blogtbl> Blogtbls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogtbl>()
                .Property(e => e.BlogTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Blogtbl>()
                .Property(e => e.BlogCat)
                .IsUnicode(false);

            modelBuilder.Entity<Blogtbl>()
                .Property(e => e.BlogDesc)
                .IsUnicode(false);
        }
    }
}
