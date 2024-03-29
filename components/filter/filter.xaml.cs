﻿using pharmaco.model;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace pharmaco.components.filter
{
    /// <summary>
    /// Interaction logic for filter.xaml
    /// </summary>
    public partial class filter : UserControl
    {
        public event Action<filter> product_ordered;
        public event Action<medicine> product_detail_needed;
        // public event EventHandler product_ordered;
        public medicine med;
        public filter_mode mode
        {
            set
            {
                if (value == filter_mode.detail)
                {
                    order_button.Visibility = Visibility.Collapsed;
                    detail_button.Visibility = Visibility.Collapsed;
                    medicine_name.Visibility = Visibility.Collapsed;
                    bottom_grid.RowDefinitions[0].Height = new GridLength(0);
                    bottom_grid.RowDefinitions[1].Height = new GridLength(0);
                    filter_grid.RowDefinitions[0].Height = new GridLength(this.Width,GridUnitType.Pixel); ;//new GridLength(image.Height + image.Margin.Bottom + image.Margin.Top, GridUnitType.Pixel);
                }
                else
                {
                    order_button.Visibility = Visibility.Visible;
                    detail_button.Visibility = Visibility.Visible;
                    medicine_name.Visibility = Visibility.Visible;
                    bottom_grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                    bottom_grid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                    filter_grid.RowDefinitions[0].Height = new GridLength(medicine_name.Height + medicine_name.Margin.Bottom + medicine_name.Margin.Top, GridUnitType.Pixel);
                }
            }
        }
        public filter()
        {
            InitializeComponent();
        }
        public filter(medicine medicine)
            : this()
        {
         
            FillMedicine(medicine);

        }

        public  void FillMedicine(medicine medicine)
        {
            med = medicine;
            if (!string.IsNullOrWhiteSpace(medicine.name))
                medicine_name_block.Text = medicine.name;
            if (medicine.price.HasValue)
                price_block.Text = medicine.price.Value.ToString("c");
            if (!string.IsNullOrWhiteSpace(medicine.available_quantity_as_string))
                stock.Content = medicine.available_quantity_as_string;
            else if (medicine.available_quantity.HasValue)
                stock.Content = "Na sklade: " + medicine.available_quantity;
            image_button.ApplyTemplate();
            var im = image_button.Template.FindName("image", image_button);
            if (im != null)
                (im as Image).Source = get_image_source();
            
            if (medicine.discountItem != null)
            {
                if (!string.IsNullOrWhiteSpace(medicine.discountItem.text))
                    marketing.Content = medicine.discountItem.text;
                else
                    marketing.Visibility = Visibility.Collapsed;
                if (medicine.discountItem.originalPrice.HasValue)
                    original_price_block.Text = medicine.discountItem.originalPrice.Value.ToString("c");
                else
                    original_price.Visibility = Visibility.Collapsed;
            }
            else
            {
                original_price.Visibility = Visibility.Collapsed;
                marketing.Visibility = Visibility.Collapsed;
            }
        }

        internal void Clear()
        {

            medicine_name_block.Text = "";
                          price_block.Text = ""; price.Visibility = Visibility.Visible;
            stock.Content = ""; stock.Visibility = Visibility.Visible;
            marketing.Content = ""; marketing.Visibility = Visibility.Visible;
            original_price_block.Text = ""; original_price.Visibility = Visibility.Visible;         
        }

        private void detail_button_Click(object sender, RoutedEventArgs e)
        {
            product_detail_needed(med);
        }

        private void order_button_Click(object sender, RoutedEventArgs e)
        {
            product_ordered(this);

        }

        public BitmapImage get_image_source()
        {
            if (!string.IsNullOrWhiteSpace(med.photo_path) && File.Exists(med.photo_path))
                try
                {
                    return new BitmapImage(new Uri(med.photo_path, UriKind.Absolute));
                }
                catch (Exception ex)
                {
                    ex.Data.Add("function", "get_image_source");
                    ex.Data.Add("path", med.photo_path);
                    ex.Data.Add("datetime", DateTime.Now);
                    error_handling.error_handler.send_email(ex, "get_image_source");

                    return  new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\pics\\medicine_default.jpg", UriKind.Absolute));
                }
            else
                return  new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\pics\\medicine_default.jpg", UriKind.Absolute));


        }

        private void image_click(object sender, RoutedEventArgs e)
        {
            if (detail_button.Visibility == Visibility.Visible)
            product_detail_needed(med);
        }
    }
}
