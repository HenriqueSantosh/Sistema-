using API.Sistema.Domain.Interfaces.Repositories;
using API.Sistema.Domain.Models;
using API.Sistema.Infra.CrossCutting.Data.Configuration;
using API.Sistema.Infra.CrossCutting.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Infra.CrossCutting.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly CadastroContext _cadastroContext;

        public UsuarioRepository(CadastroContext cadastroContext): base(cadastroContext) 
        {
            _cadastroContext = cadastroContext;
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Usuario> GetUserEndereco(Guid id)
        {
            return await DbSet.Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> HasCpf(string cpf)
        {
            return await DbSet.AnyAsync(c => c.CPF.Equals(cpf));
        }

        public async Task<IEnumerable<Usuario>> ListUsuarios()
        {
            return await DbSet.ToListAsync();
        }
    }
}
