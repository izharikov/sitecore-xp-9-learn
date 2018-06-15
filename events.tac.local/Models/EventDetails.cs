using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class EventDetails : SearchResultItem
    {
        public string ContentHeading { get; set; }
        public string ContentIntro { get; set; }
        public DateTime StartDate { get; set; }
        public HtmlString EventImage => new HtmlString(FieldRenderer.Render(GetItem(), "EventImage", "DisableWebEditing=true&mw=150"));        public string Url
        {
            get
            {
                if (_url == null)
                {
                    _url = LinkManager.GetItemUrl(GetItem());
                }
                return _url;
            }
        }

        private string _url = null;
    }
}