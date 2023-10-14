using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Viamatica.Shared;

namespace Viamatica.Data
{
    public class ViamaticaDbContext : IdentityDbContext
    {

        public ViamaticaDbContext()
        {
            
        }
        public ViamaticaDbContext(DbContextOptions<ViamaticaDbContext> options): base(options)
        {

        }       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ANDRES; Database=viamaticadb; User Id=sa; Password=sa2021; Trusted_Connection=True; Encrypt=false");
        }

        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Asegurado> Asegurados { get; set; }

        public DbSet<AseguradoSeguro> AseguradosSeguros { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AseguradoSeguro>().Property(p => p.Id).UseIdentityColumn().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
            builder.Entity<AseguradoSeguro>().HasKey(x => new { x.IdAsegurado, x.IdSeguro });
            builder.Entity<IdentityUserLogin<string>>().HasNoKey();
            builder.Entity<IdentityUserRole<string>>().HasNoKey();
            builder.Entity<IdentityUserToken<string>>().HasNoKey();
            base.OnModelCreating(builder);
        }
    }
}
