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
    public class PessoaController : ApiController
    {
        private readonly IGBWEbAppService _GBWebAppService;
        public PessoaController()
        {
            _GBWebAppService = new GBWEbAppService();
        }

        // GET: api/Pessoa
        public ICollection<PessoaViewModel> GetPessoaViewModels()
        {
            return _GBWebAppService.ListarPessoa();
        }

        // GET: api/Pessoa/5
        [ResponseType(typeof(PessoaViewModel))]
        public IHttpActionResult GetPessoaViewModel(int id)
        {
            PessoaViewModel pessoaViewModel = _GBWebAppService.CarregarPessoa((int)id);
            if (pessoaViewModel == null)
            {
                return NotFound();
            }

            return Ok(pessoaViewModel);
        }

        // PUT: api/Pessoa/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPessoaViewModel(int id, PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoaViewModel.COD_PESSOA)
            {
                return BadRequest();
            }

            try
            {
                _GBWebAppService.AlterarPessoa(pessoaViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaViewModelExists(id))
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

        // POST: api/Pessoa
        [ResponseType(typeof(PessoaViewModel))]
        public IHttpActionResult PostPessoaViewModel(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _GBWebAppService.IncluirPessoa(pessoaViewModel);

            return CreatedAtRoute("DefaultApi", new { id = pessoaViewModel.COD_PESSOA }, pessoaViewModel);
        }

        // DELETE: api/Pessoa/5
        [ResponseType(typeof(PessoaViewModel))]
        public IHttpActionResult DeletePessoaViewModel(int id)
        {
            PessoaViewModel pessoaViewModel = _GBWebAppService.CarregarPessoa(id);
            if (pessoaViewModel == null)
            {
                return NotFound();
            }

            _GBWebAppService.ExcluirPessoa(id);

            return Ok(pessoaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _GBWebAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaViewModelExists(int id)
        {
            //return db.PessoaViewModels.Count(e => e.COD_PESSOA == id) > 0;
            return false;
        }
    }
}