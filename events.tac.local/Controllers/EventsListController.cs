using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class EventsListController : Controller
    {
        private readonly EventsProvider _eventsProvider;

        public EventsListController() : this(new EventsProvider()) { }

        public EventsListController(EventsProvider eventsProvider)
        {
            _eventsProvider = eventsProvider;
        }
        // GET: EventsList
        public ActionResult Index(int page = 1)
        {
            return View(_eventsProvider.GetEventsList(page));
        }
    }
}