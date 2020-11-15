using pharmaco.model;
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

namespace pharmaco.components.categories
{
    /// <summary>
    /// Interaction logic for category_row.xaml
    /// </summary>
    public partial class category_row : UserControl
    {
        List<category> categories;
        category_row child_row;
        public category_row()
        {
            InitializeComponent();
        }

        public void set_categories(List<category> cats)
        {
            categories = cats;
            foreach (category c in cats)
            {
                arrow_button a = new arrow_button();
                a.cat = c;
                a.text = c.name;
                a.text_tont_size = 30;
                a.Width = 200;
                panel.Children.Add(a);
            }
        }
    }
}
