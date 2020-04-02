using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProduct.Models
{
    public class ProduitContext:DbContext
    {

        public ProduitContext(DbContextOptions<ProduitContext> options): base(options)
        {
        }
        public DbSet<Produit> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>(entity =>
            {
                entity.Property(e => e.IdProd)
                .IsRequired();

                entity.Property(e => e.NomProd)
                .IsRequired();


                entity.Property(e => e.QtyProd)
                .IsRequired();


                entity.Property(e => e.PrixProd)
                .IsRequired();

            });
        }
    }
}
