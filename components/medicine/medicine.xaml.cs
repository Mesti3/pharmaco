using pharmaco.model;
using System;
using System.Windows;
using System.Windows.Controls;

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
            medicine_name.Content = med.name;
            if (!string.IsNullOrWhiteSpace(med.form))
                medicine_form.Content = med.form;
            else
                medicine_form.Visibility = Visibility.Collapsed;
            if (!string.IsNullOrWhiteSpace(med.description))
                big_right_stack_panel.Children.Add(new medicine_text_block("Popis", med.description));
            if (!string.IsNullOrWhiteSpace(med.usage))
                big_right_stack_panel.Children.Add(new medicine_text_block("Spôsob použitia", med.usage));
            if (!string.IsNullOrWhiteSpace(med.dosage))
                big_right_stack_panel.Children.Add(new medicine_text_block("Dávkovanie", med.dosage));
            if (!string.IsNullOrWhiteSpace(med.warning))
                big_right_stack_panel.Children.Add(new medicine_text_block("Varovanie", med.warning));
            if (!string.IsNullOrWhiteSpace(med.producer))
                big_right_stack_panel.Children.Add(new medicine_text_block("Výrobca", med.producer));

            UpdateLayout();
            //public string producer { get; set; }
            //public bool? prescription_only { get; set; }
            //public string flyer { get; set; }

        }

        private void Clear()
        {
            medicine_filter.Clear();
            medicine_name.Content = "";
            medicine_form.Content = "";
            medicine_form.Visibility = Visibility.Visible;
            big_right_stack_panel.Children.Clear();

        }

        private void order_button_Click_1(object sender, RoutedEventArgs e)
        {
            product_ordered(medicine_filter);
        }

        private void back_button_Click_1(object sender, RoutedEventArgs e)
        {
            product_list_needed(this);
        }

        private void fillText() 
        {
            

            Label lab = new Label();
          //  lab.Content = label3 + label4 + label5 + label6;

            this.scroll_view.Content = lab;
        }

    }
}
