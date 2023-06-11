using API.Sistema.Domain.Core.Interfaces;
using API.Sistema.Domain.Core.Notifications;
using API.Sistema.Domain.Interfaces;
using API.Sistema.Domain.Interfaces.Repositories;
using API.Sistema.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Sistema.Domain.Command
{
    public class UsuarioCommadHandler : CommandHandler, IRequestHandler<UsuarioCreateCommand>, IRequestHandler<UsuarioUpdateCommand>, IRequestHandler<UsuarioDeleteCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IUsuarioRepository _repository;

        public UsuarioCommadHandler(IMediatorHandler bus, IUsuarioRepository repository, 
                   IUnitOfWork uow, INotificationHandler<DomainNotification> notification): base(uow, bus, notification)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task<Unit> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var validaCpfNaBase = await _repository.HasCpf(request.CPF);
            if (validaCpfNaBase)
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "CPF Ja cadastrado na Base"));
            else
            {
                var user = new Usuario(request.CPF, request.Nome, request.RG, request.DataExpedicao,
                             request.DataNascimento, request.OrGaoExpedicao, request.Uf,request.Sexo, request.EstadoCivil);

                var enderecoModel = request.Endereco;
                var endereco = new Endereco(enderecoModel.Cep, enderecoModel.Logradouro,
                    enderecoModel.Numero, enderecoModel.Complemento, enderecoModel.Bairro,
                     enderecoModel.Cidade, enderecoModel.UF);

                user.SetEndreco(endereco, user.Id);

                await _repository.AddAsync(user);
                await Commit();

            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(UsuarioUpdateCommand request, CancellationToken cancellationToken)
        {
            var userEnttity = await _repository.GetUserEndereco(request.Id);
            if (userEnttity == null)
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Usuario não localizado"));
            }
            else
            {
                var endereco = request.Endereco;

                userEnttity.Update(request.CPF, request.Nome, request.RG, request.DataExpedicao,
                   request.DataNascimento, request.OrGaoExpedicao, request.UF, request.Sexo, request.EstadoCivil);

                userEnttity.Endereco.UpdateEndereco(endereco.Cep,
                    endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Bairro,
                    endereco.Cidade, endereco.UF);

                _repository.UpdateAsync(userEnttity);
                await Commit(true);
            }

            return Unit.Value;
            
        }

        public async Task<Unit> Handle(UsuarioDeleteCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.GetById(request.Id);
            if(usuario == null)
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Usuario não localizado"));
            }
            else
            {
                _repository.DeleteAsync(usuario);
                await Commit(true);
            }

            return Unit.Value;
        }
    }
}
