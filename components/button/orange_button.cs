using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pharmaco.components.button
{
    public class orange_button : green_button
    {
        public orange_button() : base()
        {
            base.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 112, 0));
            base.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 220, 80, 0));
            base.UpdateLayout();
        }
    }
}
