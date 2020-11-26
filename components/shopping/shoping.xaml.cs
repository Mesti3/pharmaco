using pharmaco.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace pharmaco.components.shopping
{
    public partial class shoping : UserControl
    {
        public List<orderItem_with_image> items;
        public event Action<order> order_confirmed;
        public event Action order_canceled;
        public event Action window_closed;
        public event Action<orderItem_with_image> show_detail;
        public shoping()
        {
            InitializeComponent();
        }

        public void set_for_order(List<orderItem_with_image> items)
        {
            this.items = items;
            refresh_items();
        }
        private decimal calc_total_price()
        {
            decimal total = 0;
            if (items.Count > 0)
                total = Math.Round(items.Sum(x => x.quantity * x.med.price).Value, 2, MidpointRounding.AwayFromZero);
            price_block.Text = total.ToString("c");
            return total;
        }

        private void buy_button_Click(object sender, RoutedEventArgs e)
        {
            if (items.Count > 0)
            {
                order order = new order();
                order.created = DateTime.Now;
                order.state = orderstate.created;
                order.items = items.Select(x => x.order_item).ToList();
                order_confirmed(order);
            }
        }

        private void cance_button_Click(object sender, RoutedEventArgs e)
        {
            cancel_order();
            order_canceled();
        }

        internal void cancel_order()
        {
            items.Clear();
            refresh_items();
            window_closed();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refresh_items();
        }

        public void refresh_items()
        {
            left_panel.Children.Clear();
            foreach (orderItem_with_image oi in items)
            {
                shopping_item si = new shopping_item();
                si.set_order_item(oi);
                si.item_removed += Si_item_removed;
                si.price_changed += Si_price_changed;
                si.show_detail += Si_show_detail;
                left_panel.Children.Add(si);
            }
            calc_total_price();
        }

        private void Si_show_detail(orderItem_with_image obj)
        {
            show_detail(obj);
        }

        private void Si_price_changed()
        {
            calc_total_price();
        }

        private void Si_item_removed(shopping_item obj)
        {
            items.Remove(obj.item);
            left_panel.Children.Remove(obj);
            calc_total_price();
        }

        private void main_window_button_Click(object sender, RoutedEventArgs e)
        {
            window_closed();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
                refresh_items();
        }
    }
}
