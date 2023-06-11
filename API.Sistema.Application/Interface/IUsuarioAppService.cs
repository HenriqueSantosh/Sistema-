using API.Sistema.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Application
{
    public interface IUsuarioAppService
    {
        Task<UsuarioDto> GetById(Guid id);
        Task<UsuarioDto> GetUserEndereco(Guid id);
        Task<IEnumerable<UsuarioDto>> ListUsuarios();
        Task AddAsync(UsuarioCreateDto entity);
        Task UpdateAsync(UsuarioUpdateDto entity);
        Task DeleteAsync(Guid id);
    }
}
