using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Net;
using System;
using System.IO;
using Org.Json;

namespace HHMobileApp
{
    [Activity(Label = "XamarinLoadListView", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        ListView list;
        System.Collections.ArrayList records;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            list = (ListView)FindViewById(Resource.Id.listView1);   // refering list view of xml
            records = new System.Collections.ArrayList();
            getJSONValues();

            String[] myArr = (String[])records.ToArray(typeof(string));
            //setting array adapter with item layout
            ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.item, Resource.Id.textView1, (System.Collections.IList)records);
            list.SetAdapter(adapter);  // setting adapter to list view
            list.ItemClick += List_ItemClick;
        }

        void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

        }

        public void getJSONValues()
        {
            var request = HttpWebRequest.Create(string.Format(@"http://your_server_ip/LoadData/load_list.php"));
            request.ContentType = "application/json";
            request.Method = "GET";
            var content = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        Console.Out.WriteLine("Response Body: \r\n {0}", content);
                    }
                 //   Assert.NotNull(content);
                }
            }

            try
            {
                JSONArray json = new JSONArray(content);
                for (int i = 0; i <= json.Length(); i++)
                {
                    JSONObject obj = json.GetJSONObject(i);
                    String name = obj.GetString("name");
                    records.Add(name);
                }
            }
            catch (JSONException e)
            {
                e.StackTrace.ToString();
            }

            Toast.MakeText(this, content, ToastLength.Short).Show();
        }
    }
}

