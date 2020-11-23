using System.Collections.Generic;

namespace pharmaco.objects
{
    public class menu_item_object
    { 
        public string text_to_show;
        public object data;
        public List<menu_item_object> items;

        public menu_item_object()
        {
            items =  new List<menu_item_object>();
        }
    }
}
