using pharmaco.model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace pharmaco.components.shopping
{
    /// <summary>
    /// Interaction logic for shopping_item.xaml
    /// </summary>
    public partial class shopping_item : UserControl
    {
        public orderItem_with_image item;
        public event Action<shopping_item> item_removed;
        public event Action<orderItem_with_image> show_detail;
        public event Action price_changed;
        public shopping_item()
        {
            InitializeComponent();
            delete_button.Height = detail_button.Height;
            
        }

        public void set_order_item(orderItem_with_image order_item)
        {
            item = order_item;
            upper_text.Text = item.med.name;
            bottom_text.Text = item.med.form;
            unit_rice_text.Text = item.med.price.HasValue ? item.med.price.Value.ToString():"";
            numeric.init(Convert.ToInt32(item.quantity), item.med.available_quantity.HasValue ? (int)Math.Floor(item.med.available_quantity.Value) : int.MaxValue);
            set_total_price();
            image.Source = order_item.image_source;
        }

        private void set_total_price()
        {
            if (item.med.price.HasValue)
                total_price_text.Text = Math.Round(item.med.price.Value * item.quantity, 2, MidpointRounding.AwayFromZero).ToString("c");
        }

        private void numeric_quantity_changed(int obj)
        {
            item.quantity = obj;
            set_total_price();
            price_changed();
        }

        private orderItem get_item()
        {
            return item.order_item;
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            item_removed(this);
        }

        private void detail_button_Click(object sender, RoutedEventArgs e)
        {
            show_detail(item);
        }
    }
}
