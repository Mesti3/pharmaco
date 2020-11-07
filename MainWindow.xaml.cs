using pharmaco.components.filter;
using pharmaco.components.medicine_components;
using pharmaco.data;
using pharmaco.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace pharmaco
{
    public partial class MainWindow : Window
    {
        private List<category> categories;
        private DataController data;
        private List<orderItem> order_items;
        private BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
            data = new DataController();
            categories = new List<category>();
            order_items = new List<orderItem>();
        }

        private void FillWrapPanel(List<medicine> medicines)
        {
            filter f;
            try
            {
                wrapPanel.Children.Clear();
                if (medicines.Count == 0)
                {
                    wrapPanel.Children.Add(new Image() { 
                        Source = new BitmapImage(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\pics\\not_found.jpg", UriKind.Absolute)), 
                        Margin = new Thickness(20) , Width = 200, Height = 150});
                }
                else
                {
                    foreach (medicine m in medicines)
                    {
                        f = new filter(m);
                        f.product_ordered += F_product_ordered;
                        f.product_detail_needed += F_product_detail_needed;
                      //  f.Width = wrapPanel.ActualWidth / 5;
                        
                        wrapPanel.Children.Add(f);
                    }
                }
                wrapPanel.UpdateLayout();
            }
            catch (Exception ex)
            { 
            }
        }

        private void F_product_detail_needed(medicine obj)
        {
            medicine_dateil.FillMedicine(obj);
            medicine_dateil.Visibility = Visibility.Visible;
            wrapPanel.Visibility = Visibility.Collapsed;           
        }

        private void F_product_ordered(medicine obj)
        {
            order_items.Add(new orderItem() { med = obj, quantity = 1 });
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = true;
            this.IsManipulationEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                categories = data.GetCategories();
            }
            catch (Exception ex)
            {
                //logovanie
                //hlásk
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }




        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textbox.Text))
            {
                try
                {
                    this.Cursor = Cursors.Wait;
                    var medicines = data.GetMedicines(textbox.Text);
                    FillWrapPanel(medicines);
                    this.UpdateLayout();
                }
                catch (Exception ex)
                {
                    //logovanie
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void medicine_dateil_product_list_needed(medicine_detail obj)
        {
            wrapPanel.Visibility = Visibility.Visible;
            medicine_dateil.Visibility = Visibility.Collapsed;
        }

        private void medicine_dateil_product_ordered(medicine obj)
        {

        }
    }
}
