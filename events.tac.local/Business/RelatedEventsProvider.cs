using events.tac.local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;
using TAC.Sitecore.Abstractions.Testing;

namespace events.tac.local.Business
{
    public class RelatedEventsProvider
    {
        private readonly IRenderingContext _context;

        public RelatedEventsProvider() : this(SitecoreRenderingContext.Create()) { }

        public RelatedEventsProvider(IRenderingContext testRenderingContext)
        {
            _context = testRenderingContext;
        }

        public IEnumerable<NavigationItem> GetRelatedEvents()
        {
            return _context?
                .ContextItem?
                .GetMultilistFieldItems("RelatedEvents")
                .Select(item => new NavigationItem(item.DisplayName, item.Url, false)) ?? Enumerable.Empty<NavigationItem>();
        }
    }
}