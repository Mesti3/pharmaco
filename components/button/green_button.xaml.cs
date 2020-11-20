using System.ComponentModel;
using System.Windows.Controls;

namespace pharmaco.components.button
{

    public partial class green_button : Button
    {
        public int corner_radius 
        { 
            set
            {
                this.ApplyTemplate();
                var im = this.Template.FindName("button_border", this);
                if (im != null)
                    (im as Border).CornerRadius = new System.Windows.CornerRadius(value);
            }
        }
        public green_button():base()
        {
            InitializeComponent();
        }

        [EditorBrowsable]
        public string GreenButtonText
        {
            get { return block.Text; }
            set { block.Text = value; }
        }

        private void button_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            corner_radius = (int)this.ActualHeight / 3;
        }
    }
}
