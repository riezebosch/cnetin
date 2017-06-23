using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JetBrains.Annotations;
using System.Linq;

namespace XUnitTestProject1
{
    public class EntityFrameworkDemo
    {
        [Fact]
        public void OpslaanInEenDatabase()
        {
            var options = new DbContextOptionsBuilder<SupermarktContext>()
                .UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=supermarkt; Integrated Security=SSPI")
                .Options;

            using (var context = new SupermarktContext(options))
            {
                context.Database.EnsureCreated();

                context.Afdelingen.Add(new Vleeswaren
                {
                    Producten = new List<Product>
                    {
                        new VleesProduct {
                            PrijsPerKilo = 23m,
                            Naam = "Biefstuk"
                        }
                    }
                });
                context.SaveChanges();
            }

            using (var context = new SupermarktContext(options))
            {
                var vw = context
                    .Afdelingen
                    .Include(a => a.Producten)
                    .OfType<Vleeswaren>()
                    .First();

                var gemiddelde = vw
                    .Producten
                    .OfType<VleesProduct>()
                    .Average(p => p.PrijsPerKilo);

                Assert.Equal(23m, gemiddelde);
            }
        }
    }

    public class VleesProduct : Product
    {
        public decimal PrijsPerKilo { get; internal set; }
        public string Naam { get; internal set; }
    }

    public class Product
    {
        public int Id { get; set; }
    }

    public class SupermarktContext : DbContext
    {
        public SupermarktContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Afdeling> Afdelingen { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vleeswaren>().HasBaseType<Afdeling>();
            builder.Entity<VleesProduct>().HasBaseType<Product>();
        }
    }

    public class Afdeling
    {
        public int Id { get; set; }
        public IList<Product> Producten { get; set; }
    }

    public class Vleeswaren : Afdeling
    {
        
    }
}
