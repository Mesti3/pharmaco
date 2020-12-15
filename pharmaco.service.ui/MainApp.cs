using pharmaco.service.ui.taskbar_icon;
using System;
using System.Timers;
using System.Windows;

namespace pharmaco.service.app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class MainApp : Application
    {
        private Timer timer;
        private taksbar_icon tbi;
        private service_controller controller;
        public MainApp()
        {
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }

            tbi = new taksbar_icon();
            tbi.onclicked += tbi_onclicked; // += tbi_MouseDown;
            timer = new Timer();
            timer.AutoReset = true;
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 15000;
            timer.Start();
            controller = new service_controller(tbi);
        }

        private void tbi_onclicked(object sender)
        {
            controller.open_balloon();
        }


        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                controller.load_new_orders();
            });
            /*
           
                controller.load_new_orders();
            
            */
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            //todo> kontrola,či je potrebné vypínať a zapínať timer
            timer.Stop();
            controller.load_new_orders();
            timer.Start();
        }


        private void tbi_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                controller.open_balloon();
            });
        }
    }
}
