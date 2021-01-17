using System;
using System.Windows;
using System.Windows.Controls;
using pharmaco.model;

namespace pharmaco.components.medicine_components
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class medicine_detail : UserControl
    {
        public event Action<pharmaco.components.filter.filter> product_ordered;
        public event Action<medicine_detail> product_list_needed;
        public int left_panel_width;
        private medicine med;

        public medicine_detail()
        {
            InitializeComponent();
            order_button.corner_radius = 50/3;
            back_button.corner_radius = 50/3;
        }

        public medicine_detail(model.medicine obj):this()
        {
            FillMedicine(obj);
        }

        public void FillMedicine(medicine obj)
        {
            Clear();
               med = obj;
            medicine_filter.FillMedicine(med);
            medicine_filter.mode = filter.filter_mode.detail;
            medicine_filter.UpdateLayout();
            medicine_name.Text = med.name;
            if (!string.IsNullOrWhiteSpace(med.form))
                medicine_form.Text = med.form;
            else
                medicine_form.Visibility = Visibility.Collapsed;

            this.scroll_view.Content = new medicine_text_section(med);
                                
            UpdateLayout();
            //public string producer { get; set; }
            //public bool? prescription_only { get; set; }
            //public string flyer { get; set; }
             
        }

        private void Clear()
        {
            medicine_filter.Clear();
            medicine_name.Text = "";
            medicine_form.Text = "";
            medicine_form.Visibility = Visibility.Visible;
            scroll_view.Content = null;

        }

        private void order_button_Click_1(object sender, RoutedEventArgs e)
        {
            product_ordered(medicine_filter);
        }

        private void back_button_Click_1(object sender, RoutedEventArgs e)
        {
            product_list_needed(this);
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
                scroll_view.ScrollToTop();
        }
    }
}
