using System;
using System.ComponentModel.DataAnnotations;

namespace API.Sistema.Site.Models
{
    public class Endereco
    {

        [Required(ErrorMessage = "Informe o CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o nome da rua")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o numero")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe oo Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage ="Informe o UF")]
        public string UF { get; set; }
    }
}
