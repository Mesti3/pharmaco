using System.Windows.Controls;

namespace pharmaco.components.medicine_components
{
    public partial class medicine_text_block : UserControl
    {
        public medicine_text_block()
        {
            InitializeComponent();
        }
        public medicine_text_block(string caption, string text):this()
        {
            this.caption.Text = caption;
            this.info.Text = text;
            var texts = text.Split(new string[12] { "<p>", "</p>", "<span>", "</span>", "<strong>", "</strong>", "<br>", "</br>", "<ul>", "</ul>", "<li>", "</li>" },System.StringSplitOptions.RemoveEmptyEntries);
         
        }
    }
}
