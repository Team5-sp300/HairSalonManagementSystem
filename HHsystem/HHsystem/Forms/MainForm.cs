using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HHsystem.Controllers;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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

        private void button10_Click(object sender, EventArgs e)
        {
            appointments = new String[] { "25/06", "27/06", "26/06" };
            time = new String[] { "9:00", "13:00", "15:00" };
            name = new String[] { "Mary", "Sarah", "Emma" };
            duration = new int[] { 2, 2, 1 };
            customWeeklyScheduler1.addAppointment(appointments, time, name, duration);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            manager.backup();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            manager.restore();
        }
    }
}
