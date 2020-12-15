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

namespace pharmaco.service.ui.notifications
{
    /// <summary>
    /// Interaction logic for error_baloon.xaml
    /// </summary>
    public partial class error_baloon : UserControl
    {
        public string error_text { get { return text.Text; } set { text.Text = value; } }
        public error_baloon()
        {
            InitializeComponent();
        }
    }
}
