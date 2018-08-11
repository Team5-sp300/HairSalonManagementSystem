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
        private String[] appointments;
        private String[] time;
        private String[] name;
        private int[] duration;

        public MainForm()
        {
            InitializeComponent();
            populateTable();
            addAdppointments();
            populateWeeks();
            comboBox1.SelectedIndex = 0;
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
            appointments = new String[] { "06/08", "07/08", "14/08" };
            time = new String[] { "9:00", "13:00", "15:00" };
            name = new String[] { "Mary", "Sarah", "Emma" };
            duration = new int[] { 2, 2, 1 };
            customWeeklyScheduler1.addAppointment(appointments, time, name, duration);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedIndex = 1;
            this.button2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            label3.Text = "Appointment";

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
    }
}
