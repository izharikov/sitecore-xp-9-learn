using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class NavigationMenuItem : NavigationItem
    {
        public NavigationMenuItem(string title, string url, IEnumerable<NavigationMenuItem> children = null)
            : base(title, url, false)
        {
            Children = children;// ?? new List<NavigationMenuItem>();
        }

        public IEnumerable<NavigationMenuItem> Children { get; set; }
    }
}