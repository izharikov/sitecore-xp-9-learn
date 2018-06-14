namespace events.tac.local.Models
{
    public class NavigationItem
    {
        public NavigationItem(string title, string url, bool active)
        {
            Title = title;
            URL = url;
            Active = active;
        }

        public string Title { get; set; }
        public string URL { get; set; }
        public bool Active { get; set; }
    }
}