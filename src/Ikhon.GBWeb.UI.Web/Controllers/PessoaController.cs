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
    public class PessoaController : Controller
    {
        private readonly IGBWEbAppService _GBWebAppService;

        public PessoaController()
        {
            _GBWebAppService = new GBWEbAppService();
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            return View(_GBWebAppService.ListarPessoa());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModel pessoaViewModel = _GBWebAppService.CarregarPessoa((int)id);
            if (pessoaViewModel == null)    
            {
                return HttpNotFound();
            }
            return View(pessoaViewModel);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                _GBWebAppService.IncluirPessoa(pessoaViewModel);
                return RedirectToAction("Index");
            }

            return View(pessoaViewModel);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModel pessoaViewModel = _GBWebAppService.CarregarPessoa((int)id);
            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModel);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                _GBWebAppService.AlterarPessoa(pessoaViewModel);
                return RedirectToAction("Index");
            }
            return View(pessoaViewModel);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModel pessoaViewModel = _GBWebAppService.CarregarPessoa((int)id);
            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModel);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _GBWebAppService.ExcluirPessoa(id);
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
