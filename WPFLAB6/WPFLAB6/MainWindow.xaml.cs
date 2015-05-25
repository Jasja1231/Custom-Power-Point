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


        private double slide_width = 550;
        private double slide_heigh = 400;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void showPresent_Click(object sender, RoutedEventArgs e)
        {
            if (list.Count == 0) {
                MessageBoxResult error = MessageBox.Show("No slides to show");  
            }
        }

        private void NewPresent_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            this.stack.Children.Clear();
        }

        private void Presentation_Click(object sender, RoutedEventArgs e)
        {
            //nothing
        }

        private void Base_slide_Click(object sender, RoutedEventArgs e)
        {
            if (this.scrollView == null)
            {
                return;
            }

            Picture_slide canvas = new Picture_slide();

            canvas.canvas_height(slide_heigh);
            canvas.canvas_width(slide_width);


            canvas.set_canvas_back(GRB(),GRB(),GRB());
            //list of user controls for slides
            list.Add(canvas);
            this.stack.Children.Add(canvas);
        }

        private byte GRB() { 
          int ret =  rand.Next(255);
          return (byte)ret;
        }
 

    }
}
