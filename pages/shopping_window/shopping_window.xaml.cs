using pharmaco.model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace pharmaco.pages.shopping_window
{
    /// <summary>
    /// Interaction logic for shopping_window.xaml
    /// </summary>
    public partial class shopping_window : Window
    {
        public event Action<order> order_confirmed;
        public event Action order_canceled;
        public event Action<int> update_cart_info;

        public event Action<orderItem_with_image> show_detail;
        public int items_count { get { return shopping.items.Count; } }
        //private List<orderItem_with_image> order_items;

        public void add_to_order(orderItem_with_image item)
        {
            shopping.items.Add(item);
        }
        public shopping_window()
        {
            InitializeComponent();
            shopping.items = new List<orderItem_with_image>();
        }

        private void shopping_order_confirmed(order order)
        {
            order_confirmed(order);
        }

        private void shopping_window_closed()
        {
            update_cart_info(items_count);
            this.Hide();
        }

        private void shopping_show_detail(orderItem_with_image obj)
        {
            update_cart_info(items_count);
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

        internal void cancel_order()
        {
            shopping.cancel_order();
        }
    }
}
