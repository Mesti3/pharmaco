using pharmaco.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace pharmaco.service.ui.notifications
{
    /// <summary>
    /// Interaction logic for notification_baloon.xaml
    /// </summary>
    public partial class notification_baloon : UserControl
    {

        public event Action<notification_baloon_element> process_clicked;
        public event Action<notification_baloon_element> done_clicked;
        public event Action<notification_baloon_element> cancel_clicked;

        List<int> displayed_orders_ids;
        List<int> my_orders_ids;
        List<int> ignored_orders_ids;
        public notification_baloon()
        {
            InitializeComponent();
            displayed_orders_ids = new List<int>();
            my_orders_ids = new List<int>();
            ignored_orders_ids = new List<int>();
        }

        public notification_baloon(List<order> orders):this()
        {
            set_orders(orders);
        }

        public void set_orders(List<order> orders)
        {
            foreach (var item in orders)
            {
                notification_baloon_element element = new notification_baloon_element(item);
                element.ignore_clicked += element_ignore_clicked;
                element.process_clicked += element_process_clicked;
                element.done_clicked += element_done_clicked; ;
                element.cancel_clicked += element_cancel_clicked; ;
                panel.Children.Add(element);
            }
            displayed_orders_ids.AddRange(orders.Select(x => x.id).ToList());
        }

        private void element_cancel_clicked(notification_baloon_element obj)
        {
            my_orders_ids.Remove(obj.order.id);
            cancel_clicked(obj);
        }

        private void element_done_clicked(notification_baloon_element obj)
        {
            my_orders_ids.Remove(obj.order.id);
            done_clicked(obj);
        }

        private void element_process_clicked(notification_baloon_element obj)
        {
            my_orders_ids.Add(obj.order.id);
            process_clicked(obj);
        }

        private void element_ignore_clicked(notification_baloon_element obj)
        {
            ignored_orders_ids.Add(obj.order.id);
            panel.Children.Remove(obj);
        }
    }
}
