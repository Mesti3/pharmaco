using pharmaco.components.filter;
using pharmaco.components.medicine_components;
using pharmaco.components.search;
using pharmaco.data;
using pharmaco.model;
using pharmaco.pages.shopping_window;
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
        private shopping_window shopping_window;
        private BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
            data = new DataController();
            categories = new List<category>();
            shopping_window = new shopping_window();
            shopping_window.order_confirmed += Shopping_window_order_confirmed;
            shopping_window.show_detail += Shopping_window_show_detail;
            shopping_window.order_canceled += Shopping_window_order_canceled; 
        }

        private void Shopping_window_order_canceled()
        {
            load_main_page_products();
        }

        private void Shopping_window_show_detail(orderItem_with_image obj)
        {
            F_product_detail_needed(obj.med);
        }

        private void Shopping_window_order_confirmed(order order)
        {
            try
            {
                string tag = data.SaveOrder(order);
                MessageBox.Show(@"tvoje čislo je" + Environment.NewLine + tag + Environment.NewLine);
                // print tag
            }
            catch (Exception ex)
            {
                //hlaska
                //email o chybe
            }
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

        private void F_product_ordered(filter obj)
        {
            shopping_window.order_items.Add(new orderItem_with_image() { med = obj.med, quantity = 1, image_source = obj.get_image_source() });
            open_order_window();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = true;
            this.IsManipulationEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            searchBox.text_box_width = searchGrid.ActualWidth - searchButton.ActualWidth;
            load_categories();
            load_main_page_products();
            load_product_names();



            this.Cursor = Cursors.Arrow;

        }

        private void load_product_names()
        {
            try
            {
                var names = data.GetAllProductNames();
                searchBox.set_items(names);
                searchBox.list_max_height = (this.Height - 150) / 2;
            }
            catch (Exception ex)
            {
                //logovanie
            }
        }

        private void load_main_page_products()
        {
            try
            {
                searchBox.text = "";
                var medicines = data.GetMainPageProducts();
                FillWrapPanel(medicines);
                this.UpdateLayout();
            }
            catch (Exception ex)
            {
                //logovanie
            }
        }

        private void load_categories()
        {
            try
            {               
                categories = data.GetCategories();
            }
            catch (Exception ex)
            {
                //logovanie
                //hlásk
            }
         
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            do_search();
        }

        private void do_search()
        {
            if (!string.IsNullOrWhiteSpace(searchBox.text))
            {
                try
                {
                    this.Cursor = Cursors.Wait;
                    var medicines = data.GetMedicines(searchBox.text);
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

        private void medicine_dateil_product_ordered(filter obj)
        {
            shopping_window.order_items.Add(new orderItem_with_image() { med = obj.med, quantity = 1, image_source = obj.get_image_source() });
            open_order_window();
        }
        private void open_order_window()
        {
            shopping_window.ShowDialog();
        }

        private void searchBox_product_selected()
        {
            do_search();
        }
    }
}
