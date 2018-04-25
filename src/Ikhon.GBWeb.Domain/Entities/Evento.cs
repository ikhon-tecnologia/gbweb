using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Domain.Entities
{
    public class Evento
    {
        public int COD_EVENTO { get; set; }
        public int COD_PESSOA { get; set; }
        public string TXT_EVENTO { get; set; }
        public DateTime DT_EVENTO_INICIO { get; set; }
        public DateTime DT_EVENTO_FIM { get; set; }
        public string TXT_LOCAL { get; set; }
        public bool COD_ATIVO { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
