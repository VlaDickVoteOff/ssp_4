using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace CustomCalculator
{
    public partial class CustomCalculator : UserControl
    {

        private static string currentCalculation = string.Empty;
        private static List<string> operators = new List<string>() { "+", "-", "*", "/", "^"};
        private static string prevValue = "0";


        public CustomCalculator() => InitializeComponent();


        private void AnyButtonClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Invoke");
            textBoxError.Text = string.Empty;


            var isOperator = operators.Contains((sender as Button).Text);
            var isLastCharOperator = false;
            if (currentCalculation.Length > 0)
            {
                isLastCharOperator = operators.Contains(currentCalculation.Substring(currentCalculation.Length - 1, 1));
            }
            if (isOperator && isLastCharOperator)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }

            currentCalculation += (sender as Button).Text;
            textBoxOutput.Text = currentCalculation;
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {
            textBoxError.Text = "";

            if (currentCalculation.Length == 0)
            {
                textBoxOutput.Text = "0";
                return;
            }



            for (int i = 1; i < currentCalculation.Length; i++)
            {
                if (currentCalculation[i] == 'A' && !operators.Contains(currentCalculation[i - 1].ToString()))
                {
                    textBoxOutput.Text = "0";
                    currentCalculation = "";
                    textBoxError.Text = "Ошибка ввода";
                    return;
                    
                }
            }


            while (currentCalculation.Contains("ANS"))
            {
                currentCalculation = currentCalculation.Replace("ANS", prevValue);
            }

            for (int i = 1; i < currentCalculation.Length; i++)
            {
                if (currentCalculation[i] == '0' && currentCalculation[i - 1] == '/')
                {
                    textBoxOutput.Text = "0";
                    currentCalculation = "";
                    textBoxError.Text = "На ноль делить нельзя";
                    return;

                }
            }

            var formattedCalculation = currentCalculation.ToString().Replace("∞", "1/0");
            prevValue = formattedCalculation;

            var index = formattedCalculation.IndexOf("^");


            //try
            //{
            //    if (formattedCalculation.Contains("."))
            //    {
            //        string[] numbers = formattedCalculation.Split('.'); //string[] numbers = formattedCalculation.Split(new char[] { '.', '+', '-', '*', '/', '^' });
            //        foreach (var number in numbers)
            //        {
            //            if (formattedCalculation.Contains($".{number}."))
            //            {
            //                throw new Exception();

            //            }
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{

            //    textBoxOutput.Text = "0";
            //    currentCalculation = "";
            //    textBoxError.Text = "Ошибка ввода";
            //}









            var tst = textBoxOutput.Text;

            try
            {
                if (index == -1)
                {
                    textBoxOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString().Replace(",", "."); 
                }
                else
                {
                    var calculatedBeforeIndex = int.Parse(new DataTable().Compute(formattedCalculation.Substring(0, index), null).ToString());
                    var calculatedAfterIndex = int.Parse(new DataTable().Compute(formattedCalculation.Substring(index + 1), null).ToString());

                    var result = calculatedBeforeIndex;
                    for (int i = 1; i < calculatedAfterIndex; i++)
                    {
                        result *= calculatedBeforeIndex;
                    }

                    textBoxOutput.Text = result.ToString().Replace(",", ".");
                }

                currentCalculation = textBoxOutput.Text;
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = "0";
                currentCalculation = "";
                textBoxError.Text = "Ошибка ввода";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "0";
            currentCalculation = string.Empty;
            textBoxError.Text = string.Empty;
        }

        private void button_ClearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
           

            textBoxOutput.Text = currentCalculation;
        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }
        private bool znak = true;
        private void button19_Click(object sender, EventArgs e)
        {          
                            
                var temp=textBoxOutput.Text;
                if (temp.Length != 0)
                {
                    var govno1 = temp[0];

                    if (temp[0].ToString().Contains("-"))
                    {
                        textBoxOutput.Text = textBoxOutput.Text.Remove(0, 1);
                    }
                    else
                    {
                        textBoxOutput.Text = "-" + textBoxOutput.Text;
                    }
                    znak = true;

                }             
                
               

            
                currentCalculation = textBoxOutput.Text;



           
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }
    }
}
