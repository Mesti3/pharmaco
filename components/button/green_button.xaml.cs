using System.ComponentModel;
using System.Windows.Controls;

namespace pharmaco.components.button
{

    public partial class green_button : Button
    {
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

    }
}
