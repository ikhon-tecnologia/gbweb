using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Domain.Entities
{
    public class Pessoa
    {
        public int COD_PESSOA { get; set; }
        public string TXT_NOME { get; set; }
        public string TXT_EMAIL { get; set; }

        public virtual List<Evento> Evento { get; set; }
    }
}
