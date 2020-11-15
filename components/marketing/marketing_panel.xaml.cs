using pharmaco.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Controls;

namespace pharmaco.components.marketing
{
    public partial class marketing_panel : UserControl
    {
        public event Action<marketing_with_image> marketing_needed;
        private List<marketing_with_image> marketings;
        private Timer timer = new Timer();
        public marketing_panel()
        {
            InitializeComponent();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            chancge_marketing();
        }

        public void set_marketing(List<marketing_with_image> marketings)
        {
            this.marketings = marketings.Where(x => x.vertical_image_source != null).ToList();
            if (this.marketings.Count() > 0)
            {
                image.Tag = this.marketings[this.marketings.Count()-1];
                chancge_marketing();
            }
        }

        private void chancge_marketing()
        {
            Dispatcher.Invoke(() => {
                var index = marketings.IndexOf(image.Tag as marketing_with_image);
                if (index == marketings.Count - 1)
                    set_image(0);
                else
                    set_image(index + 1);
                if (this.marketings.Count > 1)
                    timer.Start();
            });
         
        }

        private void set_image(int index)
        {
            image.Source = marketings[index].vertical_image_source;
            image.Tag = marketings[index];
        }

        private void image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            marketing_needed(image.Tag as marketing_with_image);
        }
    }
}
