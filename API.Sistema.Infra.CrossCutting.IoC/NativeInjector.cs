using API.Sistema.Application;
using API.Sistema.Application.AppService;
using API.Sistema.Domain.Command;
using API.Sistema.Domain.Core.Events;
using API.Sistema.Domain.Core.Interfaces;
using API.Sistema.Domain.Core.Notifications;
using API.Sistema.Domain.Interfaces;
using API.Sistema.Domain.Interfaces.Repositories;
using API.Sistema.Infra.CrossCutting.Bus;
using API.Sistema.Infra.CrossCutting.Data.Configuration;
using API.Sistema.Infra.CrossCutting.Data.Context;
using API.Sistema.Infra.CrossCutting.Data.EventSourcing;
using API.Sistema.Infra.CrossCutting.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Infra.CrossCutting.IoC
{
    public  class NativeInjector
    {

        public static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IEventStore, EventStore>();

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            services.AddScoped<IRequestHandler<UsuarioCreateCommand, Unit>, UsuarioCommadHandler>();
            services.AddScoped<IRequestHandler<UsuarioUpdateCommand, Unit>, UsuarioCommadHandler>();
            services.AddScoped<IRequestHandler<UsuarioDeleteCommand, Unit>, UsuarioCommadHandler>();
            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddDbContext<CadastroContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


        }
    }
}
