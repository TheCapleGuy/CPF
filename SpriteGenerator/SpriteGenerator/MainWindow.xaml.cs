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
        public double X { get; set; }
        public double Y { get; set; }
        public int rowPos;
    }

    public partial class MainWindow : Window
    {
        string fileName;
        int currentRow = 0;
        string setMaxWidth = "";
        List<MyImage> ImageList = new List<MyImage>();
        private CanvasPopUp myPopUpController = new CanvasPopUp();

        public MainWindow()
        {
            InitializeComponent();
        }
        public void UpdateCanvasWidth()
        {
            canvasControl.MaxWidth = Convert.ToDouble(setMaxWidth);
            if (ImageList.Count() == 0)
            {
                canvasControl.Width = canvasControl.Height = 125;
            }
            else if (ImageList.Count() > 0)
            {
                //Set Canvas Width based off Width of ImageLists
                double totalImageWidth = 0;
                for (int i = 0; i < ImageList.Count(); i++)
                {
                    totalImageWidth += ImageList[i].Width;
                }
                canvasControl.Width = totalImageWidth;
            }
        }
        public int UpdateCanvasHeight(int cRow)
        {
            int heighestSoFar;
            if(ImageList.Count() == 0)
            {
                heighestSoFar = 125;
            }
            else
            {
                heighestSoFar = Convert.ToInt32(ImageList.First().Height);
                for (int i = 0; i < currentRow; i++)
                {
                    if (ImageList[i].rowPos == cRow && ImageList.First().Height > heighestSoFar)
                    {
                        heighestSoFar += Convert.ToInt32(ImageList.First().Height);
                    }
                }
            }

            return heighestSoFar;
        }

        private void Menu_New(object sender, RoutedEventArgs e)
        {
            canvasControl.Children.Clear();
            myPopUpController.Show();
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
            System.Environment.Exit(1);
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
                   _myImage.X = _myImage.Y = 0;
               }
               else if (ImageList.Count() == 1)
               {
                   int heightAdjust = UpdateCanvasHeight(currentRow);
                   canvasControl.Height = heightAdjust;
               }
               else
               {
                   _myImage.X = ImageList.Last().X + ImageList.Last().Width;
                   _myImage.Y = ImageList.Last().Y;
                   if (_myImage.X > canvasControl.MaxWidth)
                   {

                       _myImage.X = 0;
                       int heightAdjust = UpdateCanvasHeight(currentRow);
                       _myImage.Y += heightAdjust;
                       canvasControl.Height += heightAdjust;
                       currentRow++;
                   }
               }
               _myImage.Source = _image;
               _myImage.Width = _image.Width;
               _myImage.Height = _image.Height;
               _myImage.rowPos = currentRow;
               ImageList.Add(_myImage);

               Canvas.SetTop(_myImage, _myImage.Y);
               Canvas.SetLeft(_myImage, _myImage.X);
               canvasControl.Children.Add(_myImage);
               UpdateCanvasWidth();
           }
        }

        private void Width_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            setMaxWidth = Console.ReadLine();
            canvasControl.MaxWidth = Convert.ToDouble(setMaxWidth);
        }
    }
}
