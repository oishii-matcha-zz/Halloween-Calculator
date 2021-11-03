using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpookySZNCalculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operatorPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button_click(object sender, EventArgs e)
        {
            if ((txtBox_Result.Text == "0") || (isOperationPerformed))
                txtBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!txtBox_Result.Text.Contains("."))
                    txtBox_Result.Text = txtBox_Result.Text + button.Text;
            }
            else
                txtBox_Result.Text = txtBox_Result.Text + button.Text;
            
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnEquals.PerformClick();
                operatorPerformed = button.Text;
                lblCurrentOperation.Text = resultValue + " " + operatorPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operatorPerformed = button.Text;
                resultValue = Double.Parse(txtBox_Result.Text);
                lblCurrentOperation.Text = resultValue + " " + operatorPerformed;
                isOperationPerformed = true;
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtBox_Result.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBox_Result.Text = "0";
            resultValue = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            switch(operatorPerformed)
            {
                case "+":
                    txtBox_Result.Text = (resultValue + Double.Parse(txtBox_Result.Text)).ToString();
                    break;
                case "-":
                    txtBox_Result.Text = (resultValue - Double.Parse(txtBox_Result.Text)).ToString();
                    break;
                case "*":
                    txtBox_Result.Text = (resultValue * Double.Parse(txtBox_Result.Text)).ToString();
                    break;
                case "/":
                    txtBox_Result.Text = (resultValue / Double.Parse(txtBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(txtBox_Result.Text);
            lblCurrentOperation.Text = "";
        }
    }
}
