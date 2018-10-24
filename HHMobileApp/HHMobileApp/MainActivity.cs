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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private string IP = "10.0.0.169";
        private string ip;
        private string username;
        private string password;
        private List<LoginDetails> loginDetails;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfor", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutString("IP", IP);
            edit.Apply();

            username = pref.GetString("Username", String.Empty);
            password = pref.GetString("Password", String.Empty);
            ip = pref.GetString("IP", String.Empty);
    

            if (username == String.Empty || password == String.Empty)
            {
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            }
            else
            {
                WebClient client = new WebClient();
                Uri uri = new Uri("http://"+ip+"/login.php");
                client.DownloadDataAsync(uri);
                client.DownloadDataCompleted += download;
            }
        }

        private void download(object sender, DownloadDataCompletedEventArgs e)
        {

            string json = Encoding.UTF8.GetString(e.Result);
            loginDetails = JsonConvert.DeserializeObject<List<LoginDetails>>(json);
            for (int i = 0; i < loginDetails.Count; i++)
            {
                if (loginDetails[i].name.Equals(username) && loginDetails[i].password.Equals(password))
                {
                    var intent = new Intent(this, typeof(HomeActivity));
                    StartActivity(intent);
                    break;
                }
                else if(i.Equals(loginDetails.Count))
                {
                    var intent = new Intent(this, typeof(LoginActivity));
                    StartActivity(intent);
                    break;
                }
            }

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
    }
}

