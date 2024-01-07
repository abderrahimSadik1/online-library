using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblio
{
    public class BiblioDbContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your connection string here
            optionsBuilder.UseSqlServer("Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Subscriber)
                .WithMany()
                .HasForeignKey(r => r.SubscriberID);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Documents) // A reservation can have many documents
                .WithOne(d => d.Reservation); // Each document can have only one reservation
        }
    }
}

