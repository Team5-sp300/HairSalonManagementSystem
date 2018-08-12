using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HHsystem.Controllers;
using HHsystem.Forms;
using MySql.Data.MySqlClient;

namespace HHsystem
{
    public partial class MainForm : Form
    {

        DatabaseManager manager = new DatabaseManager();
        DataTable table;  
   
        public MainForm()
        {
            InitializeComponent();
            populateTable();
            addAdppointments();
            populateWeeks();
            populateNames();
            
        }

        public void populateTable()
        {
            try
            {
                populateEmployeeTable();
                populateBookingTable();
                populateClientTable();
            }
            catch (Exception)
            {
            }
        }

        public void addAdppointments() {
            customWeeklyScheduler1.setAppointment(manager.getBookingDetails());
        }

        public void populateBookingTable()
        {
            table = new DataTable();
            manager.getBooking().Fill(table);
            bindingSource1.DataSource = table;
            dataGridView2.DataSource = bindingSource1;
            table.Columns[0].ColumnName = "Booking ID";
            table.Columns[1].ColumnName = "Client Name";
            table.Columns[2].ColumnName = "Employee Name";
            table.Columns[3].ColumnName = "Appointment Time";
        }

        public void populateEmployeeTable()
        {
            table = new DataTable();
            manager.getEmployee().Fill(table);
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;
        }


        public void populateClientTable()
        {
            table = new DataTable();
            manager.getClients().Fill(table);
            bindingSource2.DataSource = table;
            dataGridView3.DataSource = bindingSource2;
        }

        public void populateWeeks()
        {
            for (int i = 0; i < 5; i++)
            {
                DateTime startOfWeek = DateTime.Today.AddDays(
          (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
          (int)DateTime.Today.DayOfWeek + 1 + i * 7);
                var endDate = startOfWeek.AddDays(7);
                comboBox1.Items.Add(startOfWeek.ToString("dd/MM") + "-" + endDate.ToString("dd/MM"));
            }
            comboBox1.SelectedIndex = 0;
        }

        public void populateNames()
        {
            for (int i = 0; i < manager.getClientDetails().GetLength(0); i++)
            {   
                comboBox2.Items.Add(manager.getClientDetails()[i,1]+" "+ manager.getClientDetails()[i, 2]);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedIndex = 1;
            this.button2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            label3.Text = "Appointments";

            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedIndex = 0;
            this.button3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            label3.Text = "Home";

            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedIndex = 2;
            this.button4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            label3.Text = "Clients";

            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedIndex = 3;
            this.button5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            label3.Text = "Staff";

            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedIndex = 4;
            this.button12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            label3.Text = "Settings";

            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            manager.backup();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            manager.restore();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            customTabControl2.SelectedIndex = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            customTabControl2.SelectedIndex = 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new AddEmployeeForm().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new AddClientForm().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customWeeklyScheduler1.setWeekNo(comboBox1.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int arraySize = manager.getClientDetails().GetLength(0);
            string[,] clientDetails = new string[arraySize, 5];
            Array.Copy(manager.getClientDetails(), clientDetails, clientDetails.Length);
            for (int i = 0; i < clientDetails.GetLength(0); i++)
            {
                string name = clientDetails[i, 1] + " " + clientDetails[i, 2];
                if (name.Equals(comboBox2.SelectedItem))
                {
                    cnametxt.Text = name;
                    cphonetxt.Text = clientDetails[i, 3];
                    cemail.Text = clientDetails[i, 4];
                    table = new DataTable();
                    manager.getBooking(clientDetails[i, 0]).Fill(table);
                    bindingSource.DataSource = table;
                    dataGridView7.DataSource = bindingSource;
                    table.Columns[0].ColumnName = "Stylist";
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //this.Width = 1000;
            //this.Height = 800;
            this.WindowState = FormWindowState.Maximized;
            customWeeklyScheduler1.redraws(this.Width-200, this.Height-205);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            customTabControl4.SelectedIndex = 1;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            customTabControl4.SelectedIndex = 0;
        }
    }
}
