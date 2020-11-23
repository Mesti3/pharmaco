using System.Collections.Generic;

namespace pharmaco.model
{
    public class category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parent_category_id { get; set; }
        public category parent_category { get; set; }
        public List<category> subcategories { get; set; }

        public category()
        {
            subcategories = new List<category>();
        }
    }
}
