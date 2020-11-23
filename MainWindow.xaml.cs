using pharmaco.components.filter;
using pharmaco.components.medicine_components;
using pharmaco.components.search;
using pharmaco.data;
using pharmaco.model;
using pharmaco.objects;
using pharmaco.pages.message_box;
using pharmaco.pages.shopping_window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace pharmaco
{
    public partial class MainWindow : Window
    {
        private List<category> categories;
        private DataController data;
        private shopping_window shopping_window;
        private BackgroundWorker worker;
        private double filter_height;
        private double filter_left_margin;
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
                message_box.show_dialog(@"tvoje čislo je" + Environment.NewLine + tag + Environment.NewLine, MessageBoxButton.OK);
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
                marketing_panel.Visibility = Visibility.Collapsed;
                wrapPanel.Children.Clear();
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
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
                        Border b = new Border() { Width = filter_left_margin, Height = filter_height, BorderThickness = new Thickness(1), BorderBrush = new SolidColorBrush(Colors.Gray) };
             
                        Viewbox wb = new Viewbox() { Stretch = System.Windows.Media.Stretch.Uniform, Width = filter_left_margin, Height = filter_height };
                   
                        f = new filter(m);
                        f.product_ordered += F_product_ordered;
                        f.product_detail_needed += F_product_detail_needed;
                        wb.Child = f;
                        b.Child = wb;
         //f.Margin = new Thickness( filter_left_margin, 0 , filter_left_margin,0);
         // f.Width = wrapPanel.ActualWidth / 5;

         wrapPanel.Children.Add(b);
                    }
                }
             //   wrapPanel.UpdateLayout();
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

            searchBox.text_box_width = searchGrid.ActualWidth - searchButton.ActualWidth - 2*leftPanel.Width - 35;
            set_size_of_medicines();
            load_categories();
            load_main_page_products();
            load_product_names();
            load_marketing();
           


            this.Cursor = Cursors.Arrow;

        }

        private void set_size_of_medicines()
        {
            filter f = new filter();
            filter_height = f.Height;
            double f_height = center_grid.ActualHeight - center_grid.Margin.Top - center_grid.Margin.Bottom;
            double ratio = 1;
            if (f_height < 2 * filter_height)
            {
                filter_height = f_height / 2;
                ratio =  filter_height/ f.Height;
            }

            filter_left_margin= (center_grid.ActualWidth - 38) / Math.Truncate( (center_grid.ActualWidth -38)/ (f.Width*ratio))  ;//18 is default scrollbar width

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
                //MenuItem mi = new MenuItem();
                //mi.Header = "Kategórie";
                //mi.FontSize = 50;
                //mi.Height = 100;
                //mi.Background = (Brush)(new BrushConverter().ConvertFrom("#FF16ED19"));
                //mi.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#FF109912"));
                //mi.BorderThickness = new Thickness(2);
                categories = data.GetCategories();
               // horizontal_category_panel.set_categories(categories);
            //    categories.ForEach(x => mi.Items.Add(createCategoryItem(x)));
                categories_menu.set_items(categories);
            }
            catch (Exception ex)
            {
                //logovanie
                //hlásk
            }         
        }
     
        private void load_marketing()
        {
            try
            {
                List<marketing_with_image> m =  data.GetMarketing().Select(x=>new marketing_with_image(x)).ToList();
                if (m.Count > 0)
                {
                    if (m.Count == 1)
                    {
                        leftPanel.set_marketing(m);
                        rightPanel.set_marketing(m);
                    }
                    else
                    {
                        leftPanel.set_marketing(m.Take(m.Count/2).ToList());
                        rightPanel.set_marketing(m.Except(m.Take(m.Count / 2)).ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                //logovanie
                //hlásk
            }

        }

        private MenuItem createCategoryItem(category x)
        {
            MenuItem mi = new MenuItem();
            mi.Header = x.name;
            mi.Tag = x.id;
            mi.FontSize = 30;
            mi.Background = Brushes.White;
            mi.Click += category_menu_Click;
            if (x.subcategories != null)
                foreach (category c in x.subcategories)
                    mi.Items.Add(createCategoryItem(c));
            return mi;
        }

        private void category_menu_Click(object sender, RoutedEventArgs e)
        {
            var t = (sender as MenuItem).Tag;
            if (t != null)
            {
                searchBox.text = "";
                List<string> ids = category_extension.find_subcategories_ids(categories, t.ToString());
                List<medicine> medicines = data.GetMedicinesInCategory(ids);
                FillWrapPanel(medicines);
                this.UpdateLayout();
            }
            e.Handled = true;
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

        private void categories_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shopping_cart_button_Click(object sender, RoutedEventArgs e)
        {
            open_order_window();
        }

        private void leftPanel_marketing_needed(objects.marketing_with_image obj)
        {
            try
            {
                marketing_panel.set_marketing(obj);

                searchBox.text = "";
                var medicines = data.GetProductsForMarketing(obj.marketing.id);
                FillWrapPanel(medicines);
                this.UpdateLayout();
                marketing_panel.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                //logovanie
            }
        }

        private void categories_menu_item_selected(category obj)
        {
            if (obj != null)
            {
                searchBox.text = "";
                List<string> ids = category_extension.find_subcategories_ids(obj);
                List<medicine> medicines = data.GetMedicinesInCategory(ids);
                FillWrapPanel(medicines);
                this.UpdateLayout();
            }
        }
    }
}
