using AutoMapper;
using Ikhon.GBWeb.Application.ViewModels;
using Ikhon.GBWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Application.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Pessoa, PessoaViewModel>();
        }
    }
}
