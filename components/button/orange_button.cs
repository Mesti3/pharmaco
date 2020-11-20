using System.Windows.Controls;

namespace pharmaco.components.button
{
    public class orange_button : green_button
    {
        public orange_button() : base()
        {
            this.ApplyTemplate();
            var im = this.Template.FindName("button_border", this);
            if (im != null)
            {
                (im as Border).Background = System.Windows.Media.Brushes.White;
                (im as Border).BorderBrush = System.Windows.Media.Brushes.LightGray;
            }
            base.UpdateLayout();
        }
    }
}
