using API.Sistema.Application.Dto;
using API.Sistema.Domain.Command;
using API.Sistema.Domain.Core.Interfaces;
using API.Sistema.Domain.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Application.AppService
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IUsuarioRepository _repository;

        public UsuarioAppService(IMapper mapper, IMediatorHandler bus, IUsuarioRepository repository)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
        }

        public async Task AddAsync(UsuarioCreateDto entity)
        {
            var command = _mapper.Map<UsuarioCreateCommand>(entity);
            await _bus.SendCommand(command);
        }

        public async Task DeleteAsync(Guid id)
        {
            var commad = new UsuarioDeleteCommand(id);
            await _bus.SendCommand(commad);
        }

        public async Task<UsuarioDto> GetById(Guid id)
        {
            var user = await _repository.GetById(id);
            return _mapper.Map<UsuarioDto>(user);
        }

        public async Task<UsuarioDto> GetUserEndereco(Guid id)
        {
            var user = await _repository.GetUserEndereco(id);
            return _mapper.Map<UsuarioDto>(user);
        }

        public async Task<IEnumerable<UsuarioDto>> ListUsuarios()
        {
            var listUsers = await _repository.ListUsuarios();
            return _mapper.ProjectTo<UsuarioDto>(listUsers.AsQueryable());
        }

        public async Task UpdateAsync(UsuarioUpdateDto entity)
        {
            var command = _mapper.Map<UsuarioUpdateCommand>(entity);
            await _bus.SendCommand(command);
        }
    }
}
