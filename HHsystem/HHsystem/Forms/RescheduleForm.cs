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
    public partial class RescheduleForm : Form
    {
        DatabaseManager manager = new DatabaseManager();
        MainForm main;

        private int selectedId;
        private string selectedEmpName;
        private string selectedDate;
        private string selectedHours;
        private string selectedMinutes;
        private string selectedService;

        public RescheduleForm(int id, string empName, string name, string date, string time, string service, MainForm main)
        {
            InitializeComponent();
            selectedId = id;
            selectedEmpName = empName;
            clientlbl.Text = name;
            selectedDate = date;
            selectedHours = time.Substring(0,2);
            selectedMinutes = time.Substring(3, 2);
            selectedService = service;
            setDate();
            populateServices();
            populateTimes();
            this.main = main;
        }

        public void setDate()
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM";
            dateTimePicker.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            dateTimePicker.Value = new DateTime(DateTime.Today.Year, Int32.Parse(selectedDate.Substring(3, 2)), Int32.Parse(selectedDate.Substring(0, 2)));
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
            timehourscombobox.SelectedIndex = timehourscombobox.FindString(selectedHours);
            timeminutescombobox.SelectedIndex = timeminutescombobox.FindString(selectedMinutes);
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
            servicecombobox.SelectedIndex = servicecombobox.FindString(selectedService);
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dateTimePicker.Value, new DateTime()) >= 0 && timehourscombobox.Text.Length > 0 && timeminutescombobox.Text.Length > 0 && servicecombobox.Text.Length > 0)
            {
                EmailController email = new EmailController();
                String[,] clients = manager.getClientDetails();

                string clientname = clientlbl.Text;
                string[] employeename = selectedEmpName.Split(new char[0]);

                if (manager.updateBookingCheck(employeename[0], employeename[1], getDate(), getTime(),selectedId,getService()).Equals(0))
                {
                    manager.updateBooking(selectedId, getDate(), getTime(), getService());
                    MessageBox.Show("Date\t: " + dateTimePicker.Value.ToString("dd/MM/yyyy") + Environment.NewLine 
                        + "Time\t: " + getTime() + Environment.NewLine 
                        + "Service\t: " + getService(),"Rescheduling Confirmed");
                    main.updateBookingTable();
                    string[,] client = manager.getClientSurname(selectedId);
                    for (int i = 0; i < clients.Length; i++)
                    {
                        if (clients[i, 1].ToString() == client[0,0] && clients[i, 2].ToString() == client[0,1])
                        {
                            email.sendRescheduleEmail(int.Parse(clients[i,0]), client[0, 0] + " " + client[0, 1], selectedEmpName,getDate(),getTime(), getService());
                            break;
                        }
                    }
                    main.populateBookingTable();
                    main.refreshAppointment();
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
