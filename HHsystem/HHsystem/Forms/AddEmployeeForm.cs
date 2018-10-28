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
        private bool nameValid;
        private bool surnameValid;
        private bool emailValid;
        private bool phoneValid;
        private bool passwordValid;
        private bool confirmPasswordValid;
        MainForm main;

        public AddEmployeeForm(MainForm main)
        {
            InitializeComponent();
            Random rnd = new Random();
            id = rnd.Next(100, 1000);
            nameValid = false;
            surnameValid = false;
            emailValid = false;
            phoneValid = false;
            passwordValid = false;
            this.main=  main;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nameValid && surnameValid && emailValid && phoneValid && passwordValid && confirmPasswordValid)
            {
                new EmployeeController().add(getEmployeeUname(), getEmployeeFname(), getEmployeeLname(), getEmployeeEmail(), getEmployeePhone(), getEmployeePassword(), adminCheck());
                main.populateEmployeesList();
                main.populateEmployeeTable();
                main.populateEmployeeTableMange();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please enter valid details.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public string getEmployeeUname()
        {
            return usernamelbl.Text;
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

        public string getEmployeePasswordConfirm()
        {
            return confirmpasswordtxt.Text;
        }

        public int adminCheck()
        {
            if (checkBox1.Checked)
            {
                return 1;
            } else
            {
                return 2;
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            fnametxt = sender as TextBox;
            if (fnametxt.Text.Length >= 3 && lnametxt.Text.Length >= 3)
            {
                usernamelbl.Text = fnametxt.Text.Substring(0, 3) + lnametxt.Text.Substring(0, 3) + id;
            }
            else if (fnametxt.Text.Length >= 3 && lnametxt.Text=="")
            {
                usernamelbl.Text = fnametxt.Text.Substring(0,3) + lnametxt.Text + id;
            }
           else if(lnametxt.Text == ""){
                usernamelbl.Text = fnametxt.Text + lnametxt.Text + id;
            }
            else if (lnametxt.Text != "")
            {
                usernamelbl.Text = fnametxt.Text+ lnametxt.Text.Substring(0, 3) + id;
            }

            if (getEmployeeFname().Length > 0 )
            {
                pictureBoxFirstName.Image = Properties.Resources.valid;
                nameValid = true;
            }
            else
            {
                pictureBoxFirstName.Image = Properties.Resources.invalid;
                nameValid = false;
            }
        }

        private void lnameTxt_TextChanged(object sender, EventArgs e)
        {
            lnametxt = sender as TextBox;

            if (fnametxt.Text.Length >= 3 && lnametxt.Text.Length >= 3)
            {
                usernamelbl.Text = fnametxt.Text.Substring(0, 3) + lnametxt.Text.Substring(0, 3) + id;
            }
            else if (lnametxt.Text.Length >= 3 && fnametxt.Text == "")
            {
                usernamelbl.Text = fnametxt.Text + lnametxt.Text.Substring(0, 3) + id;
            }
            else if (fnametxt.Text != "")
            {
                usernamelbl.Text = fnametxt.Text.Substring(0,3) + lnametxt.Text + id;
            }

            if (getEmployeeLname().Length > 0)
            {
                pictureBoxSurname.Image = Properties.Resources.valid;
                surnameValid = true;
            }
            else
            {
                pictureBoxSurname.Image = Properties.Resources.invalid;
                surnameValid = false;
            }
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(getEmployeeEmail(), expresion) && getEmployeeEmail().Length > 0)
            {
                if (Regex.Replace(getEmployeeEmail(), expresion, string.Empty).Length == 0)
                {
                    pictureBoxEmail.Image = Properties.Resources.valid;
                    emailValid = true;
                }
                else
                {
                    pictureBoxEmail.Image = Properties.Resources.invalid;
                    emailValid = false;
                }
            }
            else
            {
                pictureBoxEmail.Image = Properties.Resources.invalid;
                emailValid = false;
            }
        }

        private void phonetxt_TextChanged(object sender, EventArgs e)
        {
            Regex nonNumericRegex = new Regex(@"\D");
            if (!nonNumericRegex.IsMatch(getEmployeePhone()) && getEmployeePhone().Length > 0 && getEmployeePhone().Length <= 10)
            {
                pictureBoxPhone.Image = Properties.Resources.valid;
                phoneValid = true;
            }
            else 
            {
                pictureBoxPhone.Image = Properties.Resources.invalid;
                phoneValid = false;
            }
        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            if (getEmployeePassword().Length >= 8)
            {
                pictureBoxPassword.Image = Properties.Resources.valid;
                passwordValid = true;
            }
            else
            {
                pictureBoxPassword.Image = Properties.Resources.invalid;
                passwordValid = false;
            }
        }

        private void confirmpasswordtxt_TextChanged(object sender, EventArgs e)
        {
            if (getEmployeePasswordConfirm().Equals(getEmployeePassword()))
            {
                pictureBoxConfirmPassword.Image = Properties.Resources.valid;
                confirmPasswordValid = true;
            }
            else
            {
                pictureBoxConfirmPassword.Image = Properties.Resources.invalid;
                confirmPasswordValid = false;
            }
        }
    }
}
