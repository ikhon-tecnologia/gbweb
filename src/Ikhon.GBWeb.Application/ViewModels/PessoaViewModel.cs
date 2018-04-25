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
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome")]
        public string TXT_NOME { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string TXT_EMAIL { get; set; }
        [Display(Name = "Telefone")]
        //[RegularExpression(@"^(?:\((?:\+|00)([0-9]{3})\)|(?:\+|00)([0-9]{3}))? ([0-9]{2})[- ]?([0-9]{7})$", ErrorMessage = "Telefone deve estar no formato correto.")]
        //^(\+[1-9][0-9]*(\([0-9]*\)|-[0-9]*-))?[0]?[1-9][0-9\- ]*$
        // @"^\d{4}[-]{1}\d{4}$"
        public string TXT_TELEFONE { get; set; }
        [Display(Name = "Localização")]
        public string TXT_LOCALIZACAO { get; set; }
        [Display(Name = "Orador")]
        public bool COD_ORADOR { get; set; }
        [Display(Name = "Ativo")]
        public bool COD_ATIVO { get; set; }
    }
}
