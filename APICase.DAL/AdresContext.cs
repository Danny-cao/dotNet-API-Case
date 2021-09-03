using APICase.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace APICase.DAL
{
    public class AdresContext : DbContext
    {
        public DbSet<Adres> Adresgegevens { get; set; }
        public AdresContext(DbContextOptions<AdresContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adres>().HasData(
            new Adres() { Id = 1, Straat = "Riojagaard", Huisnummer = "6", PostCode = "3446WD", Plaats = "Woerden", Land = "Nederland" },
            new Adres() { Id = 2, Straat = "Burgemeester van Erpstraat", Huisnummer = "29-A", PostCode = "5351AR", Plaats = "Berghem", Land = "Nederland" }
            );
        }
    }
}
