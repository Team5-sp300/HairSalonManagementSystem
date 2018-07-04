using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Android;
using Android.App;
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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        List<loginDetails> loginDetails;
        EditText textName;
        EditText textPassword;
        TextView textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            Button btn = FindViewById<Button>(Resource.Id.btninsert);
            btn.Click += button_click;

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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        private void button_click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("http://10.0.0.169/Retrieve.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download;
        }


        private void download(object sender, DownloadDataCompletedEventArgs e)
        {
            textName = FindViewById<EditText>(Resource.Id.etusername);
            textPassword = FindViewById<EditText>(Resource.Id.etPass);
            textView = FindViewById<TextView>(Resource.Id.textError);

            string json = Encoding.UTF8.GetString(e.Result);
            loginDetails = JsonConvert.DeserializeObject<List<loginDetails>>(json);
            for (int i = 0; i < loginDetails.Count; i++)
            {
                if (loginDetails[i].name.Equals(textName.Text) && loginDetails[i].password.Equals(textPassword.Text))
                {
                    SetContentView(Resource.Layout.home_main);
                }
                else {
                    textView.Visibility = ViewStates.Visible;
                }
            }
           
        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_home)
            {
                SetContentView(Resource.Layout.home_main);
            }
            else if (id == Resource.Id.nav_bookings)
            {
                SetContentView(Resource.Layout.booking_main);
            }
            else if (id == Resource.Id.nav_clients)
            {

            }
            else if (id == Resource.Id.nav_settings)
            {

            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
           // drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}

