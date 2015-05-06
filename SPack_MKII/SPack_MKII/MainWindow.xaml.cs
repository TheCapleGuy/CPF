using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace SPack_MKII
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] fNames;
        SpritePacker SPacker = new SpritePacker();
        int imagePreview = 0;
        public MainWindow()
        {
            InitializeComponent();
            canvasControl.MaxWidth = 800;
        }
        private void Menu_New(object sender, RoutedEventArgs e)
        {
            canvasControl.Children.Clear();
            Console.WriteLine("NEWED");
        }
        private void Menu_Open(object sender, RoutedEventArgs e)
        {
            Menu_Import(sender, e);
            Console.WriteLine("OPENED");
        }
        private void Menu_Save(object sender, RoutedEventArgs e)
        {
            string name = GetDialogName();
            SPacker.SaveFileName(name, canvasControl);
            SPacker.SaveToXML(name);
        }
        private void Menu_Import(object sender, RoutedEventArgs e)
        {
            fNames = SPacker.GetFileNames();
            ImagePreviewName.Text = fNames[imagePreview];
            try
            {
                ImagePreview.Source = new BitmapImage(new Uri(fNames[imagePreview]));
            }
            catch(System.NotSupportedException)
            {
                Console.WriteLine("Please load a real image");
            }
        }
        private void Menu_Exit(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("EXITED");
            System.Environment.Exit(1);
        }
        private void MaxWidthBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //needs exceptions here
            if (null != canvasControl)
            {
                canvasControl.MaxWidth = Convert.ToInt32(MaxWidthBox.Text);
            }
        }
        private void AddToCanvas_Click(object sender, RoutedEventArgs e)
        {
            MaxWidthBox.IsEnabled = false;
            for (int i = 0; i < fNames.Count(); i++ )
            {
                try
                {
                    SPacker.AddToCanvas(fNames[i], canvasControl);
                }
                catch (System.NotSupportedException)
                { 
                    Console.WriteLine("Please load a real image");
                }
            }
        }
        public string GetDialogName()
        {
            string path = "";
            //create open dialog instance
            SaveFileDialog SDlog = new SaveFileDialog();
            //set filter options
            SDlog.Filter = "PNG FILES (*.png*)| *.png*";
            SDlog.DefaultExt = ".png";
            SDlog.FilterIndex = 1;
            //call show dialog if clicked ok
            bool? userClickOk = SDlog.ShowDialog();
            //check and process if clicked
            if (userClickOk == true)
            {
                //System.IO.Stream fileStream = new System.IO.FileStream(ODlog.FileName, System.IO.FileMode.Open);
                path = SDlog.FileName;
            }
            return path;
        }
        private void rightArrow_Click(object sender, RoutedEventArgs e)
        {
            if(imagePreview + 1 < fNames.Count())
            {
                imagePreview++;
            }
            else
            {
                imagePreview = 0;
            }
            ImagePreviewName.Text = fNames[imagePreview];
            ImagePreview.Source = new BitmapImage(new Uri(fNames[imagePreview]));
        }
        private void leftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (imagePreview - 1 > 0)
            {
                imagePreview--;
            }
            else
            {
                imagePreview = fNames.Count() - 1;
            }
            ImagePreviewName.Text = fNames[imagePreview];
            ImagePreview.Source = new BitmapImage(new Uri(fNames[imagePreview]));
        }
    }
}
