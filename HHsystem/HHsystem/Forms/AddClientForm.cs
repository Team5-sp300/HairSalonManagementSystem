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
    public partial class AddClientForm : Form
    {
        private bool nameValid;
        private bool surnameValid;
        private bool emailValid;
        private bool phoneValid;
        MainForm main;

        public AddClientForm(MainForm main)
        {
            InitializeComponent();
            nameValid = false;
            surnameValid = false;
            emailValid = false;
            phoneValid = false;
            this.main=main;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (nameValid && surnameValid && emailValid && phoneValid)
            {
                new ClientController().add(getClientName(), getClientSurname(), getClientPhone(), getClientEmail());
                this.Dispose();
                main.refreshAppointment();
                main.populateBookingTable();
                main.populateClientList();
                main.populateClientTableManage();
                main.populateClientTable();
            }
            else
            {
                MessageBox.Show("Please enter valid details.");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public string getClientName()
        {            
            return nametxt.Text.Replace(" ", "&nbsp&");
        }

        public string getClientSurname()
        {
            return surnametxt.Text.Replace(" ", "&nbsp&");
        }

        public string getClientEmail()
        {
            return emailtxt.Text;
        }

        public string getClientPhone()
        {
            return phonetxt.Text;
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            if (getClientName().Length > 0)
            {
                pictureBoxName.Image = Properties.Resources.valid;
                nameValid = true;
            }
            else
            {
                pictureBoxName.Image = Properties.Resources.invalid;
                nameValid = false;
            }
        }

        private void surnametxt_TextChanged(object sender, EventArgs e)
        {
            if (getClientSurname().Length > 0)
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

        private void phonetxt_TextChanged(object sender, EventArgs e)
        {
            Regex NumericRegex = new Regex("^[0-9]{10}$");
            if (NumericRegex.IsMatch(getClientPhone()) && getClientPhone().Length > 0 && getClientPhone().Length <= 10)
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

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(getClientEmail(), expresion) && getClientEmail().Length > 0)
            {
                if (Regex.Replace(getClientEmail(), expresion, string.Empty).Length == 0)
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
    }
}
