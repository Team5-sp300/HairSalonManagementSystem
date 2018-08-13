﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    [Activity(Label = "Clients", Theme = "@style/AppTheme.NoActionBar")]
    public class ClientInformatin : AppCompatActivity
    {

        List<string> items;
        ListView listview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.client_details);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            listview = FindViewById<ListView>(Resource.Id.listView1);

            items = new List<string>();
            items.Add(Intent.GetStringExtra("fname"));
            items.Add(Intent.GetStringExtra("lname"));
            items.Add(Intent.GetStringExtra("number"));
            items.Add(Intent.GetStringExtra("email"));

            ClientDetailsListAdapter adapter = new ClientDetailsListAdapter(this, items);
            listview.Adapter = adapter;

        }
    }
}
