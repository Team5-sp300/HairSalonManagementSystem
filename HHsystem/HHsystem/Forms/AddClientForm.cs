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
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            new ClientController().add(getClientName(), getClientSurname(), getClientEmail(), getClientPhone());
            this.Dispose();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public string getClientName()
        {
            return nametxt.Text;
        }

        public string getClientSurname()
        {
            return passwordtxt.Text;
        }

        public string getClientEmail()
        {
            return emailtxt.Text;
        }

        public string getClientPhone()
        {
            return phonetxt.Text;
        }
    }
}
