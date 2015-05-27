using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;


namespace WPFLAB6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        Random rand = new Random();
        List<UserControl> list = new List<UserControl>();
        List<UserControl> present_list = new List<UserControl>();

        private int position = 0;

        static SolidColorBrush black_brush = new SolidColorBrush(System.Windows.Media.Colors.Black);
        static SolidColorBrush white_brush = new SolidColorBrush(System.Windows.Media.Colors.White);

        private double slide_width = 550;
        private double slide_heigh = 400;

        Viewbox box = new Viewbox();

        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            box.Visibility = Visibility.Hidden;

        }


        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                //for minimizing window after presentgation mode 
                if (e.Key == Key.Escape)
                {

                    this.WindowState = System.Windows.WindowState.Normal;
                    this.WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
                    this.menu_panel.Visibility = System.Windows.Visibility.Visible;
                    scrollView.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                    this.Background = white_brush;
                    this.Cursor = Cursors.Arrow;

                    this.stack.Children.Clear();


                    foreach (UserControl c in present_list)
                    {
                        c.Height = 400;
                        c.Width = 550;

                        c.IsHitTestVisible = true;
                        this.stack.Children.Add(c);
                    }
                    present_list.Clear();
                }
            

                if (e.Key == Key.Left)
                {
                    if (position > 0)
                    {
                        stack.Children.Clear();
                        stack.Children.Add(present_list.ElementAt(--position));
                    }

                }

                if (e.Key == Key.Right) {
                    if (position < present_list.Count-1) { 
                        stack.Children.Clear();
                        stack.Children.Add(present_list.ElementAt(++position));
                    }
                    else 
                        if(position == present_list.Count-1){
                                this.WindowState = System.Windows.WindowState.Normal;
                                this.WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
                                this.menu_panel.Visibility = System.Windows.Visibility.Visible;
                                scrollView.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                                this.Background = white_brush;
                                this.Cursor = Cursors.Arrow;

                            this.stack.Children.Clear();


                            foreach (UserControl c in present_list)
                            {
                                c.Height = 400;
                                c.Width = 550;

                                c.IsHitTestVisible = true;
                                this.stack.Children.Add(c);
                            }
                            present_list.Clear();
                            position = 0;
                        }
                  }
            }

        }
        //Create list of all user controls ready to present

        private void showPresent_Click(object sender, RoutedEventArgs e)
        {
            if (list.Count == 0)
            {
                MessageBoxResult error = MessageBox.Show("No slides to show");
            }
            else {
             //   this.stack.Height = System.Windows.SystemParameters.FullPrimaryScreenHeight;
                this.WindowState = System.Windows.WindowState.Maximized;
                this.WindowStyle = System.Windows.WindowStyle.None;

                this.menu_panel.Visibility = System.Windows.Visibility.Collapsed;
                this.Background = black_brush;

                this.Cursor = Cursors.None;
                
                //get numb canvases to show from userControl in the list
               /* UserControl can = list[0];

                can.Background = new SolidColorBrush(System.Windows.Media.Colors.Yellow) ;
                can.MaxHeight = this.Height;
                can.MaxWidth = this.Width /1.5;
                can.Height = this.Height;
                can.Width = this.Width/1.5;

                this.stack.Children.Add(can);
                */
                foreach (UserControl c in stack.Children)
                {

                    present_list.Add(c);
                    c.MaxHeight = this.Height;
                    c.MaxWidth = this.Width/2;
          //c.Margin = new Thickness(0,0,0,0);
                    c.Height = this.Height;
                    c.Width = this.Width/2;

                    c.Margin = new Thickness(0,0,0,0);

                    c.IsHitTestVisible = false;
                    scrollView.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                }
                
               this.stack.Children.Clear();
               this.stack.Children.Add(present_list.ElementAt(0));

                
            }
        }

        private void NewPresent_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            this.stack.Children.Clear();
        }

        
        //Get random integer custed to byte
        private byte GRB()
        {
            int ret = rand.Next(255);
            return (byte)ret;
        }


        private void Base_slide_Click(object sender, RoutedEventArgs e)
        {
            if (this.scrollView == null)
            {
                return;
            }
             Base_slide canvas = new Base_slide();
            canvas.canvas_height(slide_heigh);
            canvas.canvas_width(slide_width);
            canvas.set_canvas_back(GRB(),GRB(),GRB());
            //list of user controls for slides
            list.Add(canvas);
            this.stack.Children.Add(canvas);
        }

        private void Text_slide_Click(object sender, RoutedEventArgs e)
        {
            if (this.scrollView == null)
            {
                return;
            }
            Text_slide canvas = new Text_slide();
            canvas.canvas_height(slide_heigh);
            canvas.canvas_width(slide_width);
            canvas.set_canvas_back(GRB(), GRB(), GRB());
            //list of user controls for slides
            list.Add(canvas);
            this.stack.Children.Add(canvas);
        }

        private void Title_slide_Click(object sender, RoutedEventArgs e)
        {
            if (this.scrollView == null)
            {
                return;
            }
            Title_slide canvas = new Title_slide();
            canvas.canvas_height(slide_heigh);
            canvas.canvas_width(slide_width);
            canvas.set_canvas_back(GRB(), GRB(), GRB());
            //list of user controls for slides
            list.Add(canvas);
            this.stack.Children.Add(canvas);
        }

        private void Picture_slide_Click(object sender, RoutedEventArgs e)
        {
            if (this.scrollView == null)
            {
                return;
            }
            Picture_slide canvas = new Picture_slide();
            canvas.canvas_height(slide_heigh);
            canvas.canvas_width(slide_width);
            canvas.set_canvas_back(GRB(), GRB(), GRB());
            //list of user controls for slides
            list.Add(canvas);
            this.stack.Children.Add(canvas);
        }

        private void Presentation_Click(object sender, RoutedEventArgs e)
        {
            //nothing
        }



    }
}
