using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace pharmaco.service.ui.notifications
{
    /// <summary>
    /// Interaction logic for order_item_row.xaml
    /// </summary>
    public partial class order_item_row : UserControl
    {
        [EditorBrowsable]
        public Visibility checkbutton_visibility { get { return chcek.Visibility; } set { chcek.Visibility = value; } }
        public order_item_row()
        {
            InitializeComponent();
        }
        public order_item_row(decimal quantity, string name):this()
        {
            quantity_label.Content = quantity.ToString("F0");
            name_label.Text = name;           
        }     
    }
}
