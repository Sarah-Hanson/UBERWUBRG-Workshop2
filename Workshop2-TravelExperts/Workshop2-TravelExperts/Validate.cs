using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop2_TravelExperts
{
    class Validate
    {
        
            private static string title = "ERROR";

            public static string Title
            {
                get { return title; }
                set { title = value; }
            }

            public static bool IsPresent(Control control) //validates Bools
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox textBox = (TextBox)control;
                    if (textBox.Text == "")
                    {
                    
                        MessageBox.Show(textBox.Tag + " is a required.", Title);
                        textBox.Focus();
                        return false;
                    }
                }
                else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.SelectedIndex == -1)
                    {
                        MessageBox.Show(comboBox.Tag + " is a required.", Title);
                        comboBox.Focus();
                        return false;
                    }
                }
                return true;
            }// Checks whether the user entered data into a text box.

            public static bool IsDecimal(TextBox textBox)//Validates Decimal
            {
                try
                {
                    Convert.ToDecimal(textBox.Text);
                    return true;
                }
                catch (FormatException)
                {
                    MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                    textBox.Focus();
                    return false;
                }
            } //Checks weather they entered a decimal

            public static bool IsInt32(TextBox textBox)//Validates Int
            {
                try
                {
                    Convert.ToInt32(textBox.Text);
                    return true;
                }
                catch (FormatException)
                {
                    MessageBox.Show(textBox.Tag + " must be a non Decimal number.", Title);
                    textBox.Focus();
                    return false;
                }
            } //Checks weather they enterd a decimal or not


        
    }
}
