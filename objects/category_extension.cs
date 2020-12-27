using pharmaco.model;
using System.Collections.Generic;
using System.Linq;

namespace pharmaco.objects
{
    public class category_extension
    {
        public static category find_category(List<category> categories, string category_id)
        {
            category i = categories.Where(x => x.id == category_id).FirstOrDefault();
            if (i != null)
                return i;
            else
            {
                foreach (category c in categories.Where(x => x.subcategories.Any()))
                {
                    var si = find_category(c.subcategories, category_id);
                    if (si != null)
                        return si;
                }
            }
            return null;
        }
        public static List<string> find_subcategories_ids (List<category> categories, string category_id)
        {
            return find_subcategories_ids(find_category(categories, category_id));
        }
        public static List<string> find_subcategories_ids(category category)
        {
            List<string> result = new List<string>();
            if (category != null)
            {
                result.AddRange(get_ids_from_my_branch(category));
            }
            return result;
        }
        public static List<string> get_ids_from_my_branch( category category)
        {
            List<string> ids = new List<string>();
            ids.Add(category.id);
            if (category.subcategories.Any())
                foreach (category sc in category.subcategories)
                    ids.AddRange(get_ids_from_my_branch(sc ));
            return ids;
        }
    }
}