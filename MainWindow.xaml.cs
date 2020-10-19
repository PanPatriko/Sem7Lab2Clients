using Lab2WpfClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab2WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Calculator = new ComplexCalculatorClient();
        }

        ComplexCalculatorClient Calculator;
        Complex complex;
        double ar, ai, br, bi;

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if(ParseTextBoxes())
            {
                if(CbComplex.IsChecked??false)
                {
                    Complex a = new Complex();
                    Complex b = new Complex();
                    a.Real = ar;
                    a.Imag = ai;
                    b.Real = br;
                    b.Imag = bi;
                    complex = Calculator.AddComplexData(a,b);
                    if(CbAsync.IsChecked??false)
                    {
                        complex = Calculator.AddComplexDataAsync(a, b).Result;
                    }
                }
                else
                {
                    if (CbAsync.IsChecked ?? false)
                    {
                        complex = Calculator.AddDoubleDataAsync(ar, ai, br, bi).Result;
                    }
                    else
                    {
                        complex = Calculator.AddDoubleData(ar, ai, br, bi);
                    }
                }
                TbResult.Text = ComplexToString(complex);
            }       
        }

        private void BMul_Click(object sender, RoutedEventArgs e)
        {
            if (ParseTextBoxes())
            {
                if (CbComplex.IsChecked ?? false)
                {
                    Complex a = new Complex();
                    Complex b = new Complex();
                    a.Real = ar;
                    a.Imag = ai;
                    b.Real = br;
                    b.Imag = bi;
                    complex = Calculator.MultiplyComplexData(a, b);
                    if (CbAsync.IsChecked ?? false)
                    {
                        complex = Calculator.MultiplyComplexDataAsync(a, b).Result;
                    }
                }
                else
                {
                    if (CbAsync.IsChecked ?? false)
                    {
                        complex = Calculator.MultiplyDoubleDataAsync(ar, ai, br, bi).Result;
                    }
                    else
                    {
                        complex = Calculator.MultiplyDoubleData(ar, ai, br, bi);
                    }
                }
                TbResult.Text = ComplexToString(complex);
            }
        }
        private void BSub_Click(object sender, RoutedEventArgs e)
        {
            if (ParseTextBoxes())
            {
                if (CbComplex.IsChecked ?? false)
                {
                    Complex a = new Complex();
                    Complex b = new Complex();
                    a.Real = ar;
                    a.Imag = ai;
                    b.Real = br;
                    b.Imag = bi;
                    complex = Calculator.SubstractComplexData(a, b);
                    if (CbAsync.IsChecked ?? false)
                    {
                        complex = Calculator.SubstractComplexDataAsync(a, b).Result;
                    }
                }
                else
                {
                    if (CbAsync.IsChecked ?? false)
                    {
                        complex = Calculator.SubstractDoubleDataAsync(ar, ai, br, bi).Result;
                    }
                    else
                    {
                        complex = Calculator.SubstractDoubleData(ar, ai, br, bi);
                    }
                }
                TbResult.Text = ComplexToString(complex);
            }
        }
        private void BDiv_Click(object sender, RoutedEventArgs e)
        {
            if (ParseTextBoxes())
            {
                if (CbComplex.IsChecked ?? false)
                {
                    Complex a = new Complex();
                    Complex b = new Complex();
                    a.Real = ar;
                    a.Imag = ai;
                    b.Real = br;
                    b.Imag = bi;
                    complex = Calculator.DivideComplexData(a, b);
                    if (CbAsync.IsChecked ?? false)
                    {
                        complex = Calculator.DivideComplexDataAsync(a, b).Result;
                    }
                }
                else
                {
                    if (CbAsync.IsChecked ?? false)
                    {
                        complex = Calculator.DivideDoubleDataAsync(ar, ai, br, bi).Result;
                    }
                    else
                    {
                        complex = Calculator.DivideDoubleData(ar, ai, br, bi);
                    }
                }
                TbResult.Text = ComplexToString(complex);
            }
        }
        private void BCls_Click(object sender, RoutedEventArgs e)
        {
            TbR1.Text = "";
            TbR2.Text = "";
            TbI1.Text = "";
            TbI2.Text = "";
            TbResult.Text = "";
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            // Use SelectionStart property to find the caret position.
            // Insert the previewed text into the existing text in the textbox.
            var fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            double val;
            // If parsing is successful, set Handled to false
            e.Handled = !double.TryParse(fullText, out val);
        }

        private string ComplexToString(Complex complex)
        {
            if (complex.Imag == 0.0)
            {
                return complex.Real.ToString();
            }
            if (complex.Imag < 0.0)
            {
                return complex.Real.ToString() + " - "+ (complex.Imag *-1).ToString() + "i";
            }
            return complex.Real.ToString() + " + " + complex.Imag.ToString() + "i";
        }
        private bool ParseTextBoxes()
        {
            if (TbR1.Text != "" && TbI1.Text != "" && TbR2.Text != "" && TbI2.Text != "")
            {
                ar = Double.Parse(TbR1.Text);
                ai = Double.Parse(TbI1.Text);
                br = Double.Parse(TbR2.Text);
                bi = Double.Parse(TbI2.Text);
                return true;
            }
            else
            {
                MessageBox.Show("Pole nie może być puste");
                return false;
            }
        }
    }
}
