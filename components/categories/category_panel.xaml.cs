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
    /// Interaction logic for category_panel.xaml
    /// </summary>
    public partial class category_panel : UserControl
    {
        List<category> categories;
        public category_panel()
        {
            InitializeComponent();
        }
        public void set_categories(List<category> cats) 
        {
            categories = cats;
            category_row cr = new category_row();
            cr.set_categories(cats);
            big_panel.Children.Add(cr);
        }
    }
}
