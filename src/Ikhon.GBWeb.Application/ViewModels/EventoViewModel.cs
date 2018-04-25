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
        [Required]
        [Display(Name ="Pessoa")]
        public int COD_PESSOA { get; set; }
        [Required]
        [Display(Name = "Evento")]
        public string TXT_EVENTO { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de início do evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DT_EVENTO_INICIO { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de fim do evento")]
        public DateTime DT_EVENTO_FIM { get; set; }
        [Display(Name = "Local")]
        public string TXT_LOCAL { get; set; }
        [Display(Name = "Ativo")]
        public bool COD_ATIVO { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
    }
}
