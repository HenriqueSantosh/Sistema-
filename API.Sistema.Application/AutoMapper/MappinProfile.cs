using API.Sistema.Application.Dto;
using API.Sistema.Domain.Command;
using API.Sistema.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Application.AutoMapper
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {

            CreateMap<UsuarioCreateDto, UsuarioCreateCommand>();

            CreateMap<UsuarioDto, Usuario>().ReverseMap();

            CreateMap<UsuarioUpdateDto, UsuarioUpdateCommand>();

            CreateMap<EnderecoDto, Endereco>().ReverseMap();
        }
    }
}
