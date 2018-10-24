using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace HHmobileApp
{
    [Activity(Label = "Insert Client", Theme = "@style/AppTheme.NoActionBar")]
    class ClientInsert : AppCompatActivity
    {
        private string ip;
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

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
            ip = pref.GetString("IP", String.Empty);

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
            InputMethodManager inputManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(txtFname.WindowToken, 0);
            inputManager.HideSoftInputFromWindow(txtLname.WindowToken, 0);
            inputManager.HideSoftInputFromWindow(txtNumber.WindowToken, 0);
            inputManager.HideSoftInputFromWindow(txtEmail.WindowToken, 0);

            if (!ValidateName(txtFname.Text))
            {
                txtFname.Error = "Enter Valid First Name";
                return;
            }
            if (!ValidateName(txtLname.Text))
            {
                txtLname.Error = "Enter Valid Last Name";
                return;
            }
            if (!ValidateNumber(txtNumber.Text))
            {
                txtNumber.Error = "Enter Valid Cell No.";
                return;
            }
            if (!ValidateEmail(txtEmail.Text))
            {
                txtEmail.Error = "Enter Valid Email";
                return;
            }
            else
            {

                WebClient client = new WebClient();
                Uri uri = new Uri("http://"+ip+"/insertClient.php");
                NameValueCollection parameter = new NameValueCollection();

                parameter.Add("fname", txtFname.Text);
                parameter.Add("lname", txtLname.Text);
                parameter.Add("number", txtNumber.Text);
                parameter.Add("email", txtEmail.Text);

                client.UploadValuesCompleted += Client_UploadValuesCompleted;
                client.UploadValuesAsync(uri, parameter);
            }
           
        }



        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            var intent = new Intent(this, typeof(ClientActivity));
            StartActivity(intent);
        }

        protected bool ValidateName(string name)
        {
            string pattern = @"^[A-Za-z]+$";
            var regex = new Regex(pattern);
            Log.Debug("V", regex.IsMatch(name).ToString());
            return regex.IsMatch(name);
        }
        protected bool ValidateNumber(string number)
        {
            string pattern = @"^[0-9]{10}$";
            var regex = new Regex(pattern);
            Log.Debug("V", regex.IsMatch(number).ToString());
            return regex.IsMatch(number);
        }
        protected bool ValidateEmail(string email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var regex = new Regex(pattern);
            Log.Debug("V", regex.IsMatch(email).ToString());
            return regex.IsMatch(email);
        }
    

    }
}