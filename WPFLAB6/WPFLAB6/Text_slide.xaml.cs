﻿using System;
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
    /// Interaction logic for Text_slide.xaml
    /// </summary>
    public partial class Text_slide : UserControl
    {
        public Text_slide()
        {
            InitializeComponent();
     

        }

        public void set_canvas_back(byte R, byte G, byte B)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, R, G, B));
            canvas.Background = textBox.Background = titleBox.Background = brush;
        }

        public void canvas_height(double height)
        {
            this.Height = height;

        }

        public void canvas_width(double width)
        {
            this.Width = width;
        }
    }
}
