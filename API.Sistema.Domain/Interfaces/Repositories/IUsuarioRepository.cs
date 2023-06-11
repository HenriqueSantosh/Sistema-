using API.Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetById(Guid id);
        Task<bool> HasCpf(string cpf); 
        Task<Usuario> GetUserEndereco(Guid id);
        Task<IEnumerable<Usuario>> ListUsuarios();
     }
}
