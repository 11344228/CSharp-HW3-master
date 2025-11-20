using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       
        private double firstNumber = 0.0;
        
        private string operation = "";
        
        private bool isNewNumber = true;

        public Form1()
        {
            InitializeComponent();

           
            this.button1.Click += new System.EventHandler(this.NumberButton_Click);
            this.button2.Click += new System.EventHandler(this.NumberButton_Click);
            this.button3.Click += new System.EventHandler(this.NumberButton_Click);
            this.button4.Click += new System.EventHandler(this.NumberButton_Click);
            this.button5.Click += new System.EventHandler(this.NumberButton_Click);
            this.button6.Click += new System.EventHandler(this.NumberButton_Click);
            this.button7.Click += new System.EventHandler(this.NumberButton_Click);
            this.button8.Click += new System.EventHandler(this.NumberButton_Click);
            this.button9.Click += new System.EventHandler(this.NumberButton_Click);

            
            this.button10.Text = "0";
            this.button10.Click += new System.EventHandler(this.NumberButton_Click);

            this.button11.Click += new System.EventHandler(this.OperatorButton_Click); 
            this.button12.Click += new System.EventHandler(this.OperatorButton_Click);
            this.button13.Click += new System.EventHandler(this.OperatorButton_Click); 
            this.button14.Click += new System.EventHandler(this.OperatorButton_Click); 

            this.button16.Click += new System.EventHandler(this.ClearButton_Click); 
            
        }

        
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (isNewNumber || textBox1.Text == "0")
            {
                
                textBox1.Text = buttonText;
                isNewNumber = false;
            }
            else
            {
                
                textBox1.Text += buttonText;
            }
        }


        
        private void button15_Click(object sender, EventArgs e)
        {
            if (operation == "")
            {
                
                return;
            }

            
            if (double.TryParse(textBox1.Text, out double secondNumber))
            {
                double result = 0.0;

               
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("除數不能為零", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          
                            firstNumber = 0.0;
                            operation = "";
                            isNewNumber = true;
                            textBox1.Text = "0";
                            return;
                        }
                        break;
                }

              
                textBox1.Text = result.ToString();
              
                firstNumber = result;
              
                operation = "";
                isNewNumber = true;
            }
            else
            {
                MessageBox.Show("無效的數字輸入", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

           
            if (double.TryParse(textBox1.Text, out double currentNumber))
            {
                firstNumber = currentNumber;
                operation = button.Text; 
                isNewNumber = true; 
            }
            else
            {
                
                MessageBox.Show("無效的數字輸入", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0";
                isNewNumber = true;
            }
        }


        
        private void ClearButton_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "0";
            firstNumber = 0.0;
            operation = "";
            isNewNumber = true;
        }


    }
}