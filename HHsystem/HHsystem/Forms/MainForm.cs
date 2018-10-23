﻿using System;
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
        SettingController settings = new SettingController();
        DataTable table;
        int REFRESH_RATE;
        string backLocation;
        string RefreshRate;
        string CalendarDays;
        string Resolution;
        int count;

        public MainForm()
        {
            InitializeComponent();
            loadSettings();
            populateTable();
            addAppointments();
            populateWeeks();
            populateNames();
            populateEmployees();
            customWeeklyScheduler.redrawScheduler(this.Width - 200, this.Height - 205);
            comboBox4.Text = CalendarDays;
            adminLogin();//needs to be removed, just for testing purposes
            count = manager.bookingCount();

            System.DateTime nowtime = System.DateTime.Now;

            labelmonth.Text = nowtime.ToString("ddd dd/MM");

        }


        public void loadSettings() {
            backLocation = settings.getBackLocation(); ;
            RefreshRate = settings.getRefreshRate();
             CalendarDays = settings.getCalendarDays() ;
             Resolution = settings.getResolution();
            backuptxt.Text = backLocation;
            comboBoxScreenRes.Text = Resolution;

            for (int i = 0; i < comboBoxCalendarView.Items.Count; i++)
            {
                if (comboBoxCalendarView.GetItemText(comboBoxCalendarView.Items[i]) == CalendarDays) {
                    comboBoxCalendarView.SelectedIndex = i;
                }
            }

            for (int i = 0; i < comboBoxRefresh.Items.Count; i++)
            {
                if (comboBoxRefresh.GetItemText(comboBoxRefresh.Items[i]) == RefreshRate)
                {
                    comboBoxRefresh.SelectedIndex = i;
                }
            }
            timer1.Stop();
            switch (comboBoxRefresh.Text) {

                case "5 Seconds":
                    REFRESH_RATE = 5000;
                    break;
                case "10 Seconds":
                    REFRESH_RATE = 10000;
                    break;
                case "15 Seconds":
                    REFRESH_RATE = 15000;
                    break;
            }
            timer1.Interval = REFRESH_RATE;
            //timer1.Start();
        }

        public void populateTable()
        {
            try
            {
                populateEmployeeTable();
                populateBookingTable();
                populateClientTable();
                populateClientTable2();
            }
            catch (Exception)
            {
            }
        }

        public void addAppointments()
        {
            customWeeklyScheduler.setAppointment(manager.getBookingDetails());
        }

        public void refreshAppointment() {
            int arraySize = manager.getEmployeeDetails().GetLength(0);
            string[,] employeeDetails = new string[arraySize, 6];
            Array.Copy(manager.getEmployeeDetails(), employeeDetails, employeeDetails.Length);
            for (int i = 0; i < employeeDetails.GetLength(0); i++)
            {
                string name = employeeDetails[i, 1] + " " + employeeDetails[i, 2];
                if (name.Equals(comboBox5.SelectedItem))
                {
                    customWeeklyScheduler.setAppointment(manager.getBookingSchedule(employeeDetails[i, 0]));
                }
            }
        }

        public void populateBookingTable()
        {
            table = new DataTable();
            manager.getBooking().Fill(table);
            bindingSource1.DataSource = table;
            dataGridView2.DataSource = bindingSource1;
            dataGridView6.DataSource = bindingSource1;
            table.Columns[0].ColumnName = "Booking ID";
            table.Columns[1].ColumnName = "Client Name";
            table.Columns[2].ColumnName = "Employee Name";
            table.Columns[3].ColumnName = "Appointment Date";
            table.Columns[4].ColumnName = "Appointment Time";
            table.Columns[5].ColumnName = "Service Booked";
        }

        public void populateEmployeeTable()
        {
            table = new DataTable();
            manager.getEmployee().Fill(table);
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;
            dataGridView4.DataSource = bindingSource;
            table.Columns[0].ColumnName = "Username";
            table.Columns[1].ColumnName = "Name";
            table.Columns[2].ColumnName = "Last Name";
            table.Columns[3].ColumnName = "Password";
            table.Columns[4].ColumnName = "Phone Number";
            table.Columns[5].ColumnName = "Email Address";
            table.Columns[6].ColumnName = "Status";
            dataGridView4.Refresh();
        }


        public void populateClientTable()
        {
            table = new DataTable();
            manager.getClients().Fill(table);
            foreach (DataRow row in table.Rows)
            {
                row[1] = row[1].ToString().Replace("&nbsp&", " ");
                row[0] = row[0].ToString().Replace("&nbsp&", " ");
            }
            table.Columns.Remove(table.Columns[0]);
            table.Columns.Remove(table.Columns[4]);
            bindingSource2.DataSource = table;
            dataGridView3.DataSource = bindingSource2;
            table.Columns[0].ColumnName = "Name";
            table.Columns[1].ColumnName = "Last Name";
            table.Columns[2].ColumnName = "Phone Number";
            table.Columns[3].ColumnName = "Email Address";
        }

        public void populateClientTable2()
        {
            table = new DataTable();
            manager.getClients().Fill(table);
            foreach (DataRow row in table.Rows)
            {
                row[1] = row[1].ToString().Replace("&nbsp&", " ");
                row[0] = row[0].ToString().Replace("&nbsp&", " ");
            }
            bindingSource5.DataSource = table;
            dataGridView5.DataSource = bindingSource5;
            table.Columns[0].ColumnName = "ID";
            table.Columns[1].ColumnName = "Name";
            table.Columns[2].ColumnName = "Last Name";
            table.Columns[3].ColumnName = "Phone Number";
            table.Columns[4].ColumnName = "Email Address";
            table.Columns[5].ColumnName = "Status";
        }

        public void populateWeeks()
        {
            for (int i = 0; i < 24; i++)
            {
                DateTime startOfWeek = DateTime.Today.AddDays(
          (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
          (int)DateTime.Today.DayOfWeek + 1 + i * 7);
                var endDate = startOfWeek.AddDays(6);
                comboBox1.Items.Add(startOfWeek.ToString("ddd dd MMMM") + " - " + endDate.ToString("ddd dd MMMM"));
            }
            comboBox1.SelectedIndex = 0;
        }

        public void populateNames()
        {
            comboBox2.Items.Clear();
            for (int i = 0; i < manager.getClientDetails().GetLength(0); i++)
            {
                comboBox2.Items.Add(manager.getClientDetails()[i, 1] + " " + manager.getClientDetails()[i, 2]);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        public void populateEmployees()
        {
            comboBox3.Items.Clear();
            for (int i = 0; i < manager.getEmployeeDetails().GetLength(0); i++)
            {
                comboBox3.Items.Add(manager.getEmployeeDetails()[i, 1] + " " + manager.getEmployeeDetails()[i, 2]);
                comboBox5.Items.Add(manager.getEmployeeDetails()[i, 1] + " " + manager.getEmployeeDetails()[i, 2]);
            }
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
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
            updateBookingTable();

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
            new LoginForm(this).Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            bookingTabControl.SelectedIndex = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            bookingTabControl.SelectedIndex = 1;
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
            customWeeklyScheduler.setWeekNo(comboBox1.SelectedIndex);
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
                    manager.getBookingHistory(clientDetails[i, 0]).Fill(table);
                    bindingSource3.DataSource = table;
                    dataGridView7.DataSource = bindingSource3;
                    table.Columns[0].ColumnName = "Stylist";
                    table.Columns[1].ColumnName = "Appointment Date";
                    table.Columns[2].ColumnName = "Appointment Time";
                    table.Columns[3].ColumnName = "Service Duration (in m)";
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBookingTable();
        }

        public void updateBookingTable()
        {
            int arraySize = manager.getEmployeeDetails().GetLength(0);
            string[,] employeeDetails = new string[arraySize, 6];
            Array.Copy(manager.getEmployeeDetails(), employeeDetails, employeeDetails.Length);
            for (int i = 0; i < employeeDetails.GetLength(0); i++)
            {
                string name = employeeDetails[i, 1] + " " + employeeDetails[i, 2];
                if (name.Equals(comboBox3.SelectedItem))
                {
                    enametxt.Text = name;
                    ephonetxt.Text = employeeDetails[i, 4];
                    eemail.Text = employeeDetails[i, 5];
                    table = new DataTable();
                    manager.getEmployeeSchedule(employeeDetails[i, 0]).Fill(table);
                    bindingSource4.DataSource = table;
                    dataGridView8.DataSource = bindingSource4;
                    table.Columns[0].ColumnName = "Booking ID";
                    table.Columns[1].ColumnName = "Client";
                    table.Columns[2].ColumnName = "Appointment Date";
                    table.Columns[3].ColumnName = "Appointment Time";
                    table.Columns[4].ColumnName = "Service";
                    table.Columns[5].ColumnName = "Service Duration (in m)";
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            settings.setSettings(backuptxt.Text.ToString(), comboBoxRefresh.SelectedItem.ToString(),
            comboBoxCalendarView.SelectedItem.ToString(),
            comboBoxScreenRes.SelectedItem.ToString());
            MessageBox.Show("Settings Saved. Please Restart the System for the Settings to take Effect", "Settings Saved",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            clientTabControl.SelectedIndex = 1;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            clientTabControl.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new SettingForm(this).Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            staffTabControl.SelectedIndex = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            staffTabControl.SelectedIndex = 1;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            managementTabControl.SelectedIndex = 0;
            button19.ForeColor = SystemColors.MenuHighlight;
            button26.ForeColor = SystemColors.ControlDarkDark;
            button10.ForeColor = SystemColors.ControlDarkDark;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            managementTabControl.SelectedIndex = 1;
            button19.ForeColor = SystemColors.ControlDarkDark;
            button26.ForeColor = SystemColors.MenuHighlight;
            button10.ForeColor = SystemColors.ControlDarkDark;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            managementTabControl.SelectedIndex = 2;
            button19.ForeColor = SystemColors.ControlDarkDark;
            button26.ForeColor = SystemColors.ControlDarkDark;
            button10.ForeColor = SystemColors.MenuHighlight;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            managementTabControl.SelectedIndex = 3;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (managementTabControl.SelectedIndex.Equals(1))
            {
                int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];
                string i = selectedRow.Cells[0].Value.ToString();
                string fname = selectedRow.Cells[1].Value.ToString();
                string lname = selectedRow.Cells[2].Value.ToString();
                string phone = selectedRow.Cells[3].Value.ToString();
                string email = selectedRow.Cells[4].Value.ToString();
                manager.updateClient(i, fname, lname, phone, email);
            }
            else if (managementTabControl.SelectedIndex.Equals(2))
            {
                int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
                string username = selectedRow.Cells[0].Value.ToString();
                string fname = selectedRow.Cells[1].Value.ToString();
                string lname = selectedRow.Cells[2].Value.ToString();
                string phone = selectedRow.Cells[4].Value.ToString();
                string email = selectedRow.Cells[5].Value.ToString();
                manager.updateEmployee(username, fname, lname, phone, email);
            }

            else
            {
                MessageBox.Show("Not Implemented");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (managementTabControl.SelectedIndex.Equals(1))
            {
                int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];
                string username = selectedRow.Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show("Do you want to permanently delete this?", "Warning",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    manager.deleteClient(username);
                    populateClientTable();
                    populateClientTable2();
                    populateBookingTable();
                }
                else if (result == DialogResult.No)
                {
                    manager.voidClient(username);
                    populateClientTable();
                    populateClientTable2();
                }
                else if (result == DialogResult.Cancel)
                {
                    //code for Cancel
                }
            }
            else if (managementTabControl.SelectedIndex.Equals(2))
            {
                int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
                string username = selectedRow.Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show("Do you want to permanently delete this?", "Warning",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    manager.deleteEmployee(username);
                    populateEmployeeTable();
                }
                else if (result == DialogResult.No)
                {
                    manager.voidEmployee(username);
                    populateEmployeeTable();
                }
                else if (result == DialogResult.Cancel)
                {
                    //code for Cancel
                }
            }

            else
            {
                MessageBox.Show("Not Implemented");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            customWeeklyScheduler.setColums(comboBox4.SelectedIndex + 4);
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            customWeeklyScheduler.setColums(comboBox4.SelectedIndex + 5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tmp = manager.bookingCount();
          //  timer1.Interval = REFRESH_RATE;
            
            //MessageBox.Show("test");
            populateTable();
            if (count !=tmp) {
                count = tmp;
                refreshAppointment();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            string currentTime = System.DateTime.Now.ToString("HH:mm:ss");
            labeltime.Text = currentTime;
        }

        public void stylistLogin()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button12.Enabled = false;
        }

        public void adminLogin()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button12.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Log Out Successful");
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button12.Enabled = false;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView8.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView8.Rows[selectedrowindex];

            int selectedID = Int32.Parse(selectedRow.Cells[0].Value.ToString());
            string selectedClient = selectedRow.Cells[1].Value.ToString();
            string selectedDate = selectedRow.Cells[2].Value.ToString();
            string selectedTime = selectedRow.Cells[3].Value.ToString();
            string selectedService = selectedRow.Cells[4].Value.ToString();

            new RescheduleForm(selectedID,enametxt.Text,selectedClient,selectedDate,selectedTime,selectedService, this).Show();
        }

        private void btnBrowseBackupLocation_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            backuptxt.Text = folderBrowserDialog1.SelectedPath;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshAppointment();
        }
    }
}
