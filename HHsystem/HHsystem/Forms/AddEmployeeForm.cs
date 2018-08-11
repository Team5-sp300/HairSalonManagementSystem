using HHsystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            id = rnd.Next(1, 101); ;
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
            usernametxt.Text =fnametxt.Text + lnametxt.Text+ id;
        }

        private void lnameTxt_TextChanged(object sender, EventArgs e)
        {
            lnametxt = sender as TextBox;
            usernametxt.Text = fnametxt.Text + lnametxt.Text + id;
        }
    }
}
