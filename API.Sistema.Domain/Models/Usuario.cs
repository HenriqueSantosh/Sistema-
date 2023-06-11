using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string RG { get; private set; }
        public DateTime DataExpedicao { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string OrGaoExpedicao { get; private set; }
        public string UF { get; private set; }
        public string Sexo { get; private set; }
        public string EstadoCivil { get; private set; }
        public virtual Endereco Endereco { get; private set; }

        public Usuario()
        {

        }

        public Usuario(string cPF, string nome,
                        string rG, DateTime dataExpedicao, DateTime dtNascimento, string orGaoExpedicao,
                        string uF, string sexo, string estadoCivil)
        {
            Id = Guid.NewGuid();
            CPF = cPF;
            Nome = nome;
            RG = rG;
            DataExpedicao = dataExpedicao;
            DataNascimento = dtNascimento;
            OrGaoExpedicao = orGaoExpedicao;
            UF = uF;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }

        public void Update(string cPF, string nome,
                        string rG, DateTime dataExpedicao, DateTime dtNasc, string orGaoExpedicao,
                        string uF, string sexo, string estadoCivil)
        {
            CPF = cPF;
            Nome = nome;
            RG = rG;
            DataExpedicao = dataExpedicao;
            DataNascimento = dtNasc;
            OrGaoExpedicao = orGaoExpedicao;
            UF = uF;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }

        public void SetEndreco(Endereco endereco, Guid id)
        {
            endereco.SetIdEndereco(id);
            Endereco = endereco;
        }

    }
}
