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

namespace pharmaco.pages.message_box
{
    /// <summary>
    /// Interaction logic for message_box.xaml
    /// </summary>
    public partial class message_box : Window
    {
        public message_box()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="message_box_button"> only {Ok/ OkCancel/ YesNo} supported</param>
        public static bool? show_dialog(string text, MessageBoxButton message_box_button)
        {
            message_box mb = new message_box();
            mb.text.Text = text;
            switch (message_box_button)
            {
                case MessageBoxButton.OK: { mb.orange.Visibility = Visibility.Collapsed; mb.green.GreenButtonText = "Dobre"; mb.no_column.Width = new GridLength(0,GridUnitType.Pixel) ; break; }
                case MessageBoxButton.YesNo: { mb.orange.GreenButtonText = "Nie"; mb.green.GreenButtonText = "Áno"; break; }
                case MessageBoxButton.OKCancel: { mb.orange.GreenButtonText = "Zrušiť"; mb.green.GreenButtonText = "Dobre"; break; }
            }
            mb.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            return mb.ShowDialog();

        }

        private void yes_button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void no_button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
