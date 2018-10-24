using HHsystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Forms
{
    public partial class SettingForm : Form
    {
        DatabaseManager manager = new DatabaseManager();
        MainForm main;

        public SettingForm(MainForm main)
        {
            InitializeComponent();
            populateClients();
            populateEmployees();
            populateTimes();
            populateServices();
            setDateTimePicker();
            this.main = main;
        }

        public void setDateTimePicker()
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM";
            dateTimePicker.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        }

        public void populateClients()
        {
            int length = manager.getClientDetails().GetLength(0);
            string[,] clientDetails = new string[length, 5];
            Array.Copy(manager.getClientDetails(), clientDetails, clientDetails.Length);
            for (int i = 0; i < length; i++)
            {
                clientcombobox.Items.Add(clientDetails[i, 1] + " " + clientDetails[i, 2]);
            }
            clientcombobox.SelectedIndex = 0;
        }

        public void populateEmployees()
        {
            int length = manager.getEmployeeDetails().GetLength(0);
            string[,] employeeDetails = new string[length, 6];
            Array.Copy(manager.getEmployeeDetails(), employeeDetails, employeeDetails.Length);
            for (int i = 0; i < length; i++)
            {
                employeecombobox.Items.Add(employeeDetails[i, 1] + " " + employeeDetails[i, 2]);
            }
            employeecombobox.SelectedIndex = 0;
        }

        public void populateTimes()
        {
            for (int i = 8; i < 17; i++)
            {
                if (i.ToString().Length < 2)
                {
                    timehourscombobox.Items.Add("0" + i);
                }
                else
                {
                    timehourscombobox.Items.Add(i);
                }

            }
            for (int j = 00; j < 60; j += 15)
            {
                if (j == 00)
                {
                    timeminutescombobox.Items.Add("00");
                }
                else
                {
                    timeminutescombobox.Items.Add(j);
                }

            }
            timehourscombobox.SelectedIndex = 0;
            timeminutescombobox.SelectedIndex = 0;
        }

        public void populateServices()
        {
            int length = manager.getServiceDetails().GetLength(0);
            string[,] serviceDetails = new string[length, 3];
            Array.Copy(manager.getServiceDetails(), serviceDetails, serviceDetails.Length);
            for (int i = 0; i < length; i++)
            {
                servicecombobox.Items.Add(serviceDetails[i, 1]);
            }
            servicecombobox.SelectedIndex = 0;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public string getClientName()
        {
            return clientcombobox.Text;
        }

        public string getEmployeeName()
        {
            return employeecombobox.Text;
        }

        public string getDate()
        {
            return dateTimePicker.Value.ToString("yyyy/MM/dd");
        }

        public string getTime()
        {
            return timehourscombobox.Text + ":" + timeminutescombobox.Text;
        }

        public string getService()
        {
            return servicecombobox.Text;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (employeecombobox.Text.Length > 0 && clientcombobox.Text.Length > 0 && DateTime.Compare(dateTimePicker.Value, new DateTime()) >= 0
                && timehourscombobox.Text.Length > 0 && timeminutescombobox.Text.Length > 0 && servicecombobox.Text.Length > 0)
            {
                EmailController email = new EmailController();
                String[,] clients = manager.getClientDetails();

                string[] clientname = getClientName().Split(new char[0]);
                string[] employeename = getEmployeeName().Split(new char[0]);

                if (manager.bookingCheck(employeename[0], employeename[1], getDate(), getTime()).Equals(0))
                {
                    manager.addBooking(clientname[0], clientname[1], employeename[0], employeename[1], getDate(), getTime(), getService());
                    for (int i = 0; i < clients.Length; i++)
                    {
                        if (clients[i, 1].ToString() == clientname[0] && clients[i, 2].ToString() == clientname[1])
                        {
                            email.sendEmail(int.Parse(clients[i, 0]), getClientName(), getEmployeeName(), getDate(), getTime(), getService());
                            break;
                        }
                    }

                    main.refreshAppointment();
                    main.populateBookingTable();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Stylist is not available for this appointment ");
                }
            }
            else
            {
                MessageBox.Show("Please choose valid options.");
            }
        }
    }
}
