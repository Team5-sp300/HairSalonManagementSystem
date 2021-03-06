﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace HHmobileApp
{
    [Activity(Label = "Insert Booking", Theme = "@style/AppTheme.NoActionBar")]
    class BookingInsert : AppCompatActivity
    {
        private string ip;
        private List<SpinnerDetails> clients;
        private List<SpinnerDetails> staff;
        private List<ServiceDetails> services;
        private Spinner spinnerStlyist;
        private Spinner spinnerClient;
        private Spinner spinnerDay;
        private Spinner spinnerMonth;
        private Spinner spinnerHour;
        private Spinner spinnerMinutes;
        private Spinner spinnerServices;
        private WebClient client;
        private Uri uri;
        private string cname;
        private string ename;
        private string aday;
        private string amonth;
        private string ahour;
        private string amin;
        private string aservice;
        private NameValueCollection parameter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.booking_insert);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.MenuItemClick += Menu_Clicked;

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
            ip = pref.GetString("IP", String.Empty);

            Button btn = FindViewById<Button>(Resource.Id.btninsert);
            btn.Click += button_click;

            client = new WebClient();
            uri = new Uri("http://" + ip + "/getStaff.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download_staff;

            client = new WebClient();
            uri = new Uri("http://" + ip + "/getClients.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download_client;

            client = new WebClient();
            uri = new Uri("http://" + ip + "/getServices.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download_service;

            spinnerStlyist = FindViewById<Spinner>(Resource.Id.spinnerStaff);
            spinnerClient = FindViewById<Spinner>(Resource.Id.spinnerClient);
            spinnerDay = FindViewById<Spinner>(Resource.Id.spinnerDate);
            spinnerMonth = FindViewById<Spinner>(Resource.Id.spinnerMonth);
            spinnerHour = FindViewById<Spinner>(Resource.Id.spinnerHours);
            spinnerMinutes = FindViewById<Spinner>(Resource.Id.spinnerMin);
            spinnerServices = FindViewById<Spinner>(Resource.Id.spinnerService);

            spinnerDay.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spinnerMonth.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spinnerStlyist.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spinnerClient.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spinnerHour.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spinnerMinutes.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spinnerServices.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);


            var hours = new List<string>() { "08", "09", "10", "11", "12", "13", "14", "15", "16" };
            var adapter0 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, hours);
            spinnerHour.Adapter = adapter0;

            var minutes = new List<string>() { "00", "15", "30", "45" };
            var adapter1 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, minutes);
            spinnerMinutes.Adapter = adapter1;

            var day = new List<string>() { "DD", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", };
            var adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, day);
            spinnerDay.Adapter = adapter2;
            spinnerDay.SetSelection(DateTime.Now.Day);

            var month = new List<string>() { "MM", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            var adapter3 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, month);
            spinnerMonth.Adapter = adapter3;
            spinnerMonth.SetSelection(DateTime.Now.Month);
        }



        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            if (sender.Equals(spinnerHour))
            {
                spinnerHour = (Spinner)sender;
                ahour = spinnerHour.GetItemAtPosition(e.Position).ToString();
            }
            else if (sender.Equals(spinnerMinutes))
            {
                spinnerMinutes = (Spinner)sender;
                amin = spinnerMinutes.GetItemAtPosition(e.Position).ToString();
            }
            else if (sender.Equals(spinnerClient))
            {
                spinnerClient = (Spinner)sender;
                cname = clients[e.Position].fname + " " + clients[e.Position].lname;
                Console.WriteLine(cname);
            }
            else if (sender.Equals(spinnerStlyist))
            {
                spinnerStlyist = (Spinner)sender;
                ename = staff[e.Position].fname + " " + staff[e.Position].lname;
            }
            else if (sender.Equals(spinnerDay))
            {
                spinnerDay = (Spinner)sender;
                aday = spinnerDay.GetItemAtPosition(e.Position).ToString();
            }
            else if (sender.Equals(spinnerMonth))
            {
                spinnerMonth = (Spinner)sender;
                amonth = spinnerMonth.GetItemAtPosition(e.Position).ToString();
                Console.WriteLine(amonth);
            }
            else if (sender.Equals(spinnerServices))
            {
                spinnerServices = (Spinner)sender;
                aservice = services[e.Position].service;
                Console.WriteLine(aservice);
            }
        }


        //private void spinnerMin_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        //{
        //    spinnerMinutes = (Spinner)sender;
        //    amin = spinnerMinutes.GetItemAtPosition(e.Position).ToString();
        //}


        private void download_staff(object sender, DownloadDataCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                string json = Encoding.UTF8.GetString(e.Result);
                staff = JsonConvert.DeserializeObject<List<SpinnerDetails>>(json);
                SpinnerAdapter adapter = new SpinnerAdapter(this, staff);
                spinnerStlyist.Adapter = adapter;
            });

        }

        private void download_client(object sender, DownloadDataCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                string json = Encoding.UTF8.GetString(e.Result);
                clients = JsonConvert.DeserializeObject<List<SpinnerDetails>>(json);
                SpinnerAdapter adapter = new SpinnerAdapter(this, clients);
                spinnerClient.Adapter = adapter;
            });

        }

        private void download_service(object sender, DownloadDataCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                string json = Encoding.UTF8.GetString(e.Result);
                services = JsonConvert.DeserializeObject<List<ServiceDetails>>(json);
                ServiceAdapter adapter = new ServiceAdapter(this, services);
                spinnerServices.Adapter = adapter;
            });
        }

        private void Menu_Clicked(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.ItemId == Resource.Id.action_back)
            {
                var intent = new Intent(this, typeof(BookingActivity));
                StartActivity(intent);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        private void button_click(object sender, EventArgs e)
        {
            client = new WebClient();
            uri = new Uri("http://" + ip + "/bookingCheck.php");
            parameter = new NameValueCollection();
            string[] employeename = ename.Split(' ');
            parameter.Add("efname", employeename[0]);
            parameter.Add("elname", employeename[1]);
            parameter.Add("adate", "2018/" + amonth + "/" + aday);
            parameter.Add("atime", ahour + ":" + amin);
            parameter.Add("service", aservice);

            client.UploadValuesCompleted += BookingCheck_UploadValuesCompleted;
            client.UploadValuesAsync(uri, parameter);
        }

        private void BookingCheck_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                string json = Encoding.UTF8.GetString(e.Result);
                string count = json.Replace("count","").Replace("{","").Replace("}", "").Replace(":", "").Replace("\"", "").Trim();
                Console.WriteLine("Here");
                Console.WriteLine(json);
                Console.WriteLine(count);
                if (int.Parse(count).Equals(0)) {
                    if (ValidateDate().Equals(true))
                    {

                        client = new WebClient();
                        uri = new Uri("http://" + ip + "/insertBooking.php");
                        string[] clientname = cname.Split(' ');
                        string[] employeename = ename.Split(' ');

                        parameter = new NameValueCollection();
                        parameter.Add("cfname", clientname[0]);
                        parameter.Add("clname", clientname[1]);
                        parameter.Add("efname", employeename[0]);
                        parameter.Add("elname", employeename[1]);
                        parameter.Add("adate", "2018/" + amonth + "/" + aday);
                        parameter.Add("atime", ahour + ":" + amin);
                        parameter.Add("service", aservice);

                        client.UploadValuesCompleted += Client_UploadValuesCompleted;
                        client.UploadValuesAsync(uri, parameter);
                    }
                    else
                    {
                        Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                        alert.SetTitle("Date Past");
                        alert.SetMessage("You cannot make an appointment for a date that has past");
                        alert.SetPositiveButton("OK", (senderAlert, args) =>
                        {
                        });
                        Dialog dialog = alert.Create();
                        dialog.Show();
                    }
                }
                else {
                    Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                    alert.SetTitle("Booking Already Exisit");
                    alert.SetMessage("Stylist is unavaliable");
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();

                }
                //items = JsonConvert.DeserializeObject<List<ScheduleDetails>>(json);
            });
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            client = new WebClient();
            uri = new Uri("http://" + ip + "/sendEmail.php");
            NameValueCollection parameter = new NameValueCollection();
            parameter.Add("cname", cname);
            parameter.Add("ename", ename);
            parameter.Add("adate", "2018/" + amonth + "/" + aday);
            parameter.Add("atime", ahour + ":" + amin);
            parameter.Add("service", aservice);
            client.UploadValuesAsync(uri, parameter);

            var intent = new Intent(this, typeof(BookingActivity));
            StartActivity(intent);
        }

        protected bool ValidateDate()
        {
            int month = int.Parse(DateTime.Now.ToString("MM"));
            int day = int.Parse(DateTime.Now.ToString("dd"));
            int hh = int.Parse(DateTime.Now.ToString("HH"));

            if (month == int.Parse(amonth) && day == int.Parse(aday) && hh <= int.Parse(ahour))
            {
                return true;
            }
            else if (month == int.Parse(amonth) && day <= int.Parse(aday))
            {
                return true;
            }
            else if (month <= int.Parse(amonth))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}