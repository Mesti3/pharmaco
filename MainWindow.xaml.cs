using pharmaco.components.filter;
using pharmaco.components.medicine_components;
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
        private double filter_height;
        private double filter_left_margin;
        private int search_page_size = 20;
        private int worker_run;
        public MainWindow()
        {
            InitializeComponent();
            data = new DataController();
            categories = new List<category>();
            shopping_window = new shopping_window();
            shopping_window.order_confirmed += Shopping_window_order_confirmed;
            shopping_window.show_detail += Shopping_window_show_detail;
            shopping_window.order_canceled += Shopping_window_order_canceled;
            shopping_window.update_cart_info += shopping_window_update_cart_info;
            worker_run = 0;
        }

        private void shopping_window_update_cart_info(int obj)
        {
            set_cart(obj);
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
                message_box.show_dialog(@"Vaše číslo je" + Environment.NewLine + tag.PadLeft(9,' ') + Environment.NewLine, MessageBoxButton.OK);
                shopping_window.cancel_order();
                // print tag
            }
            catch (Exception ex)
            {
                //hlaska
                //email o chybe
            }
        }

        private void FillWrapPanel(List<medicine> medicines, bool clear_previous_result = true)
        {
            filter f;
            try
            {
                if (clear_previous_result)
                {
                    marketing_panel.Visibility = Visibility.Collapsed;
                    wrapPanel.Children.Clear();
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                }
                if (medicines.Count == 0)
                {
                    wrapPanel.Children.Add(new Image()
                    {
                        Source = new BitmapImage(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\pics\\not_found.jpg", UriKind.Absolute)),
                        Margin = new Thickness(20),
                        Width = 200,
                        Height = 150
                    });
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
                        wrapPanel.Children.Add(b);
                    }
                }
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
            shopping_window.add_to_order(new orderItem_with_image() { med = obj.med, quantity = 1, image_source = obj.get_image_source() });
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

            searchBox.text_box_width = searchGrid.ActualWidth - searchButton.ActualWidth - 2 * leftPanel.Width - 35;
            set_size_of_medicines();
            set_cart_info();
            load_categories();
            load_main_page_products();
            load_product_names();
            load_marketing();
            


            this.Cursor = Cursors.Arrow;
        }

        private void set_cart_info()
        {
            cart_label.MinWidth = cart_label.ActualHeight;
            cart_border.CornerRadius = new CornerRadius(cart_label.ActualHeight / 2);
            set_cart(0);
        }

        private void set_cart(int quantity)
        {
            cart_label.Content = quantity;
            if (quantity <= 0)
                cart.Visibility = Visibility.Collapsed;
            else
                cart.Visibility = Visibility.Visible;
            UpdateLayout();
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
                ratio = filter_height / f.Height;
            }

            filter_left_margin = (center_grid.ActualWidth - (20+20)) / Math.Truncate((center_grid.ActualWidth - (20 + 20)) / (f.Width * ratio));// (20+20) = magin + scrollbar width

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
            stop_worker();
            try
            {
                searchBox.text = "";
                var medicines = data.GetMainPageProducts(search_page_size,0);
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
                List<marketing_with_image> m = data.GetMarketing().Select(x => new marketing_with_image(x)).ToList();
                if (m.Count > 0)
                {
                    if (m.Count == 1)
                    {
                        leftPanel.set_marketing(m);
                        rightPanel.set_marketing(m);
                    }
                    else
                    {
                        leftPanel.set_marketing(m.Take(m.Count / 2).ToList());
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
            stop_worker();
            var t = (sender as MenuItem).Tag;
            if (t != null)
            {
                searchBox.text = "";
                List<string> ids = category_extension.find_subcategories_ids(categories, t.ToString());
                List<medicine> medicines = data.GetMedicinesInCategory(ids, search_page_size, 0);
                FillWrapPanel(medicines);
                this.UpdateLayout();
                if (medicines.Count == search_page_size)
                    search_by_worker(new worker_params(worker_run) { mode = search_mode_enum.category, category_ids = ids, count = search_page_size, offset = 1});
            }
            e.Handled = true;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            do_search();
        }

        private void do_search()
        {
            stop_worker();
            if (!string.IsNullOrWhiteSpace(searchBox.text))
            {
                try
                {
                    this.Cursor = Cursors.Wait;
                    var medicines = data.GetMedicines(searchBox.text, search_page_size, 0);
                    FillWrapPanel(medicines);
                    this.UpdateLayout();

                    if (medicines.Count == search_page_size)
                    {
                        search_by_worker(new worker_params(worker_run) { mode = search_mode_enum.name, name = searchBox.text, count = search_page_size, offset = 1 });
                        
                    }
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
            shopping_window.add_to_order(new orderItem_with_image() { med = obj.med, quantity = 1, image_source = obj.get_image_source() });
            open_order_window();
        }
        private void open_order_window()
        {
            shopping_window.ShowDialog();
            //set_cart(shopping_window.items_count);
        //}

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
            stop_worker();
            try
            {
                marketing_panel.set_marketing(obj);

                searchBox.text = "";
                var medicines = data.GetProductsForMarketing(obj.marketing.id, search_page_size,0);
                FillWrapPanel(medicines);
                this.UpdateLayout();
                marketing_panel.Visibility = Visibility.Visible;
                if (medicines.Count == search_page_size)
                    search_by_worker(new worker_params(worker_run) { mode = search_mode_enum.markering, marketing_id = obj.marketing.id ,count = search_page_size, offset = 1 }) ;

            }
            catch (Exception ex)
            {
                //logovanie
            }
        }

        private void categories_menu_item_selected(category obj)
        {
            stop_worker();
            if (obj != null)
            {
                searchBox.text = "";
                List<string> ids = category_extension.find_subcategories_ids(obj);
                List<medicine> medicines = data.GetMedicinesInCategory(ids, search_page_size, 0);
                FillWrapPanel(medicines);
                this.UpdateLayout();
                if (medicines.Count == search_page_size)
                    search_by_worker(new worker_params(worker_run) { mode = search_mode_enum.category, category_ids = ids, count = search_page_size, offset = 1 });
            }
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if ((e.Result as worker_result).input.worker_run == worker_run)
                {
                    if (e.Error != null)
                        throw e.Error;
                    if (!e.Cancelled)
                    {
                        if ((e.Result as worker_result).medicines.Count > 0)
                        {
                            FillWrapPanel((e.Result as worker_result).medicines, false);
                            this.UpdateLayout();
                        }

                        if ((e.Result as worker_result).medicines.Count == (e.Result as worker_result).input.count)
                        {
                            (sender as BackgroundWorker).RunWorkerAsync((e.Result as worker_result).input);
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if ((e.Argument as worker_params).worker_run == worker_run )
                {
                    switch ((e.Argument as worker_params).mode)
                    {
                        case search_mode_enum.category:
                            e.Result = new worker_result() { medicines = data.GetMedicinesInCategory((e.Argument as worker_params).category_ids, (e.Argument as worker_params).count, (e.Argument as worker_params).count * (e.Argument as worker_params).offset), input = (e.Argument as worker_params).AddOffsetAndReturn() }; break;
                        case search_mode_enum.name:
                            e.Result = new worker_result() { medicines = data.GetMedicines((e.Argument as worker_params).name, (e.Argument as worker_params).count, (e.Argument as worker_params).count * (e.Argument as worker_params).offset), input = (e.Argument as worker_params).AddOffsetAndReturn() }; break;
                        case search_mode_enum.markering:
                            e.Result = new worker_result() { medicines = data.GetProductsForMarketing((e.Argument as worker_params).marketing_id, (e.Argument as worker_params).count, (e.Argument as worker_params).count * (e.Argument as worker_params).offset), input = (e.Argument as worker_params).AddOffsetAndReturn() }; break;
                        case search_mode_enum.main_page:
                            e.Result = new worker_result() { medicines = data.GetMainPageProducts((e.Argument as worker_params).count, (e.Argument as worker_params).count * (e.Argument as worker_params).offset), input = (e.Argument as worker_params).AddOffsetAndReturn() }; break;

                    }

                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private void search_by_worker(worker_params worker_params)
        {
            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(worker_params);
        }
        private void stop_worker()
        {
            worker_run++;
        }


    }
}
