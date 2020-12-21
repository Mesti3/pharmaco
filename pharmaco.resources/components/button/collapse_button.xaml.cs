using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pharmaco.resources.components.button
{
    /// <summary>
    /// Interaction logic for collapse_button.xaml
    /// </summary>
    public partial class collapse_button : Button
    {
        private bool up_arrow;
       
        [EditorBrowsable]
        public bool up { get { return up_arrow; }set { up_arrow = value; refresh_arrow(); } }

        public collapse_button()
        {
            InitializeComponent();
            up_arrow = true;
            ApplyTemplate();
        }


        private void refresh_arrow()
        {
            Polygon polygon = this.Template.FindName("polygon", this) as Polygon;
            if (up_arrow)
                polygon.Points = new PointCollection(new List<Point>() { new Point(ActualWidth/2-20,16), new Point(ActualWidth / 2, 4), new Point(ActualWidth / 2+20, 16), new Point(ActualWidth / 2, 12) });
            else
                polygon.Points = new PointCollection(new List<Point>() { new Point(ActualWidth / 2-20, 4), new Point(ActualWidth / 2, 16), new Point(ActualWidth / 2+20, 4), new Point(ActualWidth / 2, 8) });
            this.UpdateLayout();
        }



        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            refresh_arrow();
        }
    }
}
