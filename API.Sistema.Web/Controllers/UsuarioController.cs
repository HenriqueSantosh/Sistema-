using API.Sistema.Application;
using API.Sistema.Application.Dto;
using API.Sistema.Domain.Core.Interfaces;
using API.Sistema.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Sistema.Web.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService, 
                                 INotificationHandler<DomainNotification> notification,
                                 IMediatorHandler mediatorHandler) : base(notification, mediatorHandler)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UsuarioCreateDto usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(ModelState);
                }

                await _usuarioAppService.AddAsync(usuarioDto);
                return Response();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UsuarioUpdateDto usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(ModelState);
                }

                await _usuarioAppService.UpdateAsync(usuarioDto);
                return Response();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        [HttpGet]
        [Route("GetListUsers")]
        public async Task<IActionResult> GetListUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(ModelState);
                }

               var list = await _usuarioAppService.ListUsuarios();
                return Response(list);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(ModelState);
                }

                await _usuarioAppService.DeleteAsync(id);
                return Response();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(ModelState);
                }

                var user = await _usuarioAppService.GetUserEndereco(id);
                return Response(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}
