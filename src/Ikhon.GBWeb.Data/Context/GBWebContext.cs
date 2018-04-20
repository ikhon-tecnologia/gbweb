using Ikhon.GBWeb.Data.EntityConfig;
using Ikhon.GBWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Data.Context
{
    public class GBWebContext : DbContext
    {
        public GBWebContext() : base("DefaultConnection")
        {
            
        }

        DbSet<Pessoa> Pessoa { get; set; }
        DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "cod_" + p.ReflectedType.Name)
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));


            modelBuilder.Configurations.Add(new PessoaConfig());
            modelBuilder.Configurations.Add(new EventoConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}
