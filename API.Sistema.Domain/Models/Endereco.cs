using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Domain.Models
{
    public class Endereco
    {
        public Guid Id { get; private set; }
        public Guid IdUsuario { get; set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        public Endereco()
        {

        }

        public Endereco(string cep, string logradouro, string numero,
            string complemento, string bairro, string cidade, string uF)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }

        public void UpdateEndereco(string cep, string logradouro, string numero,
            string complemento, string bairro, string cidade, string uF)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }

        public void SetIdEndereco(Guid id)
        {
            Id = Guid.NewGuid();
            IdUsuario = id;
        }

    }
}
