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
    class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<EventoViewModel, Evento>();
            CreateMap<PessoaViewModel, Pessoa>();
        }
    }
}
