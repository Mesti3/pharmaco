using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pharmaco.components.search
{
    /// <summary>
    /// Interaction logic for search_box.xaml
    /// </summary>
    public partial class search_box : UserControl
    {
        public event Action product_selected;


        [EditorBrowsable]
        public string text { get { return text_block.Text; } set { text_block.Text = value; } }
        [EditorBrowsable]
        public double list_max_height { get { return list_box.MaxHeight; } set { list_box.MaxHeight = value; } }
        [EditorBrowsable]
        public double list_font_height { get { return list_box.FontSize; } set { list_box.FontSize = value; } }
        [EditorBrowsable]
        public double text_box_width { get { return text_block.Width; } set { text_block.Width = value; } }
        [EditorBrowsable]
        public double text_box_heigh { get { return text_block.Height; } set { text_block.Height = value; } }
        [EditorBrowsable]
        public double text_box_corner_radius { get { return button_border.CornerRadius.TopLeft; } set { button_border.CornerRadius  =new CornerRadius(value); } }
        public search_box()
        {
            InitializeComponent();
            list_box.Visibility = Visibility.Collapsed;
            list_box.FontSize = 0.9 * text_block.FontSize;
        }
        public void  set_items(List<string> items)
        {
            list_box.ItemsSource = items;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list_box.ItemsSource);
            list_box.Items.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
                return text_block.Text.Length >= 3 && item.ToString().ToUpper().StartsWith(text.ToUpper());
        }
        private void text_block_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (list_box != null)
            {
                if (text_block.Text.Length >= 3)
                {
                    CollectionViewSource.GetDefaultView(list_box.ItemsSource).Refresh();
                    list_box.Visibility = Visibility.Visible;
                }
                else
                    list_box.Visibility = Visibility.Collapsed;
            }
        }

        private void list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                text_block.Text = (sender as ListView).SelectedItem.ToString();
                list_box.Visibility = Visibility.Collapsed;
                product_selected();
            }
        }

        private void text_block_LostFocus(object sender, RoutedEventArgs e)
        {
            list_box.Visibility = Visibility.Collapsed;
        }

        private void text_block_KeyDown(object sender, KeyEventArgs e)
        {

            if (list_box != null)
            {
                if (text_block.Text.Length >= 3)
                {
                    CollectionViewSource.GetDefaultView(list_box.ItemsSource).Refresh();
                    list_box.Visibility = Visibility.Visible;
                }
                else
                    list_box.Visibility = Visibility.Collapsed;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            button_border.CornerRadius = new CornerRadius(text_box_heigh / 3);
        }
    }
}
