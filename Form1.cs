using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Operation = "";
        private float Result = 0;
        private float Number1 = 0;
        private float Number2 = 0;
        private bool IsFirstNumber = true;

        private float CalculationResult(string Operation, float Number1, float Number2)
        {
            float Result = 0;

            switch (Operation)
            {
                case "+":
                    Result = Number1 + Number2;
                    break;

                case "-":
                    Result = Number1 - Number2;
                    break;

                case "x":
                    Result = Number1 * Number2;
                    break;

                case "/":
                    Result = Number1 / Number2;
                    break;

                case "%":
                    Result = Number1 % Number2;
                    break;

                default:
                    break;
            }

            return Result;
        }

        private void Reset()
        {
            lblResult.Text = "0";
            txtOperation.Clear();
            Number1 = 0;
            Number2 = 0;
            Result = 0;
            Operation = "";
            IsFirstNumber = true;
        }

        private void NumberHandiling(Button Numberbutton)
        {
            txtOperation.Text += Numberbutton.Text;

            if (IsFirstNumber)
            {
                Number1 = Number1 * 10 + Convert.ToSingle(Numberbutton.Text);
            }

            else if (!IsFirstNumber)
            {
                Number2 = Number2 * 10 + Convert.ToSingle(Numberbutton.Text);
            }

        }

        private void SympolsHandiling(Button Sympolbutton)
        {
            if (IsFirstNumber
           && !string.IsNullOrWhiteSpace(txtOperation.Text)
           && !(txtOperation.Text.Contains("+")
           || txtOperation.Text.Contains("-")
           || txtOperation.Text.Contains("/")
           || txtOperation.Text.Contains("x")
           || txtOperation.Text.Contains("%")))
            {
                txtOperation.Text += Sympolbutton.Text;

                IsFirstNumber = false;
                Operation = Sympolbutton.Text;

            }

            else
            {
                return;
            }
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            Reset();
        }

        private void Numberbtn_Click(object sender, System.EventArgs e)
        {
            NumberHandiling((Button)sender);
        }

        private void Operationbtn_Click(object sender, System.EventArgs e)
        {
            SympolsHandiling((Button)sender);

        }

        private void btnEqual_Click(object sender, System.EventArgs e)
        {
            Result = CalculationResult(Operation, Number1, Number2);

            lblResult.Text = Result.ToString();
        }
    }
}
