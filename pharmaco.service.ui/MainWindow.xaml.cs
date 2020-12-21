using pharmaco.data;
using pharmaco.log;
using pharmaco.model;
using pharmaco.service.ui.notifications;
using pharmaco.service.ui.taskbar_icon;
using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace pharmaco.service.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private taksbar_icon tbi;

        public MainWindow()
        {
            InitializeComponent();
            tbi = new taksbar_icon();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client_id = ConfigurationManager.AppSettings["ClientID"];
            try
            {
              var data = new DataController("client_id");
                var orders = data.GetAllOrders(DateTime.Now.AddHours(-3), DateTime.Now,null, orderstate.created);

                if (orders.Count > 0)
                {
                    notification_baloon balloon = new notification_baloon(orders);
                    balloon.process_clicked += balloon_process_clicked;
                    balloon.done_clicked += balloon_done_clicked;
                    balloon.cancel_clicked += balloon_cancel_clicked;
                    tbi.ShowCustomBalloon(balloon, PopupAnimation.Slide);
                
                }
            }
            catch (Exception ex)
            {
                {
                    error_baloon balloon = new error_baloon();
                    tbi.ShowCustomBalloon(balloon, PopupAnimation.Slide);
                }
            }
        }

        private void balloon_cancel_clicked(notification_baloon_element obj)
        {
            try
            {
                set_order_state(orderstate.created, null, obj);
            }
            catch (Exception ex)
            {
                handle_balloon_ex(ex, "Objednávku sa nepodarilo aktualizovať");
            }
        }
        private void balloon_done_clicked(notification_baloon_element obj)
        {
            set_order_state(orderstate.sold, System.Environment.MachineName, obj);
            obj.Visibility = Visibility.Collapsed;
        }
#nullable enable
        private void set_order_state(orderstate new_state, string? user, notification_baloon_element obj)
        {
            tbi.ResetTimer();
            var data = new DataController("client_id");
            try
            {
                    data.UpdateOrderState(obj.order.id, new_state,user);
                    obj.order.state = new_state;
                    obj.order.user =  (user == null) ? "" : user;
                
                obj.update_state();
            }
            catch (Exception ex)
            {
                handle_balloon_ex(ex, "Objednávku sa nepodarilo aktualizovať");
            }
        }

#nullable disable


        private void balloon_process_clicked(notification_baloon_element obj)
        {
            tbi.ResetTimer();
            var data = new DataController("client_id");
            try
            {
                Tuple<orderstate, string> o = data.ReloadOrderHeader(obj.order.id);
                obj.order.state = o.Item1;
                obj.order.user = o.Item2;
                if (o.Item1 == orderstate.created)
                {
                    data.UpdateOrderState(obj.order.id, orderstate.processed, System.Environment.MachineName);
                    obj.order.state = orderstate.processed;
                    obj.order.user = System.Environment.MachineName;
                }
                obj.update_state();
            }
            catch (Exception ex)
            {
                handle_balloon_ex(ex, "Objednávku sa nepodarilo aktualizovať");
            }
        }

        private void handle_balloon_ex(Exception ex, string text)
        {
            logger.send_email(ex, ConfigurationManager.AppSettings["ClientID"], "service error");
            error_baloon balloon = new error_baloon();
            balloon.error_text = text;
            tbi.ShowCustomBalloon(balloon, PopupAnimation.Slide);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            error_baloon balloon = new error_baloon();
            tbi.ShowCustomBalloon(balloon, PopupAnimation.Slide);
        }
    }
}
