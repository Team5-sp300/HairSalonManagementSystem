using HHsystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Forms
{
    public partial class AddEmployeeForm : Form
    {
        private int id;

        public AddEmployeeForm()
        {
            InitializeComponent();
            Random rnd = new Random();
            id = rnd.Next(100, 1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new EmployeeController().add(getEmployeeUname(),getEmployeeFname(), getEmployeeLname(),getEmployeeEmail(), getEmployeePhone(), getEmployeePassword());
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public string getEmployeeUname()
        {
            return usernametxt.Text;
        }

        public string getEmployeeFname()
        {
            return fnametxt.Text;
        }

        public string getEmployeeLname()
        {
            return lnametxt.Text;
        }

        public string getEmployeeEmail()
        {
            return emailtxt.Text;
        }

        public string getEmployeePhone()
        {
            return phonetxt.Text;
        }

        public string getEmployeePassword()
        {
            return passwordtxt.Text;
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            fnametxt = sender as TextBox;
            if (fnametxt.Text.Length >= 3 && lnametxt.Text.Length >= 3)
            {
                usernametxt.Text = fnametxt.Text.Substring(0, 3) + lnametxt.Text.Substring(0, 3) + id;
            }
            else if (fnametxt.Text.Length >= 3 && lnametxt.Text=="")
            {
                usernametxt.Text = fnametxt.Text.Substring(0,3) + lnametxt.Text + id;
            }
           else if(lnametxt.Text == ""){
                usernametxt.Text = fnametxt.Text + lnametxt.Text + id;
            }
            else if (lnametxt.Text != "")
            {
                usernametxt.Text = fnametxt.Text+ lnametxt.Text.Substring(0, 3) + id;
            }

            if (fnametxt.Text.Length > 0 )
            {
                pictureBoxFirstName.Image = Properties.Resources.valid;
            }
            else
            {
                pictureBoxFirstName.Image = Properties.Resources.invalid;
            }
        }

        private void lnameTxt_TextChanged(object sender, EventArgs e)
        {
            lnametxt = sender as TextBox;

            if (fnametxt.Text.Length >= 3 && lnametxt.Text.Length >= 3)
            {
                usernametxt.Text = fnametxt.Text.Substring(0, 3) + lnametxt.Text.Substring(0, 3) + id;
            }
            else if (lnametxt.Text.Length >= 3 && fnametxt.Text == "")
            {
                usernametxt.Text = fnametxt.Text + lnametxt.Text.Substring(0, 3) + id;
            }
            else if (fnametxt.Text != "")
            {
                usernametxt.Text = fnametxt.Text.Substring(0,3) + lnametxt.Text + id;
            }

            if (fnametxt.Text.Length > 0)
            {
                pictureBoxSurname.Image = Properties.Resources.valid;
            }
            else
            {
                pictureBoxSurname.Image = Properties.Resources.invalid;
            }
        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {
            if (usernametxt.Text.Length >= 8)
            {
                pictureBoxUserName.Image = Properties.Resources.valid;
            }
            else
            {
                pictureBoxUserName.Image = Properties.Resources.invalid;
            }            
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(emailtxt.Text, expresion) && emailtxt.Text.Length > 0)
            {
                if (Regex.Replace(emailtxt.Text, expresion, string.Empty).Length == 0)
                {
                    pictureBoxEmail.Image = Properties.Resources.valid;
                }
                else
                {
                    pictureBoxEmail.Image = Properties.Resources.invalid;
                }
            }
            else
            {
                pictureBoxEmail.Image = Properties.Resources.invalid;
            }
        }

        private void phonetxt_TextChanged(object sender, EventArgs e)
        {
            Regex nonNumericRegex = new Regex(@"\D");
            if (!nonNumericRegex.IsMatch(phonetxt.Text) && phonetxt.Text.Length > 0)
            {
                pictureBoxPhone.Image = Properties.Resources.valid;
            }
            else 
            {
                pictureBoxPhone.Image = Properties.Resources.invalid;
            }
        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            if (passwordtxt.Text.Length >= 8)
            {
                pictureBoxPassword.Image = Properties.Resources.valid;
            }
            else
            {
                pictureBoxPassword.Image = Properties.Resources.invalid;
            }
        }
    }
}
