using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HHMobileApp
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        EditText textName;
        EditText textPassword;
        List<Employee> items;
        ListView view;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

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
        }

      
        private void uploaded(object sender, UploadValuesCompletedEventArgs e)
        {
            SetContentView(Resource.Layout.employee_list);
            view = FindViewById<ListView>(Resource.Id.listView1);

            //items = new List<Employee>();
            //items.Add(new Employee() { name = "Andrew", password = "12345" });
            //items.Add(new Employee() { name = "Paul", password = "124645" });
           

            

            WebClient client = new WebClient();
            Uri uri = new Uri("http://10.0.0.169/Retrieve.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download;
        }

        private void download(object sender, DownloadDataCompletedEventArgs e)
        {
            RunOnUiThread(() =>
                {
                string json = Encoding.UTF8.GetString(e.Result);
                items = JsonConvert.DeserializeObject<List<Employee>>(json);
                nListViewApdater adapter = new nListViewApdater(this, items);
                view.Adapter = adapter;
            });
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

