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
using Android.Views.InputMethods;
using Android.Widget;
using Newtonsoft.Json;

namespace HHmobileApp
{
    [Activity(Label = "Login", Theme = "@style/AppTheme.NoActionBar")]
    public class LoginActivity : AppCompatActivity
    {
        private string ip;
        private List<LoginDetails> loginDetails;
        private EditText textName;
        private EditText textPassword;
        private TextView textView;
        private CheckBox checkbox;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
            ip = pref.GetString("IP", String.Empty);
            Console.WriteLine("Here");
            Console.WriteLine(ip);

            Button btn = FindViewById<Button>(Resource.Id.btninsert);
            btn.Click += button_click;

            checkbox = FindViewById<CheckBox>(Resource.Id.cbRemeberMe);
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

        private void button_click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus?.WindowToken, HideSoftInputFlags.None);

            WebClient client = new WebClient();
            Uri uri = new Uri("http://"+ip+"/login.php");
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += download;
        }


        private void download(object sender, DownloadDataCompletedEventArgs e)
        {
            textName = FindViewById<EditText>(Resource.Id.etusername);
            textPassword = FindViewById<EditText>(Resource.Id.etPass);
            textView = FindViewById<TextView>(Resource.Id.textError);

            string json = Encoding.UTF8.GetString(e.Result);
            loginDetails = JsonConvert.DeserializeObject<List<LoginDetails>>(json);
            for (int i = 0; i < loginDetails.Count; i++)
            {
                if (loginDetails[i].name.Equals(textName.Text) && loginDetails[i].password.Equals(textPassword.Text))
                {
                    var intent = new Intent(this, typeof(HomeActivity));
                    intent.PutExtra("Username", textName.Text);
                    if (checkbox.Checked)
                    {
                        ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
                        ISharedPreferencesEditor edit = pref.Edit();
                        edit.PutString("Username", textName.Text);
                        edit.PutString("Password", textPassword.Text);
                        edit.Apply();
                    }
                    StartActivity(intent);
                    break;
                }
                else if (i.Equals(loginDetails.Count - 1))
                {
                    textView.Visibility = ViewStates.Visible;
                }
                //else if (i.Equals(loginDetails.Count))
                //{

                //}

            }
        }
    }
}

