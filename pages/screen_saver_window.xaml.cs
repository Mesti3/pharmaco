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
using System.Windows.Shapes;

namespace pharmaco.pages
{
    /// <summary>
    /// Interaction logic for screen_saver_windiw.xaml
    /// </summary>
    public partial class screen_saver_window : Window
    {
        public event Action<objects.marketing_with_image> marketing_needed;
        public event Action search_button_clicked;
        public screen_saver_window()
        {
            InitializeComponent();
            big_marketing.interval = 10000;
        }

        private void green_button_Click(object sender, RoutedEventArgs e)
        {
            search_button_clicked();
            Hide();
        }           

        private void big_marketing_marketing_needed(objects.marketing_with_image obj)
        {
            marketing_needed(obj);
            Hide();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            big_marketing.reset_timer();
        }
    }
}
