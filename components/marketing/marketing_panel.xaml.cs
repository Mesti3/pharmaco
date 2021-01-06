using pharmaco.objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private marketing_panel_mode_enum mode;

        [EditorBrowsable]
        public double interval { get { return timer.Interval; } set { timer.Interval = value; } }

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

        public void set_marketing(List<marketing_with_image> marketings, marketing_panel_mode_enum mode)
        {
            this.mode = mode;
            switch (mode)
            {
                case marketing_panel_mode_enum.vertical: { this.marketings = marketings.Where(x => x.vertical_image_source != null).ToList(); break; }
                case marketing_panel_mode_enum.horizontal: { this.marketings = marketings.Where(x => x.horizontal_image_source != null).ToList(); break; }
                case marketing_panel_mode_enum.fullscren: { this.marketings = marketings.Where(x => x.fullscreen_image_source != null).ToList(); break; }
            }
            if (this.marketings.Count() > 0)
            {
                image.Tag = this.marketings[this.marketings.Count() - 1];
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
            switch (mode)
            {
                case marketing_panel_mode_enum.vertical: { image.Source = marketings[index].vertical_image_source; break; }
                case marketing_panel_mode_enum.horizontal: { image.Source = marketings[index].horizontal_image_source; break; }
                case marketing_panel_mode_enum.fullscren: { image.Source = marketings[index].fullscreen_image_source; break; }
            }
            image.Tag = marketings[index];
        }

        private void image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            marketing_needed(image.Tag as marketing_with_image);
        }
        public void reset_timer()
        {
            timer.Enabled = false;
            timer.Stop();
            timer.Enabled = true;
            timer.Start();
        }
    }
}
