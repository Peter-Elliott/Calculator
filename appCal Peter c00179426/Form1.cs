using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appCal_Peter_c00179426
{
    public partial class frmCal : Form
    {
        Double Num1 = 0;// the first number entered
        Double Num2 = 0;// the second number entered used in the equals buttons calculations
        Double Ans = 0;// the calulations answer
        String Numbers = "";//the numbers enteed in to be converted to Double later
        Boolean Sign_clicked = false;//has a sign like + or - been click
        String Sign = "";// the signs themsels
        Boolean Desimal = false;//has the Double point been clicked in the number yet
        Boolean First_Click = true;

        public frmCal()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);//a method for adding in the label value of a button used to save on lines of code
        }

        private void Addnumbers(object sender)
        {// this method is to take the lable value and add it to variable Numbers and the Display box
            Button button = sender as Button;

            if(First_Click == true)
            {
                Numbers = "" + Convert.ToDouble(button.Text);
                txtDisplay.Text = "" + Convert.ToDouble(button.Text);
            }
            else if (First_Click == false)
            {
                Numbers += Convert.ToDouble(button.Text);
                txtDisplay.Text += Convert.ToDouble(button.Text);
            }

            First_Click = false;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            Addnumbers(sender);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (Desimal == false)// the Double can only be click once  for each number
            {
                txtDisplay.Text += ".";
                Numbers += ".";
                Desimal = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Desimal == true)
            {
                if (Numbers == ".")
                {
                    Numbers = "";
                }
                else if (Numbers.Length == 1 && Numbers != ".")
                {
                    Numbers = "";
                }
                txtDisplay.Text = Numbers;
                Desimal = false;
            }

            if (Sign_clicked == false)
            {
                if (Numbers != "")
                    Numbers = Numbers.Substring(0, Numbers.Length - 1);
                txtDisplay.Text = Numbers;
            }
            else if (Sign_clicked == true && Numbers == "")
            {
                Sign = "";
                Sign_clicked = false;
                Numbers = "" + Num1;
                Num1 = 0;
                txtDisplay.Text = "" + Numbers;
                Desimal = false;
            }
            else if (Sign_clicked == true && Num1 == 0)
            {
                Numbers = Numbers.Substring(0, Numbers.Length - 1);
                txtDisplay.Text = Num1 + Sign + Numbers;
            }
            else if (Sign_clicked == true)
            {
                Numbers = Numbers.Substring(0, Numbers.Length - 1);
                txtDisplay.Text = Num1 + Sign + Numbers;
            }

            if (Numbers =="" && Sign_clicked==false)
            {
                txtDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {   //reset all values to their default values except Ans
            Num1 = 0;
            Num2 = 0;
            Numbers = "";
            Sign_clicked = false;
            Sign = "";
            Desimal = false;
            txtDisplay.Text = "0";
            First_Click = true;
        }

        private void btnPositive_Click(object sender, EventArgs e)
        {
            Numbers = "" + (-1 * Convert.ToDouble(Numbers)); 
            
            if (Sign_clicked == false)
            {
                txtDisplay.Text = Numbers;
            }
            if(Sign_clicked == true)
            {
                txtDisplay.Text = Num1 + Sign + Numbers;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSigns(sender); // send of add a sign
        }

        private void AddSigns(object sender)
        {//turning the sender into a button allows the progrram to get the label
            Button Signclicked = sender as Button;

            if (Sign_clicked == false)
            {
                try
                {
                    Num1 = Convert.ToDouble(Numbers);//convert the string to a double and store for later
                    Sign_clicked = true;// the sign has been clicked
                }
                catch (FormatException myError)
                {
                    Console.WriteLine(myError.Message);
                }
                Sign = Signclicked.Text;// the sign variable will know equal + or -
                txtDisplay.Text = Num1 + Sign; //Display both play bout the number and value
               }
            else if (Sign_clicked == true && Numbers == "")
            {
                Sign = Signclicked.Text; //to change the sign value form + to * or /
                txtDisplay.Text = Num1 + Sign;// redisplay
            }
            else if (Sign_clicked == true)
            {
                try
                {   //send to equaltion to be calulated if it has been click twice
                    Calculate();
                }
                catch (FormatException myError)
                {
                    Console.WriteLine(myError.Message);
                }
                txtDisplay.Text = Num1 + Sign;
            }
            Numbers = "";// reset numbers
            Desimal = false;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            AddSigns(sender);
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            AddSigns(sender);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            AddSigns(sender);
        }

        private void Calculate()
        {
            try{
                Num2 = Convert.ToDouble(Numbers);
            }
            catch (FormatException){
                Num2 = 0;
            }

            switch (Sign)
            {
                case "+":
                    txtDisplay.Text = "" + (Num1 + Num2);
                    Ans = Num1 + Num2;
                    break;
                case "-":
                    txtDisplay.Text = "" + (Num1 - Num2);
                    Ans = Num1 - Num2;
                    break;
                case "*":
                    txtDisplay.Text = "" + (Num1 * Num2);
                    Ans = Num1 * Num2;
                    break;
                case "/":
                    txtDisplay.Text = "" + (Num1 / Num2);
                    Ans = Num1 / Num2;
                    break;
                case "":
                    txtDisplay.Text = "" + Numbers;
                    break;
                default:
                    txtDisplay.Text = "0";
                    Ans = 0;
                    break;
            }
            Num2 = 0;
            Numbers = "";
            Num1 = Ans;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Calculate();
            Sign_clicked = false;
            Desimal = false;
            First_Click = true;
        }
    }
}
