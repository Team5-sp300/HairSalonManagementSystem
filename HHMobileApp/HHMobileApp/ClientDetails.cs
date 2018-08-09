using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HHmobileApp
{
    class ClientDetails
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string number { get; set; }
        public string email { get; set; }
    }
}