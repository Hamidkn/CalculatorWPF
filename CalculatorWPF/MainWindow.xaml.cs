using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _firstNumber;
        private double _secondNumber;
        private double _result;
        private string _opt;
        private bool flag;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                txtCalculate.Clear();
                flag = false;
            }
            
            if (txtCalculate.Text == "0")
            {
                txtCalculate.Clear();
            }
            
            txtCalculate.Text += ((Button)sender).Content.ToString();
        }

        private void txtCalculate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCalculate.Text.Contains('.'))
            {
                btnDot.IsEnabled = false;
            }
            else
            {
                btnDot.IsEnabled = true;
            }

            btnBackSpace.IsEnabled = Convert.ToBoolean(txtCalculate.Text.Length);
        }

        private void btnNegate_Click(object sender, RoutedEventArgs e)
        {
            txtCalculate.Text = Convert.ToString(Convert.ToDouble(txtCalculate.Text) * -1);
        }

        private void Operators(object sender, RoutedEventArgs e)
        {
            if (_opt != null)
            {
                btnEqual_Click(null,null);
            }
            
            _firstNumber = Convert.ToDouble(txtCalculate.Text);
            _opt = ((Button)sender).Content.ToString();
            txtCalculateShow.Text = Convert.ToString(_firstNumber) + Convert.ToString(_opt);
            flag = true;
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            _secondNumber = Convert.ToDouble(txtCalculate.Text);
            switch (_opt)
            {
                case "+":
                    _result = _firstNumber + _secondNumber;
                    break;
                case "-":
                    _result = _firstNumber - _secondNumber;
                    break;
                case "*":
                    _result = _firstNumber * _secondNumber;
                    break;
                case "/":
                    _result = _firstNumber / _secondNumber;
                    break;
            }

            txtCalculate.Text = _result.ToString();
            txtCalculateShow.Text += Convert.ToString(_secondNumber) + "=" + _result.ToString();
            _opt = null;
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (txtCalculate.Text.Length > 0)
            {
                txtCalculate.Text = txtCalculate.Text.Remove(txtCalculate.Text.Length - 1);
            }

            if (!btnBackSpace.IsEnabled)
            {
                txtCalculate.Text = "0";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtCalculate.Text = "0";
        }

        private void btnClearc_Click(object sender, RoutedEventArgs e)
        {
            txtCalculate.Text = "0";
            txtCalculateShow.Text = "";
        }
    }
}
