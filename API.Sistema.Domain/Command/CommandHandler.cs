using API.Sistema.Domain.Core.Events;
using API.Sistema.Domain.Core.Interfaces;
using API.Sistema.Domain.Core.Notifications;
using API.Sistema.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Domain.Command
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notificationHandler;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notificationHandler)
        {
            _uow = uow;
            _bus = bus;
            _notificationHandler = (DomainNotificationHandler)notificationHandler;
        }

        protected void NotifyValidationErrors(Core.Commands.Command msg)
        {
            foreach(var error in msg.ValidationResult.Errors)
                 _bus.RaiseEvent(new DomainNotification(msg.MessageType, error.ErrorMessage));
        }

        public async Task<bool> Commit(bool ignoreNotification = false)
        {
            if(!ignoreNotification && _notificationHandler.HasNotification()) return false;
            if (await _uow.Commit()) return true;

            await _bus.RaiseEvent(new DomainNotification("Commit", "Erro ao salvar no banco"));

            return false;
        }
    }
}
