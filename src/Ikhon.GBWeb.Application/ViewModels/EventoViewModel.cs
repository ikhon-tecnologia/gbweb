using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Application.ViewModels
{
    public class EventoViewModel
    {
        [Key]
        public int COD_EVENTO { get; set; }
        [Display(Name ="Pessoa")]
        public int COD_PESSOA { get; set; }
        [Display(Name = "Evento")]
        public string TXT_EVENTO { get; set; }
        [Display(Name = "Evento Inicio")]
        public DateTime DT_EVENTO_INICIO { get; set; }
        [Display(Name = "Evento Fim")]
        public DateTime DT_EVENTO_FIM { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
    }
}
