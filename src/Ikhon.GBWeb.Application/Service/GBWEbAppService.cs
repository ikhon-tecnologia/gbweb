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
        private readonly PessoaRepository _PessoaRepository;

        public GBWEbAppService()
        {
            _EventoRepository = new EventoRepository();
            _PessoaRepository = new PessoaRepository();

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

        public EventoViewModel CarregarEvento(int cod_evento)
        {
            return Mapper.Map<EventoViewModel>(_EventoRepository.ObterPorId(cod_evento));
        }

        public PessoaViewModel IncluirPessoa(PessoaViewModel pessoa)
        {
            return Mapper.Map<PessoaViewModel>(_PessoaRepository.Adicionar(Mapper.Map<Pessoa>(pessoa)));
        }

        public PessoaViewModel AlterarPessoa(PessoaViewModel pessoa)
        {
            return Mapper.Map<PessoaViewModel>(_PessoaRepository.Atualizar(Mapper.Map<Pessoa>(pessoa)));
        }

        public void ExcluirPessoa(int cod_pessoa)
        {
            _PessoaRepository.Remover(cod_pessoa);
        }

        public ICollection<PessoaViewModel> ListarPessoa()
        {
            return Mapper.Map<List<PessoaViewModel>>(_PessoaRepository.ObterTodos());
        }

        public PessoaViewModel CarregarPessoa(int cod_pessoa)
        {
            return Mapper.Map<PessoaViewModel>(_PessoaRepository.ObterPorId(cod_pessoa));
        }

        public void Dispose()
        {
            _EventoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
