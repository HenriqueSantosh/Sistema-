using System;
using System.ComponentModel.DataAnnotations;

namespace API.Sistema.Site.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o numero do CPF")]
        public string CPF { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o RG")]
        public string RG { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Data Invalida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe uma data")]
        public DateTime DataExpedicao { get; set; }

        [Display(Name = "Data Invalida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe a data")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o orgão que expediu o documento")]
        public string OrGaoExpedicao { get; set; }

        public string UF { get; set; }

        public string Sexo { get; set; }

        public string EstadoCivil { get; set; }

        public Endereco Endereco { get; set; }


    }
}
