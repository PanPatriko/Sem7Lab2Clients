using Lab2WpfClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Security;
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
            Calculator = new ComplexCalculatorClient("wsHttpBindingEndpoint");
            Calculator.ClientCredentials.UserName.UserName = UsernameTextBox.Text;
            Calculator.ClientCredentials.UserName.Password = PasswordBox.Password;
            Calculator.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
        }

        ComplexCalculatorClient Calculator;
        Complex complex;
        double ar, ai, br, bi;

        private async void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if(ParseTextBoxes())
            {
                try
                {
                    if (CbComplex.IsChecked ?? false)
                    {
                        Complex a = new Complex();
                        Complex b = new Complex();
                        a.Real = ar;
                        a.Imag = ai;
                        b.Real = br;
                        b.Imag = bi;
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex = await Calculator.AddComplexDataAsync(a, b);
                        }
                        else
                        {
                            complex = Calculator.AddComplexData(a, b);
                        }
                    }
                    else
                    {
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex =  await Calculator.AddDoubleDataAsync(ar, ai, br, bi);
                        }
                        else
                        {
                            complex = Calculator.AddDoubleData(ar, ai, br, bi);
                        }
                    }
                    TbResult.Text = ComplexToString(complex);
                }
                catch (System.ServiceModel.EndpointNotFoundException)
                {
                    MessageBox.Show("Serwis jest obecnie niedostępny");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                    }
                }
            }       
        }

        private async void BMul_Click(object sender, RoutedEventArgs e)
        {
            if (ParseTextBoxes())
            {
                try
                {
                    if (CbComplex.IsChecked ?? false)
                    {
                        Complex a = new Complex();
                        Complex b = new Complex();
                        a.Real = ar;
                        a.Imag = ai;
                        b.Real = br;
                        b.Imag = bi;
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex = await Calculator.MultiplyComplexDataAsync(a, b);
                        }
                        else
                        {
                            complex = Calculator.MultiplyComplexData(a, b);
                        }
                    }
                    else
                    {
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex = await Calculator.MultiplyDoubleDataAsync(ar, ai, br, bi);
                        }
                        else
                        {
                            complex = Calculator.MultiplyDoubleData(ar, ai, br, bi);
                        }
                    }
                    TbResult.Text = ComplexToString(complex);
                }
                catch (System.ServiceModel.EndpointNotFoundException)
                {
                    MessageBox.Show("Serwis jest obecnie niedostępny");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                    }
                }
            }
        }
        private async void BSub_Click(object sender, RoutedEventArgs e)
        {
            if (ParseTextBoxes())
            {
                try
                {
                    if (CbComplex.IsChecked ?? false)
                    {
                        Complex a = new Complex();
                        Complex b = new Complex();
                        a.Real = ar;
                        a.Imag = ai;
                        b.Real = br;
                        b.Imag = bi;
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex = await Calculator.SubstractComplexDataAsync(a, b);
                        }
                        else
                        {
                            complex = Calculator.SubstractComplexData(a, b);
                        }
                    }
                    else
                    {
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex = await Calculator.SubstractDoubleDataAsync(ar, ai, br, bi);
                        }
                        else
                        {
                            complex = Calculator.SubstractDoubleData(ar, ai, br, bi);
                        }
                    }
                    TbResult.Text = ComplexToString(complex);
                }
                catch (System.ServiceModel.EndpointNotFoundException)
                {
                    MessageBox.Show("Serwis jest obecnie niedostępny");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                    }
                }
            }
        }
        private async void BDiv_Click(object sender, RoutedEventArgs e)
        {
            if (ParseTextBoxes())
            {
                try
                {
                    if (CbComplex.IsChecked ?? false)
                    {
                        Complex a = new Complex();
                        Complex b = new Complex();
                        a.Real = ar;
                        a.Imag = ai;
                        b.Real = br;
                        b.Imag = bi;
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex = await Calculator.DivideComplexDataAsync(a, b);
                        }
                        else
                        {
                            complex = Calculator.DivideComplexData(a, b);
                        }
                    }
                    else
                    {
                        if (CbAsync.IsChecked ?? false)
                        {
                            complex = await Calculator.DivideDoubleDataAsync(ar, ai, br, bi);
                        }
                        else
                        {
                            complex = Calculator.DivideDoubleData(ar, ai, br, bi);
                        }
                    }
                    TbResult.Text = ComplexToString(complex);
                }
                catch (System.ServiceModel.EndpointNotFoundException ex )
                {
                    MessageBox.Show("Serwis jest obecnie niedostępny","", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (FaultException<ServiceReference1.DivideByZeroException> ex)
                {
                    MessageBox.Show(ex.Detail.Details + "\n" + "Dividient: " + ComplexToString(ex.Detail.Divident),ex.Detail.Message,MessageBoxButton.OK,MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                    }
                }
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

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = (sender as RadioButton).Content.ToString();
            Calculator = new ComplexCalculatorClient(endpoint);
            if(endpoint == "wsHttpBindingEndpoint")
            {
                Calculator.ClientCredentials.UserName.UserName = UsernameTextBox.Text;
                Calculator.ClientCredentials.UserName.Password = PasswordBox.Password;
                Calculator.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            }
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
