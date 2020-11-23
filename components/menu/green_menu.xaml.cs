using pharmaco.objects;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace pharmaco.components.menu
{
    /// <summary>
    /// Interaction logic for green_menu.xaml
    /// </summary>
    public partial class green_menu : UserControl
    {
        public event Action<menu_item_object> item_selected;
       
        public green_menu()
        {
            InitializeComponent();
        }
        public void set_items(List<menu_item_object> items)
        {
            foreach (menu_item_object item in items)
            {
                menu_item mi = new menu_item(item);
                mi.dots_button_clicked += mi_dots_button_clicked;
                mi.item_selected += mi_item_selected;
                mi.mouse_leave += mi_mouse_leave;
                panel.Children.Add(mi);
            }
        }

        private void mi_mouse_leave()
        {
            if (!canvas_for_child.IsMouseOver)
            {
                delete_children();
                foreach (var p in panel.Children)
                {
                    if (!(p as menu_item).IsMouseOver)
                        (p as menu_item).child_opened = false;
                }
            }

        }

        private void mi_item_selected(menu_item_object obj)
        {
            item_selected(obj);
        }

        private void mi_dots_button_clicked(menu_item_object obj)
        {
            delete_children();
            if (obj.items.Count > 0)
            {
                green_menu gm = new green_menu();
                gm.set_items(obj.items);
                gm.item_selected += child_item_selected;
            
                //   gm.LostFocus += child_LostFocus;
                gm.MouseLeave += child_MouseLeave;
                gm.Margin = new System.Windows.Thickness(panel.ActualWidth,0,0,0);
                canvas_for_child.Children.Add(gm);
                UpdateLayout();
            }
        }

        private void child_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((sender as green_menu).canvas_for_child.Children.Count == 0)
            {
                delete_children();
            }
        }

        private void child_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            //if ((sender as green_menu).canvas_for_child.Children.Count == 0)
            //{
            //    delete_children();
            //}
        }

        private void child_item_selected(menu_item_object obj)
        {
            item_selected(obj);
        }

        private void ScrollViewer_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        //    delete_children();
        //    this.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void delete_children()
        {
            if (canvas_for_child.Children.Count > 0  )
            {
                (canvas_for_child.Children[0] as green_menu).delete_children(); 
            }
            canvas_for_child.Children.Clear();
            foreach (var p in panel.Children)
            {
                if (!(p as menu_item).IsMouseOver)
                    (p as menu_item).child_opened = false;
            }
        }

        private void ScrollViewer_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
