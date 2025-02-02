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
        private bool FirstNumber = true;

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

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            txtOperation.Clear();
        }

        private void txtOperation_TextChanged(object sender, System.EventArgs e)
        {
            Operation = ((Button)sender).Tag.ToString();

            Result = CalculationResult(Operation, Number1, Number2);
        }

        private void Numberbtn_Click(object sender, System.EventArgs e)
        {
            txtOperation.Text += ((Button)sender).Tag.ToString();

            if (FirstNumber)
            {
                Number1 += ((float)((Button)sender).Tag) * 10;
            }

            else
            {
                Number2 = ((float)((Button)sender).Tag) * 10;
            }

        }

        private void Operationbtn_Click(object sender, System.EventArgs e)
        {
            txtOperation.Text += ((Button)sender).Tag.ToString();

            FirstNumber = false;
            Operation = ((Button)sender).Tag.ToString();

        }

        private void btnEqual_Click(object sender, System.EventArgs e)
        {
            lblResult.Text = Result.ToString();
        }
    }
}
