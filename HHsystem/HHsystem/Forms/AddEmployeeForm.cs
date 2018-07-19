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
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new EmployeeController().add(getEmployeeName(),getEmployeeEmail(), getEmployeePhone(), getEmployeePassword());
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public string getEmployeeName()
        {
            return nametxt.Text;
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
    }
}
