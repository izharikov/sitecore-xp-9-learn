using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        private readonly RelatedEventsProvider _relatedEventsProvider;

        public RelatedEventsController(RelatedEventsProvider provider)
        {
            _relatedEventsProvider = provider;
        }

        public RelatedEventsController() : this(new RelatedEventsProvider()) { }

        // GET: RelatedEvents
        public ActionResult Index()
        {
            return View(_relatedEventsProvider.GetRelatedEvents());
        }
    }
}