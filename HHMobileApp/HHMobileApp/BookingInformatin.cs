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
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace HHmobileApp
{
    [Activity(Label = "Booking", Theme = "@style/AppTheme.NoActionBar")]
    public class BookingInformatin : AppCompatActivity
    {

        List<string> items;
        ListView listview;
        BookingDetailsListAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.booking_details);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.MenuItemClick += Menu_Clicked;

            listview = FindViewById<ListView>(Resource.Id.listView1);

            items = new List<string>();
            items.Add(Intent.GetStringExtra("cname"));
            if (Intent.GetStringExtra("type").Equals("0"))
            {
                items.Add(Intent.GetStringExtra("ename"));
                adapter = new BookingDetailsListAdapter(this, items, 0);
            }
            items.Add(Intent.GetStringExtra("date"));
            items.Add(Intent.GetStringExtra("time"));
        
            if (Intent.GetStringExtra("type").Equals("1"))
            {
                items.Add(Intent.GetStringExtra("length"));
                adapter = new BookingDetailsListAdapter(this, items, 1);
            }
            items.Add(Intent.GetStringExtra("service"));

            listview.Adapter = adapter;

            Button btn = FindViewById<Button>(Resource.Id.btncancelbooking);
            btn.Click += button_click;

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
            Uri uri = new Uri("http://10.0.0.169/cancelBooking.php");
            NameValueCollection parameter = new NameValueCollection();

            parameter.Add("id", Intent.GetStringExtra("id"));

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
