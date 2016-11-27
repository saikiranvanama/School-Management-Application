namespace LabAssignment4
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LabAssignment_4 : DbContext
    {
        public LabAssignment_4()
            : base("name=LabAssignment_4")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Titles)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("AuthorISBN").MapLeftKey("AuthorID").MapRightKey("ISBN"));

            modelBuilder.Entity<Title>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Title1)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Copyright)
                .IsUnicode(false);
        }
    }
}
