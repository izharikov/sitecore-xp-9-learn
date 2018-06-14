using events.tac.local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class BreadcrumbBuilder
    {
        private readonly IRenderingContext _context;

        public BreadcrumbBuilder() : this(SitecoreRenderingContext.Create()) { }

        public BreadcrumbBuilder(IRenderingContext context)
        {
            _context = context;
        }

        public IEnumerable<NavigationItem> Build()
        {
            if (_context?.HomeItem == null || _context?.ContextItem == null)
            {
                return Enumerable.Empty<NavigationItem>();
            }
            var homeItem = _context.HomeItem;
            var item = _context.ContextItem;
            return item
                .GetAncestors()
                .Where(i => homeItem.IsAncestorOrSelf(i))
                .Select(i => new NavigationItem(i.DisplayName, i.Url, false))
                .Concat(new []{ new NavigationItem(item.DisplayName, item.Url, true) });
        }

    }
}