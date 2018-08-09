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
    public class BookingInformatin : AppCompatActivity
    {

        List<ClientDetails> items;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.booking_details);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            TextView cname = FindViewById<TextView>(Resource.Id.textView3);
            cname.Text = Intent.GetStringExtra("cname");

            TextView ename = FindViewById<TextView>(Resource.Id.textView5);
            ename.Text = Intent.GetStringExtra("ename");

            TextView date = FindViewById<TextView>(Resource.Id.textView7);
            date.Text = Intent.GetStringExtra("date");

            TextView time = FindViewById<TextView>(Resource.Id.textView9);
            time.Text = Intent.GetStringExtra("time");
        }
    }
}
