using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinaf.WebApi.Api.DTOs
{
    public class PessoaDTO
    {
        public int cdpes { get; set; }

        [Required(ErrorMessage = "Tipo pessoa é obrigatório")]
        public int tppes { get; set; }

        [Required(ErrorMessage = "CPF/CGC é obrigatório")]
        public string nrcgccpf { get; set; }

        [Required(ErrorMessage ="Nome é obrigatório")]
        [StringLength(maximumLength:40, MinimumLength = 2, ErrorMessage = "Tamanho do campo nome tem que ser entre 2 e 40 caracteres.")]
        public string nmpes { get; set; }
        //public DateTime dtcad { get; set; }
        [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
        [Display(Name = "Data de nascimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime dtnas { get; set; }

        [Required(ErrorMessage = "CPF/CGC é obrigatório")]
        public int tpsex { get; set; }


    }
}