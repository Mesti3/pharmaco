using pharmaco.service.app;
using System;
using System.Windows;

namespace pharmaco.service.ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    { 
        [STAThread]
        public static void Main()
        {
            //var application = new App();
            //application.InitializeComponent();
            //application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            //application.Run();
            var mapp = new MainApp();

            System.Uri resourceLocater = new System.Uri("/pharmaco.service.ui;component/app.xaml", System.UriKind.Relative);

            System.Windows.Application.LoadComponent(mapp, resourceLocater);

            mapp.Run();
        }

    }
}
