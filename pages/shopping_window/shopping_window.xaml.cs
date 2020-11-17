using pharmaco.components.shopping;
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

namespace pharmaco.pages.shopping_window
{
    /// <summary>
    /// Interaction logic for shopping_window.xaml
    /// </summary>
    public partial class shopping_window : Window
    {
        public event Action<order> order_confirmed;
        public event Action order_canceled;

        public event Action<orderItem_with_image> show_detail;
        public List<orderItem_with_image> order_items { get { return shopping.items; } set { shopping.items = value; } }
        public shopping_window()
        {
            InitializeComponent();
            order_items = new List<orderItem_with_image>();
        }

        private void shopping_order_confirmed(order order)
        {
            order_confirmed(order);
        }

        private void shopping_window_closed()
        {
            this.Hide();
        }

        private void shopping_show_detail(orderItem_with_image obj)
        {
            this.Hide();
            show_detail(obj);
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
           
        }

        private void shopping_order_canceled()
        {
            order_canceled();
        }
    }
}
