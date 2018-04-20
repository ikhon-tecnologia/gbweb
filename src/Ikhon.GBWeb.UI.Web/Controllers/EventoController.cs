using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ikhon.GBWeb.Application.ViewModels;
using Ikhon.GBWeb.UI.Web.Models;
using Ikhon.GBWeb.Application.Interfaces;
using Ikhon.GBWeb.Application.Service;

namespace Ikhon.GBWeb.UI.Web.Controllers
{
    public class EventoController : Controller
    {        
        private readonly IGBWEbAppService _GBWebAppService;

        public EventoController()
        {
            _GBWebAppService = new GBWEbAppService();
        }

        // GET: Evento
        public ActionResult Index()
        {            
            return View(_GBWebAppService.ListarEvento());
        }

        // GET: Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoViewModel eventoViewModel = _GBWebAppService.CarregarEvento((int)id);
            if (eventoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(eventoViewModel);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            //ViewBag.COD_PESSOA = new SelectList(db.PessoaViewModels, "COD_PESSOA", "TXT_NOME");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoViewModel eventoViewModel)
        {
            if (ModelState.IsValid)
            {
                _GBWebAppService.IncluirEvento(eventoViewModel);                
                return RedirectToAction("Index");
            }

            //ViewBag.COD_PESSOA = new SelectList(db.PessoaViewModels, "COD_PESSOA", "TXT_NOME", eventoViewModel.COD_PESSOA);
            return View(eventoViewModel);
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoViewModel eventoViewModel = _GBWebAppService.CarregarEvento((int)id);
            if (eventoViewModel == null)
            {
                return HttpNotFound();
            }
            
            return View(eventoViewModel);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventoViewModel eventoViewModel)
        {
            if (ModelState.IsValid)
            {
                _GBWebAppService.AlterarEvento(eventoViewModel);
                return RedirectToAction("Index");
            }            
            return View(eventoViewModel);
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoViewModel eventoViewModel = _GBWebAppService.CarregarEvento((int)id);
            if (eventoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(eventoViewModel);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _GBWebAppService.ExcluirEvento(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _GBWebAppService.Dispose();
                GC.SuppressFinalize(this);
            }
            base.Dispose(disposing);
        }
    }
}
