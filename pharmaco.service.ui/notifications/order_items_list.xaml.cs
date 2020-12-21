using pharmaco.model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace pharmaco.service.ui.notifications
{
    /// <summary>
    /// Interaction logic for order_items_list.xaml
    /// </summary>
    public partial class order_items_list : UserControl
    {
        private bool panel_collapsed;
        public bool collapsed { get { return panel_collapsed; } set { panel_collapsed = value; refresh_collapsed(); } }

        public order_items_list()
        {
            InitializeComponent();
        }

        public void set_items(List<orderItem> items)
        {
            items.ForEach(item => items_panel.Children.Add(new order_item_row(item.quantity, item.name) { checkbutton_visibility = Visibility.Hidden}));
            if (items.Count > 3)
                collapsed = true;
            else
                expand_button.Visibility = Visibility.Collapsed;
        }

        private void expand_button_Click(object sender, RoutedEventArgs e)
        {
            collapsed = !collapsed;
            expand_button.up = !expand_button.up;
            refresh_collapsed();
        }

        private void refresh_collapsed()
        {
            if (panel_collapsed)
            {
                for (int i = 3; i < items_panel.Children.Count; i++)
                    items_panel.Children[i].Visibility = Visibility.Collapsed;
                shadow_rectangle.Visibility = Visibility.Visible;
                expand_button.Visibility = Visibility.Visible;
                shadow_rectangle.Fill = FindResource("fill_grey") as SolidColorBrush; 
                
            }
            else
            {
                for (int i = 3; i < items_panel.Children.Count; i++)
                    items_panel.Children[i].Visibility = Visibility.Visible;
                shadow_rectangle.Visibility = Visibility.Hidden;
              //  shadow_rectangle.Fill = Brushes.White ;
                // if (items.Count > 3) expand_button.Visibility = Visibility.Collapsed;
            }
        }

        internal void set_checkbutton_visibility(Visibility visibility)
        {
            foreach (UIElement ch in items_panel.Children)
                if (ch is order_item_row)
                    (ch as order_item_row).chcek.Visibility = visibility;
        }
    }
}
