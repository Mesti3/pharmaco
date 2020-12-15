using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace pharmaco.service.ui.taskbar_icon
{
    /// <summary>
    /// Interaction logic for taksbar_icon.xaml
    /// </summary>
    public partial class taksbar_icon
    {
        public delegate void clicked(object sender);
        public event clicked onclicked;

        //public EventHandler clicked2;
        // public event Action clicked =  delegate{};
        public taksbar_icon()
        {
            InitializeComponent();
        }
        public void ShowCustomBalloon(UIElement balloon, PopupAnimation animation, int timeout = 10000)
        {
            tb_icon.ShowCustomBalloon(balloon, animation, timeout); 
        }
        public void ResetTimer()
        {
            tb_icon.ResetBalloonCloseTimer();
        }

        private void tb_icon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            onclicked(this);
        }

        //private void tb_icon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        //{
        //    onclicked(this);
        //}
    }
}
