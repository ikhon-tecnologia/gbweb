using Ikhon.GBWeb.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikhon.GBWeb.Application.ViewModels;
using Ikhon.GBWeb.Domain.Interfaces.Repository;
using Ikhon.GBWeb.Domain.Entities;
using Ikhon.GBWeb.Data.Repository;
using AutoMapper;

namespace Ikhon.GBWeb.Application.Service
{
    public class GBWEbAppService : IGBWEbAppService
    {
        private readonly EventoRepository _EventoRepository;

        public GBWEbAppService()
        {
            _EventoRepository = new EventoRepository();

        }

        public EventoViewModel IncluirEvento(EventoViewModel evento)
        {
            return Mapper.Map<EventoViewModel>(_EventoRepository.Adicionar(Mapper.Map<Evento>(evento)));
        }

        public EventoViewModel AlterarEvento(EventoViewModel evento)
        {
            return Mapper.Map<EventoViewModel>(_EventoRepository.Atualizar(Mapper.Map<Evento>(evento)));
        }

        public void ExcluirEvento(int cod_evento)
        {
            _EventoRepository.Remover(cod_evento);
        }

        public ICollection<EventoViewModel> ListarEvento()
        {            
            return Mapper.Map<List<EventoViewModel>>(_EventoRepository.ObterTodos());            
        }

        public void Dispose()
        {
            _EventoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public EventoViewModel CarregarEvento(int cod_evento)
        {
            return Mapper.Map<EventoViewModel>(_EventoRepository.ObterPorId(cod_evento));
        }
    }
}
