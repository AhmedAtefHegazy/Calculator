using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String Result = "0";
        private bool IsFirstNumber = true;

        private void Reset()
        {
            lblResult.Text = "0";
            txtOperation.Clear();

            Result = "0";
            IsFirstNumber = true;
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            Reset();
        }

        private void Numberbtn_Click(object sender, System.EventArgs e)
        {
            txtOperation.Text += ((Button)sender).Text;
        }

        private void Operationbtn_Click(object sender, System.EventArgs e)
        {
            txtOperation.Text += ((Button)sender).Text;
        }

        private void btnEqual_Click(object sender, System.EventArgs e)
        {
            DataTable table = new DataTable();

            string Equation = "";

            Equation = txtOperation.Text.Replace("x", "*");


            try
            {
                Result = Convert.ToString(table.Compute(Equation, ""));
                lblResult.Text = Result;

            }
            catch (Exception)
            {
                lblResult.Text = "Syntax Error";
            }

        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            txtOperation.Text = txtOperation.Text.Substring(0, txtOperation.Text.Length - 1);
        }
    }
}
