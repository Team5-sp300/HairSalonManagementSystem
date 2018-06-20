using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using System.Net;
using System.Collections.Specialized;

namespace HHMobileApp
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        EditText textName;
        EditText textPassword;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Button btn = FindViewById<Button>(Resource.Id.btninsert);
            btn.Click += button_click;

            
            textName= FindViewById<EditText>(Resource.Id.etusername);

         
            textPassword = FindViewById<EditText>(Resource.Id.etPass);
        }

        private void button_click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("http://10.0.0.169/Insert.php");
            NameValueCollection parameter = new NameValueCollection();
            parameter.Add("Name", textName.Text);
            parameter.Add("Password", textPassword.Text);
            client.UploadValuesCompleted += uploaded;
            client.UploadValuesAsync(uri, parameter);
            //client.DownloadDataAsync(uri);
            //client.DownloadDataCompleted += download;
        }

        private void download(object sender, DownloadDataCompletedEventArgs e)
        {
            
        }

        private void uploaded(object sender, UploadValuesCompletedEventArgs e)
        {
         
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

