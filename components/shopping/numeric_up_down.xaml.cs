using pharmaco.model;
using pharmaco.pages.message_box;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
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

namespace pharmaco.components.shopping
{
    /// <summary>
    /// Interaction logic for numeric_up_down.xaml
    /// </summary>
    public partial class numeric_up_down : UserControl
    {
        public event Action<int> quantity_changed;

        private int order_qiantity;
        private int max_quantity;
        public numeric_up_down()
        {
            InitializeComponent();
        }

     

        internal  void init(int ordered_quantity, int max_quantity)
        {
            this.max_quantity = max_quantity;// orderitem.med.available_quantity.HasValue ? (int)Math.Floor( orderitem.med.available_quantity.Value ): int.MaxValue;
            this.order_qiantity = ordered_quantity;

            set_quantity();
        }

        private void set_quantity()
        {

            block.Text = (order_qiantity).ToString();
        }

        private void green_button_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(block.Text) < max_quantity)
            {
                order_qiantity += 1;
                set_quantity();
                quantity_changed(order_qiantity);
            }
            else
                message_box.show_dialog("Viac nemáme", MessageBoxButton.OK);
        }

        private void minus_button_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(block.Text) >0)
            {
                order_qiantity -= 1;
                set_quantity();
                quantity_changed(order_qiantity);
            }
        }

        public int get_item()
        {
            return order_qiantity;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            plus_button.Width = plus_button.ActualHeight;
            plus_button.corner_radius =(int)(plus_button.ActualHeight*0.8);
            minus_button.Width = minus_button.ActualHeight;
            minus_button.corner_radius = (int)(minus_button.ActualHeight*0.8);
        }
    }

}
