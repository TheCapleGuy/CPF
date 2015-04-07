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

namespace Calculator
{
    enum MathState
    {
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,
    };

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //bool lhs = true;
        string numberValue;
        MathState mathOperation;
        int firstNum, secNum, answer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Plus(object sender, RoutedEventArgs e)
        {
            if(numberValue != " ")
            {
                firstNum = Convert.ToInt32(numberValue);
            }
            numberValue = " ";
            calcDisplay.Text = numberValue;
            mathOperation = MathState.ADDITION;
        }
        private void Button_Minus(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToInt32(numberValue);
            numberValue = " ";
            calcDisplay.Text = numberValue;
            mathOperation = MathState.SUBTRACTION;
        }
        private void Button_Multiply(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToInt32(numberValue);
            numberValue = " ";
            calcDisplay.Text = numberValue;
            mathOperation = MathState.MULTIPLICATION;
        }
        private void Button_Divide(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToInt32(numberValue);
            numberValue = " ";
            calcDisplay.Text = numberValue;
            mathOperation = MathState.DIVISION;
        }
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            //firstNum = Convert.ToInt32(numberValue);
            numberValue = " ";
            calcDisplay.Text = numberValue;
            //mathOperation = MathState.DIVISION;
        }
        private void Button_Flip(object sender, RoutedEventArgs e)
        {
            //firstNum = Convert.ToInt32(numberValue);
            float test = Convert.ToInt32(numberValue);
            if(test > 0)
            {
                numberValue = "-" + numberValue;
            }
            else if(test < 0)
            {
               numberValue = numberValue.Substring(1);
            }
            calcDisplay.Text = numberValue;
            //mathOperation = MathState.DIVISION;
        }
        private void Button_Equals(object sender, RoutedEventArgs e)
        {
            secNum = Convert.ToInt32(numberValue);
            if (mathOperation == MathState.ADDITION)
            {
                answer = firstNum + secNum;
                numberValue = answer.ToString();
                calcDisplay.Text = numberValue;
            }
            else if (mathOperation == MathState.SUBTRACTION)
            {
                answer = firstNum - secNum;
                numberValue = answer.ToString();
                calcDisplay.Text = numberValue;
            }
            else if (mathOperation == MathState.MULTIPLICATION)
            {
                answer = firstNum * secNum;
                numberValue = answer.ToString();
                calcDisplay.Text = numberValue;
            }
            else if (mathOperation == MathState.DIVISION)
            {
                try
                {
                    answer = firstNum / secNum;
                }
                catch(System.DivideByZeroException)
                {
                    Console.WriteLine("Fuck you terry");
                    answer = 0;
                }
               //if(secNum != 0)
               //{
               //    answer = firstNum / secNum;
               //}
               //else
               //{
               //    Console.WriteLine("Fuck you terry");
               //}
               numberValue = answer.ToString();
               calcDisplay.Text = numberValue;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            numberValue += 1;
            calcDisplay.Text = numberValue.ToString();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            numberValue += 2;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            numberValue += 3;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            numberValue += 4;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            numberValue += 5;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            numberValue += 6;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            numberValue += 7;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            numberValue += 8;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            numberValue += 9;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            numberValue += 0;
            calcDisplay.Text = numberValue.ToString();
        }
    }
}
