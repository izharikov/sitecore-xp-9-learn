using events.tac.local.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Business
{
    public class EventsProvider
    {
        private const int PageSize = 4;

        public EventsList GetEventsList(int pageNo)
        {
            var index = ContentSearchManager.GetIndex(IndexName);
            var currentContextItem = RenderingContext.Current.ContextItem;
            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<EventDetails>()
                    .Where(i => i.Paths.Contains(currentContextItem.ID))
                    .Where(i => i.Language == currentContextItem.Language.Name)
                    .Page(pageNo - 1, PageSize)
                    .GetResults();
                return new EventsList()
                {
                    Events = results.Hits.Select(h => h.Document).ToArray(),
                    TotalResultCount = results.TotalSearchResults,
                    PageSize = PageSize
                };
            }
        }

        private static string IndexName => $"events_{Sitecore.Context.Database.Name}_index";
    }
}