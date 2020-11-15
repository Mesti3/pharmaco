using pharmaco.model;
using System.Windows;
using System.Windows.Controls;

namespace pharmaco.components.categories
{
    /// <summary>
    /// Interaction logic for arrow_button.xaml
    /// </summary>
    public partial class arrow_button : Button
    {
        public category cat ;
        public string text { get { return text_block.Text; } set { text_block.Text = value; } }
        public double text_tont_size { get { return text_block.FontSize; } set { text_block.FontSize = value; } }

        private bool arrow_mode_value;
        public bool arrow_mode
        {
            set { arrow_mode_value = value; arrow_polygon.Visibility = arrow_mode_value == true ? Visibility.Visible : Visibility.Collapsed ; }

        }
        public arrow_button()
        {
            InitializeComponent();
            arrow_mode_value = false;
        }

        private void button_Loaded(object sender, RoutedEventArgs e)
        {
            
            arrow_polygon.Points.Add(new Point(-canvas.Width/2, -canvas.Height/2));
            arrow_polygon.Points.Add(new Point(-canvas.Width / 2, canvas.Height / 2));
            arrow_polygon.Points.Add(new Point(canvas.Width / 2, canvas.Height / 2));
            arrow_polygon.Points.Add(new Point(canvas.Width / 2, -canvas.Height / 2));
            arrow_polygon.Points.Add(new Point(-10, -canvas.Height / 2));
            arrow_polygon.Points.Add(new Point(0, -canvas.Height / 2 -10));
            arrow_polygon.Points.Add(new Point(10, -canvas.Height / 2));
        }


    }
}
