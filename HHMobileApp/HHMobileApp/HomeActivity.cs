﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace HHmobileApp
{
    [Activity(Label = "Home", Theme = "@style/AppTheme.NoActionBar")]
    public class HomeActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home_activity);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            DrawerLayout drawer1 = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle1 = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            Button btn = FindViewById<Button>(Resource.Id.btnsignout);
            btn.Click += button_click;

            TextView greeting = FindViewById<TextView>(Resource.Id.txtWelcome);
            greeting.Text ="Welcome \n"+ Intent.GetStringExtra("Username");


        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.menu_main, menu);
        //    return true;
        //}



        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_home)
            {
                var intent = new Intent(this, typeof(HomeActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_schedule)
            {
                var intent = new Intent(this, typeof(ScheduleActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_bookings)
            {
                var intent = new Intent(this, typeof(BookingActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_clients)
            {
                var intent = new Intent(this, typeof(ClientActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_logout)
            {
                ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
                ISharedPreferencesEditor edit = pref.Edit();
                edit.Clear();
                edit.Apply();
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            }




            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        private void button_click(object sender, EventArgs e)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.Clear();
            edit.Apply();
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }

    }
}

