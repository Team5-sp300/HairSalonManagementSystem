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
    public partial class SettingForm : Form
    {
        DatabaseManager manager = new DatabaseManager();

        public SettingForm()
        {
            InitializeComponent();
            populateClients();
            populateEmployees();
            populateTimes();
            populateServices();
            setDateTimePicker();
        }

        public void setDateTimePicker()
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM";
            dateTimePicker.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        }

        public void populateClients()
        {
            for (int i = 0; i < manager.getClientDetails().GetLength(0); i++)
            {
                clientcombobox.Items.Add(manager.getClientDetails()[i, 1] + " " + manager.getClientDetails()[i, 2]);
            }
            clientcombobox.SelectedIndex = 0;
        }

        public void populateEmployees()
        {
            for (int i = 0; i < manager.getEmployeeDetails().GetLength(0); i++)
            {
                employeecombobox.Items.Add(manager.getEmployeeDetails()[i, 1] + " " + manager.getEmployeeDetails()[i, 2]);
            }
            employeecombobox.SelectedIndex = 0;
        }

        public void populateTimes()
        {
            for (int i = 8; i < 17; i++)
            {
                timehourscombobox.Items.Add(i);
            }
            for (int j = 00; j < 60; j+= 15)
            {
                timeminutescombobox.Items.Add(j);
            }
            timehourscombobox.SelectedIndex = 0;
            timeminutescombobox.SelectedIndex = 0;
        }

        public void populateServices()
        {
            for (int i = 0; i < manager.getServiceDetails().GetLength(0); i++)
            {
                servicecombobox.Items.Add(manager.getServiceDetails()[i, 1]);
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
            return dateTimePicker.Text;
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
            EmailController email = new EmailController();
            String[,] clients = manager.getClientDetails();

            string[] clientname = getClientName().Split(new char[0]);
            string[] employeename = getEmployeeName().Split(new char[0]);

            manager.addBooking(clientname[0], clientname[1], employeename[0], employeename[1], getDate(), getTime(), getService());

            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i,1].ToString() == clientname[0] && clients[i,2].ToString() == clientname[1])
                {
                    //email.sendEmail(int.Parse(clients[i,0]),getClientName(),getEmployeeName(),getDate(),getTime());
                    break;
                }
            }            
            this.Dispose();
        }
    }
}
