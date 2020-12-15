using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace pharmaco.resources.components.button
{

    public partial class green_button : Button
    {
        private CornerRadius? cornerradius;
        public int corner_radius 
        { 
            set
            {
                this.ApplyTemplate();
                var im = this.Template.FindName("button_border", this);
                if (im != null)
                {
                    cornerradius = new System.Windows.CornerRadius(value);
                    (im as Border).CornerRadius = cornerradius.Value;                    
                }
            }
        }
        public green_button():base()
        {
            InitializeComponent();
            cornerradius = null ;
        }

        [EditorBrowsable]
        public string GreenButtonText
        {
            get { return block.Text; }
            set { block.Text = value; }
        }

        private void button_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!cornerradius.HasValue)
                corner_radius = (int)this.ActualHeight / 3;
        }
    }
}
