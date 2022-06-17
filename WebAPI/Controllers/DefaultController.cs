﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Version()
        {
            return Json("Web API version 1.0");
        }
    }
}
