﻿using Ikhon.GBWeb.Application.Interfaces;
using Ikhon.GBWeb.Application.Service;
using Ikhon.GBWeb.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ikhon.GBWeb.API.Controllers
{    
    public class ValuesController : ApiController
    {
        private readonly IGBWEbAppService _GBWebAppService;

        public ValuesController()
        {
            _GBWebAppService = new GBWEbAppService();
        }
        // GET api/values
        public IEnumerable<EventoViewModel> Get()
        {
            return _GBWebAppService.ListarEvento();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
