using API.Sistema.Domain.Core.Interfaces;
using API.Sistema.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Sistema.Web
{
    public class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly IMediatorHandler _mediatorHandler;

        public ApiController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler mediatorHandler)
        {
            _notificationHandler = (DomainNotificationHandler)notificationHandler;
            _mediatorHandler = mediatorHandler;
        }

        protected IEnumerable<DomainNotification> Notifications => _notificationHandler.GetNotifications();

        protected bool IsValidOperations()
        {
            return (!_notificationHandler.HasNotification());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperations())
            {
                return Ok(new {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificationHandler.GetNotifications().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(c => c.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediatorHandler.RaiseEvent(new DomainNotification(code, message));
        }

        protected IActionResult HandleException(Exception ex)
        {
            string actionName = this.ControllerContext.ActionDescriptor.ActionName;
            string controllerName = this.ControllerContext.ActionDescriptor?.ControllerName;

            ex.Message.Split(';').ToList().ForEach(e =>
            {
                Log.Error(ex, "v1/{controllername:l}/{actionName:l} - {message:l}",
                    controllerName, actionName, ex.Message, ex.TargetSite, ex.StackTrace);
                NotifyError("500", actionName);
            });

            return Error();
            
        }

        private IActionResult Error()
        {
            return BadRequest(new
            {
                success = true,
                errors = _notificationHandler.GetNotifications().Select(n => n.Value)
            }) ;
        }
    }
}
