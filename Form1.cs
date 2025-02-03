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

        private float Result = 0;
        private float Number1 = 0;
        private float Number2 = 0;
        private string Operation = "";
        private bool IsFirstNumber = true;
        private bool IsAfterTheComma = false;
        private byte FOrderAfterComma = 1;
        private byte LOrderAfterComma = 1;

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
            IsAfterTheComma = false;
        }

        private void NumberHandiling(Button Numberbutton)
        {
            txtOperation.Text += Numberbutton.Text;

            if (IsFirstNumber && !IsAfterTheComma)
            {
                Number1 = Number1 * 10 + Convert.ToSingle(Numberbutton.Text);
            }

            else if (IsFirstNumber && IsAfterTheComma)
            {
                FOrderAfterComma *= 10;
                Number1 += (Convert.ToSingle(Numberbutton.Text) / (FOrderAfterComma));
            }

            else if (!IsFirstNumber && IsAfterTheComma)
            {
                LOrderAfterComma *= 10;
                Number2 += (Convert.ToSingle(Numberbutton.Text) / (LOrderAfterComma));
            }

            else if (!IsFirstNumber && !IsAfterTheComma)
            {
                Number2 = Number2 * 10 + Convert.ToSingle(Numberbutton.Text);
            }
        }

        private void SympolsHandiling(Button Sympolbutton)
        {
            if (Sympolbutton.Text == ",")
            {
                if (IsFirstNumber
               && !string.IsNullOrWhiteSpace(txtOperation.Text)
               && !(txtOperation.Text.Contains("+")
               || txtOperation.Text.Contains("-")
               || txtOperation.Text.Contains("/")
               || txtOperation.Text.Contains("x")
               || txtOperation.Text.Contains("%")))
                {
                    txtOperation.Text += btnComma.Text;
                    IsAfterTheComma = true;
                }
            }

            else
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
                    IsAfterTheComma = false;

                }

                else if (IsAfterTheComma)
                {
                    IsAfterTheComma = false;
                }

                else
                {
                    IsAfterTheComma = false;
                    return;
                }
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

        private void Commabtn_Click(object sender, EventArgs e)
        {
            SympolsHandiling((Button)sender);
        }
    }
}
