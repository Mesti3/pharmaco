using pharmaco.model;
using pharmaco.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pharmaco.components.menu
{
    public partial class button_menu : UserControl
    {
        public event Action<category> item_selected;
        public button_menu()
        {
            InitializeComponent();
            menu.Visibility = Visibility.Collapsed;
        }

        public void set_items(List<category> categories)
        {
            menu.set_items(create_menu_item_objects(categories));
        }

        private List<menu_item_object> create_menu_item_objects(List<category> categories)
        {
            if (categories.Count > 0)
                return categories.Select(x => new objects.menu_item_object() { text_to_show = x.name, data = x, items = create_menu_item_objects(x.subcategories) }).ToList();
            else
                return new List<menu_item_object>();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
        }

        private void menu_item_selected(objects.menu_item_object obj)
        {
            item_selected(obj.data as category);
            menu.Visibility = Visibility.Collapsed;
        }

      
    }
}
