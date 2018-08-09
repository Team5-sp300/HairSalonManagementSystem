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

        List<ClientDetails> items;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.client_details);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            TextView fname = FindViewById<TextView>(Resource.Id.textView3);
            fname.Text = Intent.GetStringExtra("fname");

            TextView lname = FindViewById<TextView>(Resource.Id.textView5);
            lname.Text = Intent.GetStringExtra("lname");

            TextView number = FindViewById<TextView>(Resource.Id.textView7);
            number.Text = Intent.GetStringExtra("number");

            TextView email = FindViewById<TextView>(Resource.Id.textView9);
            email.Text = Intent.GetStringExtra("email");
        }
    }
}
