using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace pharmaco.components.search
{
    /// <summary>
    /// Interaction logic for search_box.xaml
    /// </summary>
    public partial class search_box : UserControl
    {
        public event Action product_selected;
        public event Action<string> category_selected;

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
        public double text_box_corner_radius { get { return button_border.CornerRadius.TopLeft; } set { button_border.CornerRadius = new CornerRadius(value); } }
        public double list_box_radius { get { return Math.Min(Math.Max((box_border.ActualHeight - 20) / 2, 0), 30); } }
        public search_box()
        {
            InitializeComponent();
            box_border.Visibility = Visibility.Collapsed;
            list_box.FontSize = 0.9 * text_block.FontSize;
        }
        public void set_items(List<string> items)
        {
            list_box.ItemsSource = items;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list_box.ItemsSource);
            list_box.Items.Filter = UserFilter;
        }
        public void set_items_cat(List<Tuple<string, string>> items)
        {
            list_box_cat.ItemsSource = items;
            list_box_cat.DisplayMemberPath = "Item1";
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list_box_cat.ItemsSource);
            list_box_cat.Items.Filter = UserFilterCat;
        }

        private bool UserFilter(object item)
        {
            return text_block.Text.Length >= 3 && item.ToString().ToUpper().StartsWith(text.ToUpper());
        }
        private bool UserFilterCat(object item)
        {
            return text_block.Text.Length >= 3 && (item.ToString().ToUpper().Contains(" > " + text.ToUpper()) || (item as Tuple<string, string>).Item1.ToUpper().StartsWith(text.ToUpper()));
        }
        private void text_block_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (list_box != null && list_box.ItemsSource!= null)
            {
                if (text_block.Text.Length >= 3)
                {
                    CollectionViewSource.GetDefaultView(list_box.ItemsSource).Refresh();
                    CollectionViewSource.GetDefaultView(list_box_cat.ItemsSource).Refresh();
                    if (list_box.HasItems || list_box_cat.HasItems)
                    {
                        box_border.Visibility = Visibility.Visible;

                        list_box.Visibility = list_box.HasItems ? Visibility.Visible : Visibility.Collapsed;
                        list_box_cat.Visibility = list_box_cat.HasItems ? Visibility.Visible : Visibility.Collapsed;
                        //if (list_box.HasItems && list_box_cat.HasItems)
                        //{
                        //    if (list_box.Template.FindName("list_box_border", list_box) != null)
                        //        (list_box.Template.FindName("list_box_border", list_box) as Border).BorderThickness = new Thickness(0, 0, 0, 1);
                        //}
                        //else
                        //{
                        //    if (list_box.Template.FindName("list_box_border", list_box) != null)
                        //        (list_box.Template.FindName("list_box_border", list_box) as Border).BorderThickness = new Thickness(0, 0, 0, 0);
                        //}
                    }
                    else
                        box_border.Visibility = Visibility.Collapsed;
                }
                else
                    box_border.Visibility = Visibility.Collapsed;
            }
        }

        private void list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                if ((sender as ListView).SelectedItem is Tuple<string, string>)//category selected
                {
                    text_block.Text = (sender as ListView).SelectedItem.ToString();
                    box_border.Visibility = Visibility.Collapsed;
                    category_selected(((sender as ListView).SelectedItem as Tuple<string, string>).Item2);
                }
                else //product selected
                {
                    text_block.Text = (sender as ListView).SelectedItem.ToString();
                    box_border.Visibility = Visibility.Collapsed;
                    product_selected();
                }
            }
         
        }

        private void text_block_LostFocus(object sender, RoutedEventArgs e)
        {
            box_border.Visibility = Visibility.Collapsed;
        }

        private void text_block_KeyDown(object sender, KeyEventArgs e)
        {

            if (list_box != null && list_box_cat != null)
            {
                if (text_block.Text.Length >= 3)
                {
                    CollectionViewSource.GetDefaultView(list_box.ItemsSource).Refresh();
                    box_border.Visibility = Visibility.Visible;

                    list_box.Visibility = list_box.HasItems ? Visibility.Visible : Visibility.Collapsed;
                    list_box_cat.Visibility = list_box_cat.HasItems ? Visibility.Visible : Visibility.Collapsed;
                }
                else
                    box_border.Visibility = Visibility.Collapsed;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            button_border.CornerRadius = new CornerRadius(text_box_heigh / 3);
            list_box.ApplyTemplate();
            list_box_cat.ApplyTemplate();
        }

        private void list_box_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          double rad = list_box_radius;
            list_box.ApplyTemplate();
            list_box_cat.ApplyTemplate();

            if (list_box.HasItems)
            {
                if (list_box_cat.HasItems)
                {
                    (list_box.Template.FindName("mask", list_box) as Border).CornerRadius = new CornerRadius(rad - 0, rad - 0, 0, 0);
                    (list_box.Template.FindName("list_box_border", list_box) as Border).CornerRadius = new CornerRadius(rad - 0, rad + 0, 0, 0);
                }
                else
                {
                    (list_box_cat.Template.FindName("mask_cat", list_box_cat) as Border).CornerRadius = new CornerRadius(rad - 0, rad - 0, rad, rad);
                    (list_box_cat.Template.FindName("list_box_border_cat", list_box_cat) as Border).CornerRadius = new CornerRadius(rad - 0, rad + 0, rad, rad);

                    (list_box.Template.FindName("mask", list_box) as Border).CornerRadius = new CornerRadius(rad - 0, rad - 0, rad, rad);
                    (list_box.Template.FindName("list_box_border", list_box) as Border).CornerRadius = new CornerRadius(rad - 0, rad + 0, rad, rad);
                }
            }
                box_border.CornerRadius = new CornerRadius(rad);
            
        }
    }
}
