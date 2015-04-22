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

namespace SpriteGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class CanvasWithBitmap : Canvas
    {
        public CanvasWithBitmap()
        {
            _image = new BitmapImage(new Uri("C:/Users/adrian.caple/Documents/GitHub/CPF/SpriteGenerator/SpriteGenerator/images/test.png"));
        }
        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawImage(_image, new Rect(0,0,_image.PixelWidth, _image.PixelHeight));
        }
        public BitmapImage _image;
    }

    public class MyImage : Image
    {

        public double x { get; set; }
        public double y { get; set; }
    }

    public partial class MainWindow : Window
    {
        string fileName;
        List<MyImage> ImageList = new List<MyImage>();
        private CanvasPopUp myController = new CanvasPopUp();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Menu_New(object sender, RoutedEventArgs e)
        {
            canvasControl.Children.Clear();
            myController.Show();

            Console.WriteLine("NEWED");
        }

        private void Menu_Open(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("OPENED");
        }

        private void Menu_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("SAVED");
        }

        private void Menu_SaveAs(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("SAVEDAS");
        }

        private void Menu_Import(object sender, RoutedEventArgs e)
        {
            //create open dialog instance
            OpenFileDialog ODlog = new OpenFileDialog();
            //set filter options
            ODlog.Filter = "All Files (*.*)| *.*";
            ODlog.FilterIndex = 1;
            ODlog.Multiselect = true;
            //call show dialog if clicked ok
            bool? userClickOk = ODlog.ShowDialog();
            //check and process if clicked
            if (userClickOk == true)
            {
                //System.IO.Stream fileStream = new System.IO.FileStream(ODlog.FileName, System.IO.FileMode.Open);
                fileName = ODlog.FileName;
            }
            Console.WriteLine("IMPORTED");
        }

        private void Menu_Exit(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("EXITED");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //create open dialog instance
            OpenFileDialog ODlog = new OpenFileDialog();
            //set filter options
            ODlog.Filter = "All Files (*.*)| *.*";
            ODlog.FilterIndex = 1;
            ODlog.Multiselect = true;
            //call show dialog if clicked ok
            bool? userClickOk = ODlog.ShowDialog();
            //check and process if clicked
            if(userClickOk == true)
            {
                //System.IO.Stream fileStream = new System.IO.FileStream(ODlog.FileName, System.IO.FileMode.Open);
                string fileName = ODlog.FileName; 
            }
        }

        private void Click_Picture(object sender, RoutedEventArgs e)
        {
            //BitmapImage bmp = new BitmapImage(new Uri("C:/Users/adrian.caple/Documents/GitHub/CPF/SpriteGenerator/SpriteGenerator/images/test.png"));
           if(fileName != null)
           {
               BitmapImage _image = new BitmapImage(new Uri(fileName));
               MyImage _myImage = new MyImage();

               if (ImageList.Count() == 0)
               {
                   _myImage.x = _myImage.y = 0;
               }
               else
               {
                   _myImage.x = ImageList.Last().x + ImageList.Last().Width;
                   _myImage.y = ImageList.Last().y;
                   if (_myImage.x > 1000)
                   {
                       _myImage.x = 0;
                       _myImage.y += ImageList.Last().Height;
                   }
               }
               _myImage.Source = _image;
               _myImage.Width = _image.Width;
               _myImage.Height = _image.Height;
               ImageList.Add(_myImage);

               Canvas.SetTop(_myImage, _myImage.y);
               Canvas.SetLeft(_myImage, _myImage.x);
               canvasControl.Children.Add(_myImage);
           }
           
        }
    }
}
