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
    [Activity(Label = "Insert Client", Theme = "@style/AppTheme.NoActionBar")]
    class ClientInsert : AppCompatActivity
    {
        private EditText txtFname;
        private EditText txtLname;
        private EditText txtNumber;
        private EditText txtEmail;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.client_insert);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.MenuItemClick += Menu_Clicked;

            Button btn = FindViewById<Button>(Resource.Id.btninsert);
            btn.Click += button_click;

            txtFname = FindViewById<EditText>(Resource.Id.etFname);
            txtLname = FindViewById<EditText>(Resource.Id.etLname);
            txtNumber = FindViewById<EditText>(Resource.Id.etNumber);
            txtEmail = FindViewById<EditText>(Resource.Id.etEmail);
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


        private void button_click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("http://10.0.0.169/insertClient.php");
            NameValueCollection parameter = new NameValueCollection();

            parameter.Add("fname", txtFname.Text);
            parameter.Add("lname", txtLname.Text);
            parameter.Add("number", txtNumber.Text);
            parameter.Add("email", txtEmail.Text);

            client.UploadValuesCompleted += Client_UploadValuesCompleted;
            client.UploadValuesAsync(uri, parameter);
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            var intent = new Intent(this, typeof(ClientActivity));
            StartActivity(intent);
        }
    }
}