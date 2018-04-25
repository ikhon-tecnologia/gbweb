using Ikhon.GBWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Data.EntityConfig
{
    public class EventoConfig : EntityTypeConfiguration<Evento>
    {
        public EventoConfig()
        {
            HasKey(p => p.COD_EVENTO);

            Property(p => p.TXT_EVENTO)
                .HasMaxLength(255);

            Property(p => p.TXT_LOCAL)
                .HasMaxLength(255);

            ToTable("TBL_EVENTO");
        }
    }
}
