using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pharmaco.resources.components.button
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class check_buttom : Button
    {
        private bool chcecked;
        
        [EditorBrowsable]
        public bool Checked { get { return chcecked; } set { chcecked = value; update_colors(); } }

        private void update_colors()
        {
            try
            {
                this.ApplyTemplate();
                Polygon p = this.Template.FindName("polygon", this) as Polygon;

                if (chcecked)
                {
                    p.Fill = FindResource("light_green") as SolidColorBrush;
                    p.Stroke = FindResource("dark_green") as SolidColorBrush;
                }
                else
                {
                    p.Fill = FindResource("fill_grey") as SolidColorBrush;
                    p.Stroke = FindResource("border_grey") as SolidColorBrush;
                }
            }
            catch (Exception ex)
            { 
            }
                        
        }

        public check_buttom()
        {
            InitializeComponent();
            chcecked = false;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Checked = !Checked;
        }
    }
}
