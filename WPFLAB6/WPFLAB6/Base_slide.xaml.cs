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
    /// Interaction logic for Base_slide.xaml
    /// </summary>
    public partial class Base_slide : UserControl
    {
        public Base_slide()
        {
            InitializeComponent();
            
        }

        public void set_canvas_back(byte R, byte G, byte B) {
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, R, G, B));
            canvas.Background = brush;
        }

        public void canvas_height(double height){
            canvas.Height    = height;
            canvas.MaxHeight = height;
            canvas.MinHeight = height;
        }

        public void canvas_width(double width){
            canvas.Width    = width;
            canvas.MaxWidth = width;
            canvas.MinWidth = width;
        }

        public int Create_Bit() {
            

            if (this.Initialized())
            this.Measure(new Size(this.Width,this.Height));
            this.Arrange(new Rect(new Size(this.Width, this.Height)));

            RenderTargetBitmap bmp = new RenderTargetBitmap(550, 400, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(this);

            var encoder = new PngBitmapEncoder();
            using (Stream stm = File.Create(@"c:\test.png"))encoder.Save(stm);
            return 1;
         }
    }
}
