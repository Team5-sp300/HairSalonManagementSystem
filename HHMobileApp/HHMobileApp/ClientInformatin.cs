using System;
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
            toolbar.MenuItemClick += Menu_Clicked;

            listview = FindViewById<ListView>(Resource.Id.listView1);

            items = new List<string>();
            items.Add(Intent.GetStringExtra("fname"));
            items.Add(Intent.GetStringExtra("lname"));
            items.Add(Intent.GetStringExtra("number"));
            items.Add(Intent.GetStringExtra("email"));

            ClientDetailsListAdapter adapter = new ClientDetailsListAdapter(this, items);
            listview.Adapter = adapter;

        }

        private void Menu_Clicked(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.ItemId == Resource.Id.action_back)
            {
                var intent = new Intent(this, typeof(ClientActivity));
                StartActivity(intent);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

    }
}
