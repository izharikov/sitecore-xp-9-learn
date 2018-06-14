﻿using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class BreadcrumbController : Controller
    {
        private readonly BreadcrumbBuilder _builder;

        public BreadcrumbController() : this(new BreadcrumbBuilder()) { }

        public BreadcrumbController(BreadcrumbBuilder builder)
        {
            _builder = builder;
        }

        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(_builder.Build());
        }
    }
}