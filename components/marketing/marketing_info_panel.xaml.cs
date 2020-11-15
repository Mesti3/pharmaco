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

namespace pharmaco.components.marketing
{
    /// <summary>
    /// Interaction logic for marketing_info_panel.xaml
    /// </summary>
    public partial class marketing_info_panel : UserControl
    {
        public marketing_info_panel()
        {
            InitializeComponent();
        }

        public void set_marketing(marketing_with_image marketing)
        {
            if (!string.IsNullOrWhiteSpace(marketing.marketing.name))
            {
                name_text.Text = marketing.marketing.name;
                name_text.Visibility = Visibility.Visible;
            }
            else
                name_text.Visibility = Visibility.Collapsed;

            if (!string.IsNullOrWhiteSpace(marketing.marketing.description))
            {
                description_text.Text  = marketing.marketing.description;
                description_text.Visibility = Visibility.Visible;
            }
            else
                description_text.Visibility = Visibility.Collapsed;

            if (marketing.horizontal_image_source != null)
            {
                image.Source = marketing.horizontal_image_source;
                image.Visibility = Visibility.Visible;
            }
            else
                image.Visibility = Visibility.Collapsed;
        }
    }
}
