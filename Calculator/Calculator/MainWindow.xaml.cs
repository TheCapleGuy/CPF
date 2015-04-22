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
        bool StartCalculation;
        string addHistory;
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

            if (numberValue != " ")
            {
                secNum = Convert.ToInt32(numberValue);
                if (mathOperation == MathState.ADDITION)
                {
                    addHistory = firstNum.ToString() + " + " +  secNum.ToString();

                    answer = firstNum + secNum;
                    numberValue = answer.ToString();
                    calcDisplay.Text = numberValue;
                    addHistory += " = " + answer;
                }
                else if (mathOperation == MathState.SUBTRACTION)
                {
                    addHistory = firstNum.ToString() + " - " + secNum.ToString();

                    answer = firstNum - secNum;
                    numberValue = answer.ToString();
                    calcDisplay.Text = numberValue;
                    addHistory += " = " + answer;
                }
                else if (mathOperation == MathState.MULTIPLICATION)
                {
                    addHistory = firstNum.ToString() + " * " + secNum.ToString();

                    answer = firstNum * secNum;
                    numberValue = answer.ToString();
                    calcDisplay.Text = numberValue;
                    addHistory += " = " + answer;
                }
                else if (mathOperation == MathState.DIVISION)
                {
                    //divide by zero catch
                    try
                    {
                        answer = firstNum / secNum;
                    }
                    catch (System.DivideByZeroException)
                    {
                        Console.WriteLine("Fuck you terry");
                        answer = 0;
                    }
                    //print to history log 
                    addHistory = firstNum.ToString() + " / " + secNum.ToString();

                    //print to text for calc
                    numberValue = answer.ToString();
                    calcDisplay.Text = numberValue;
                    addHistory += " = " + answer;
                }
                StartCalculation = true;
                History.Text += addHistory + "\n";
            }
            else
            {
                 calcDisplay.Text = numberValue;
                 History.Text = addHistory;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 1;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 2;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 3;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 4;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 5;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 6;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 7;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 8;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 9;
            calcDisplay.Text = numberValue.ToString();
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if (StartCalculation == true)
            {
                numberValue = " ";
                calcDisplay.Text = numberValue;
                StartCalculation = false;
            }
            numberValue += 0;
            calcDisplay.Text = numberValue.ToString();
        }
    }
}

//if i want to ad ISBN excersice to calculator

//public class ISBN
//{
//    public bool ISBNValidation(string ISBNCode)
//    {
//        List<int> ISBNResult = new List<int> { };
//        int i = 10;
//        int combinedResult = 0;
//        //multiply all ISBN values by 10 - i
//        foreach (char ch in ISBNCode)
//        {
//            int ISBNNumber = Convert.ToInt32(ch);
//            ISBNNumber *= 10 - i;
//            i--;
//            ISBNResult.Add(ISBNNumber);
//        }
//        // add all numbers together and divide by 11
//        for (int j = 0; j < ISBNResult.Count; j++)
//        {
//            combinedResult += ISBNResult[j];
//        }
//        if ((combinedResult / 11) % 1 == 0)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//}
