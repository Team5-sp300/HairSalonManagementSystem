using System;
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
        List<SpinnerDetails> clients;
        List<SpinnerDetails> staff;
        Spinner spinnerStlyist;
        Spinner spinnerClient;
        Spinner spinnerTime;
        Spinner spinnerDay;
        Spinner spinnerMonth;
        WebClient client;
        Uri uri;
        string cname;
        string ename;
        string atime;
        string aday;
        string amonth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.booking_insert);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.MenuItemClick += Menu_Clicked;

            Button btn = FindViewById<Button>(Resource.Id.btninsert);
            btn.Click += button_click;

            client = new WebClient();
            uri = new Uri("http://10.0.0.169/getStaff.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download_staff;

            client = new WebClient();
            uri = new Uri("http://10.0.0.169/getClients.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download_client;

            spinnerStlyist = FindViewById<Spinner>(Resource.Id.spinnerStaff);
            spinnerClient = FindViewById<Spinner>(Resource.Id.spinnerClient);
            spinnerTime = FindViewById<Spinner>(Resource.Id.spinnerTime);
            spinnerDay = FindViewById<Spinner>(Resource.Id.spinnerDate);
            spinnerMonth = FindViewById<Spinner>(Resource.Id.spinnerMonth);

            spinnerDay.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerDate_ItemSelected);
            spinnerMonth.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerMonth_ItemSelected);
            spinnerTime.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerTime_ItemSelected);
            spinnerStlyist.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerStylist_ItemSelected);
            spinnerClient.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerClient_ItemSelected);
        

            var times = new List<string>() { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00" };
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, times);
            spinnerTime.Adapter = adapter;

            var day = new List<string>() { "DD", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11","12","13", "14", "15", "16", "17", "18","19","20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", };
            var adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, day);
            spinnerDay.Adapter = adapter2;

            var month = new List<string>() { "MM","01", "02", "03", "04", "05", "06", "07", "08", "09","10","11","12" };
            var adapter3 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, month);
            spinnerMonth.Adapter = adapter3;
        }

        private void spinnerDate_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            spinnerDay = (Spinner)sender;
            aday = spinnerDay.GetItemAtPosition(e.Position).ToString();
        }

        private void spinnerMonth_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            spinnerDay = (Spinner)sender;
            amonth = spinnerDay.GetItemAtPosition(e.Position).ToString();
        }



        private void spinnerTime_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            spinnerTime = (Spinner)sender;
            atime = spinnerTime.GetItemAtPosition(e.Position).ToString();
        

        }

        private void spinnerStylist_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            spinnerStlyist = (Spinner)sender;
            ename = staff[e.Position].fname+" "+ staff[e.Position].lname;
       

        }

        private void spinnerClient_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            spinnerClient = (Spinner)sender;
            cname = clients[e.Position].fname + " " + clients[e.Position].lname;
        
        
        }

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
            uri = new Uri("http://10.0.0.169/insertBooking.php");
            NameValueCollection parameter = new NameValueCollection();

            string[] clientname = cname.Split(' ');
            string[] employeename = ename.Split(' ');

            parameter.Add("cfname", clientname[0]);
            parameter.Add("clname", clientname[1]);
            parameter.Add("efname", employeename[0]);
            parameter.Add("elname", employeename[1]);
            parameter.Add("adate", "2018/"+amonth+"/"+ aday);
            parameter.Add("atime", atime);
            parameter.Add("service", "Gents Cut");

            client.UploadValuesCompleted += Client_UploadValuesCompleted;
            client.UploadValuesAsync(uri, parameter);
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            var intent = new Intent(this, typeof(BookingActivity));
            StartActivity(intent);
        }
    }
}