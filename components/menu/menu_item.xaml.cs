using pharmaco.objects;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace pharmaco.components.menu
{
    /// <summary>
    /// Interaction logic for menu_item.xaml
    /// </summary>
    public partial class menu_item : UserControl
    {

        public event Action<menu_item_object> dots_button_clicked;
        public event Action<menu_item_object> item_selected;
        public event Action mouse_leave;
        private Brush hover_color;
        private bool child_is_opened;

        public Brush base_hover_color { get { return hover_color ?? Brushes.White; } set { hover_color = value; } }
        public double text_font_size { get { return block.FontSize; } set { block.FontSize = value; } }

        public menu_item_object data_object;
        private Timer timer;
        private bool mouse_button_pressed;
        public bool child_opened { get { return child_is_opened; }set { child_is_opened = value; if (value == false) { polygon.Fill = Brushes.White; dots_button.Background = Brushes.White; } } }
        public menu_item()
        {
            InitializeComponent();
            hover_color = new SolidColorBrush(Color.FromArgb(255, 208, 249, 189));
            child_is_opened = false;
            timer = new Timer();
            timer.Interval = 500;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
        }

        public menu_item(menu_item_object data_object)
            :this()
        {
            this.data_object = data_object;
            block.Content = data_object.text_to_show;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            mouse_button_pressed = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dots_button_clicked(data_object);
            child_is_opened = true;
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouse_button_pressed = true;
            timer.Start();
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (mouse_button_pressed)
                item_selected(data_object);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dots_button.Height = canvas.ActualHeight+2;
            if (data_object.items.Count>0)
                polygon.Points = new PointCollection(new List<Point>() { new Point(0,0), new Point( canvas.ActualWidth,0), new Point( canvas.ActualWidth + 20, canvas.ActualHeight / 2), new Point( canvas.ActualWidth, canvas.ActualHeight+1), new Point(0,canvas.ActualHeight+1) });
            else
                polygon.Points = new PointCollection(new List<Point>() { new Point(0, 0), new Point(this.ActualWidth , 0), new Point(this.ActualWidth, this.ActualHeight), new Point(0, this.ActualHeight) });
            this.UpdateLayout();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            polygon.Fill = hover_color;
            dots_button.Background = hover_color;
            this.UpdateLayout();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!child_is_opened)
            {
                polygon.Fill = Brushes.White;
                dots_button.Background = Brushes.White;
            }
            this.UpdateLayout();
            mouse_leave();
        }
    }
}
