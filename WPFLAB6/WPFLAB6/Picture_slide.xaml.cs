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
using Microsoft.Win32;


namespace WPFLAB6
{
    /// <summary>
    /// Interaction logic for Picture_slide.xaml
    /// </summary>
    public partial class Picture_slide : UserControl
    {
       

        public Picture_slide()
        {
            InitializeComponent();
        }

        public void set_canvas_back(byte R, byte G, byte B)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, R, G, B));
            canvas.Background = titleBox.Background = brush;
        }


        public void removeframes()
        {
            this.titleBox.BorderThickness = new Thickness(0);
            //image.Focusable = false;
            this.titleBox.Focusable = false;
        }


        public void canvas_height(double height)
        {
            this.Height = height;

        }

        public void canvas_width(double width)
        {
            this.Width = width;
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg";
                if (op.ShowDialog() == true)
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();


                    //bitmap.UriSource = new Uri(op.FileName);
                    

                    
                    vb.Name = "picture";
                    vb.MaxHeight = 310;
                    vb.Width = this.Width;
                    vb.SetValue(Canvas.TopProperty, 70.00);

                    Image image = new Image();
                    image.SetValue(Canvas.ZIndexProperty, 10);
                    image.Source = new BitmapImage(new Uri(op.FileName, UriKind.Absolute));
                    //bitmap.EndInit();

                   


                    vb.Child = image;
                    vb.Margin = new Thickness(-10) ;
                    //this.canvas.Children.Add(vb);
                }
            }

        }
    }
}
