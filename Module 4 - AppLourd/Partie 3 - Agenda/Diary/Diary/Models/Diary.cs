namespace Diary.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Diary : DbContext
    {
        public Diary()
            : base("name=Diary")
        {
        }

        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<broker> brokers { get; set; }
        public virtual DbSet<customer> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<appointment>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<broker>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<broker>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);
        }
    }
}
