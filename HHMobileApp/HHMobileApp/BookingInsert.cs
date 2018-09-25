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

namespace HHmobileApp
{
    [Activity(Label = "Insert Booking", Theme = "@style/AppTheme.NoActionBar")]
    class BookingInsert : AppCompatActivity
    {
        private EditText txtCname;
        private EditText txtEname;
        private EditText txtDate;
        private EditText txtTime;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.booking_insert);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.MenuItemClick += Menu_Clicked;

            Button btn = FindViewById<Button>(Resource.Id.btninsert);
            btn.Click += button_click;

            txtCname = FindViewById<EditText>(Resource.Id.etCname);
            txtEname = FindViewById<EditText>(Resource.Id.etEname);
            txtDate = FindViewById<EditText>(Resource.Id.etDate);
            txtTime = FindViewById<EditText>(Resource.Id.etTime);
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
            WebClient client = new WebClient();
            Uri uri = new Uri("http://10.0.0.169/insertBooking.php");
            NameValueCollection parameter = new NameValueCollection();

            parameter.Add("cname", txtCname.Text);
            parameter.Add("ename", txtEname.Text);
            parameter.Add("adate", txtDate.Text);
            parameter.Add("atime", txtTime.Text);

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