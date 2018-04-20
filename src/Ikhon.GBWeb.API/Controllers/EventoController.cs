using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ikhon.GBWeb.API.Models;
using Ikhon.GBWeb.Application.ViewModels;
using Ikhon.GBWeb.Application.Interfaces;
using Ikhon.GBWeb.Application.Service;

namespace Ikhon.GBWeb.API.Controllers
{
    public class EventoController : ApiController
    {
        private readonly IGBWEbAppService _GBWebAppService;
        public EventoController()
        {
            _GBWebAppService = new GBWEbAppService();
        }

        // GET: api/Evento
        public ICollection<EventoViewModel> GetEventoViewModels()
        {
            return _GBWebAppService.ListarEvento();
        }

        // GET: api/Evento/5
        [ResponseType(typeof(EventoViewModel))]
        public IHttpActionResult GetEventoViewModel(int id)
        {
            EventoViewModel eventoViewModel = _GBWebAppService.CarregarEvento((int)id);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return Ok(eventoViewModel);
        }

        // PUT: api/Evento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventoViewModel(int id, EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventoViewModel.COD_EVENTO)
            {
                return BadRequest();
            }
                      
            try
            {
                _GBWebAppService.AlterarEvento(eventoViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Evento
        [ResponseType(typeof(EventoViewModel))]
        public IHttpActionResult PostEventoViewModel(EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _GBWebAppService.IncluirEvento(eventoViewModel);                

            return CreatedAtRoute("DefaultApi", new { id = eventoViewModel.COD_EVENTO }, eventoViewModel);
        }

        // DELETE: api/Evento/5
        [ResponseType(typeof(EventoViewModel))]
        public IHttpActionResult DeleteEventoViewModel(int id)
        {
            EventoViewModel eventoViewModel = _GBWebAppService.CarregarEvento(id);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            _GBWebAppService.ExcluirEvento(id);

            return Ok(eventoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _GBWebAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoViewModelExists(int id)
        {
            //return db.EventoViewModels.Count(e => e.COD_EVENTO == id) > 0;
            return false;
        }
    }
}