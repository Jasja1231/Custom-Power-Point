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



            Create_Bit(canvas);

        }


        public int Create_Bit(Base_slide canvas)
        {
          //if (this.Initialized())
            this.Measure(new Size(this.Width, this.Height));
            this.Arrange(new Rect(new Size(this.Width, this.Height)));

            RenderTargetBitmap bmp = new RenderTargetBitmap(550, 400, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(this);

            var encoder = new PngBitmapEncoder();
          //  using (Stream stm = File.Create("test.png")) encoder.Save(stm);

            IntPtr hBitmap = bmp.GetHbitmap();

            //Convert Bitmap To Image
            Image myim = new Image();
            myim.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            Canvas
            mycanvas.Children.Clear();
            RemoveLogicalChild(MyImg);
            mycanvas.Children.Add(MyImg);

          
            return 1;
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
 

    }
}
