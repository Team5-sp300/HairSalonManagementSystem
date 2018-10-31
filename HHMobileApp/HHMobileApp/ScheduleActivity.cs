using System;
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
    [Activity(Label = "Schedule", Theme = "@style/AppTheme.NoActionBar")]
    public class ScheduleActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private string ip;
        private List<ScheduleDetails> items;
        private ListView listview;
        private WebClient client;
        private Uri uri;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.schedule_activity);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
            ip = pref.GetString("IP", String.Empty);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();


            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            listview = FindViewById<ListView>(Resource.Id.listView1);
            listview.ItemClick += Listview_ItemClick;

            client = new WebClient();
            uri = new Uri("http://" + ip + "/getSchedule.php");
            NameValueCollection parameter = new NameValueCollection();
            parameter.Add("username", pref.GetString("Username", String.Empty));

            client.UploadValuesCompleted += Client_UploadValuesCompleted;
            client.UploadValuesAsync(uri, parameter);
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            ScheduleListAdapter adapter;
            RunOnUiThread(() =>
            {
                
            string json = Encoding.UTF8.GetString(e.Result);
                try
                {
                    items = JsonConvert.DeserializeObject<List<ScheduleDetails>>(json);
                     adapter = new ScheduleListAdapter(this, items, 1);
                }
                catch (Newtonsoft.Json.JsonSerializationException) {
                    items = new List<ScheduleDetails>();
                     adapter = new ScheduleListAdapter(this, items, 0);
                    TextView textView = FindViewById<TextView>(Resource.Id.textError);
                    textView.Visibility = ViewStates.Visible;
                }
                listview.Adapter = adapter;
            });
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

        //private void download(object sender, DownloadDataCompletedEventArgs e)
        //{
        //    RunOnUiThread(() =>
        //    {
        //        string json = Encoding.UTF8.GetString(e.Result);
        //        items = JsonConvert.DeserializeObject<List<ScheduleDetails>>(json);
        //        ScheduleListAdapter adapter = new ScheduleListAdapter(this, items,1);
        //        listview.Adapter = adapter;
        //    });

        //}

        private void button_click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BookingInsert));
            StartActivity(intent);
        }

        private void Listview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(BookingInformatin));
            intent.PutExtra("type", "1");
            intent.PutExtra("id", items[e.Position].id);
            intent.PutExtra("cname", items[e.Position].cusomter);
            intent.PutExtra("date", items[e.Position].date);
            intent.PutExtra("time", items[e.Position].time);
            intent.PutExtra("length", items[e.Position].length);
            intent.PutExtra("service", items[e.Position].service);
            StartActivity(intent);
        }

    }
}

