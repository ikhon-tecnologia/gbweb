using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Application.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public int COD_PESSOA { get; set; }
        [Display(Name = "Nome Pessoa")]
        public string TXT_NOME { get; set; }
        public string TXT_EMAIL { get; set; }
        
    }
}
