using Ikhon.GBWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Data.EntityConfig
{
    public class PessoaConfig : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfig()
        {
            HasKey(p => p.COD_PESSOA);

            Property(p => p.TXT_EMAIL)
                .HasMaxLength(150);

            Property(p => p.TXT_NOME)
                .HasMaxLength(255);

            Property(p => p.TXT_TELEFONE)
                .HasMaxLength(30);

            Property(p => p.TXT_LOCALIZACAO)
                .HasMaxLength(255);

            ToTable("TBL_PESSOA");
        }
    }
}
