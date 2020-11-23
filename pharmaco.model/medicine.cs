using System.Collections.Generic;

namespace pharmaco.model
{
    public class medicine
    {
        public string id { get; set; }
        public string name { get; set; }
        public decimal? price { get; set; }
        public decimal? available_quantity { get; set; }
        public string available_quantity_as_string { get; set; }
        public string description { get; set; }
        public string form { get; set; }
        public string usage { get; set; }
        public string dosage { get; set; }
        public string warning { get; set; }
        public string producer { get; set; }
        public bool? prescription_only { get; set; }
        public string flyer { get; set; }
        public string photo_path { get; set; }
        public discount discountItem { get; set; }

        public List<category> categories { get; set; }
        public List<medicine> similar_products { get; set; }
        public string active_substances { get; set; }

        public medicine()
        {
            categories = new List<category>();
            similar_products = new List<medicine>();

        }

    }
}
