using System;
using System.Windows.Controls;
using pharmaco.model;

namespace pharmaco.service.ui.notifications
{
    /// <summary>
    /// Interaction logic for notification_baloon.xaml
    /// </summary>
    public partial class notification_baloon_element : UserControl
    {
        public event Action<notification_baloon_element> ignore_clicked;
        public event Action<notification_baloon_element> process_clicked;
        public event Action<notification_baloon_element> done_clicked;
        public event Action<notification_baloon_element> cancel_clicked;
        public order order;

        public notification_baloon_element(order order)
        {
            InitializeComponent();
            in_progress_label.Visibility = System.Windows.Visibility.Collapsed;
            this.order = order;
            state_label.Content = state_as_string(order.state);
            creation_date_label.Content = order.created.ToString("HH:mm:ss d.M.yyyy");
            block.Text = order.tag;
            items_list.set_items(order.items);

        }

        private void process_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (process_button.Tag.ToString() == "")
                process_clicked(this);
            else
                done_clicked(this);
        }

        private void ignore_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (process_button.Tag.ToString() == "")
                ignore_clicked(this);
            else
                cancel_clicked(this);

        }
        public void update_state()
        {
            state_label.Content = state_as_string(order.state);
            if (order.state == orderstate.created)
            {
                in_progress_label.Visibility = System.Windows.Visibility.Collapsed;
                items_list.Visibility = System.Windows.Visibility.Visible;
                reset_buttons(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible);
            }
            else if (order.state == orderstate.processed && (order.user == System.Environment.MachineName))
            {

                state_label.Content = "Vybavujem ju ja";
                in_progress_label.Visibility = System.Windows.Visibility.Collapsed;
                process_button.GreenButtonText = "Hotovo";
                process_button.Tag = "done";
                ignore_button.GreenButtonText = "Nechať iným";
                ignore_button.Tag = "cancel";
                process_button.Visibility = System.Windows.Visibility.Visible;
                ignore_button.Visibility = System.Windows.Visibility.Visible;
                items_list.set_checkbutton_visibility(System.Windows.Visibility.Visible);
            }
            else
            {
                in_progress_label.Visibility = System.Windows.Visibility.Visible;
                reset_buttons(System.Windows.Visibility.Collapsed, System.Windows.Visibility.Visible);
                items_list.Visibility = System.Windows.Visibility.Collapsed;
            }
            //}
            //else
            //{
            //    in_progress_label.Visibility = System.Windows.Visibility.Collapsed;
            //    reset_buttons(System.Windows.Visibility.Collapsed, System.Windows.Visibility.Visible);

            //}
            UpdateLayout();

        }
        private void reset_buttons(System.Windows.Visibility process_button_visibility, System.Windows.Visibility ignore_button_visibility)
        {
            process_button.GreenButtonText = "Spracovať";
            process_button.Tag = "";
            ignore_button.GreenButtonText = "Skryť";
            ignore_button.Tag = "";
            process_button.Visibility = process_button_visibility;
            ignore_button.Visibility = ignore_button_visibility;
            items_list.set_checkbutton_visibility(System.Windows.Visibility.Hidden);
        }

        private string state_as_string(orderstate state)
        {
            switch (state)
            {
                case orderstate.created: return "Nová";
                case orderstate.processed: return "Spracúva sa";
                case orderstate.sold: return "Predaná";
                case orderstate.cancelled: return "Zrušená";
                default: return "";
            }
        }
    }
}
