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
    class ScheduleDetails
    {
        public string id { get; set; }
        public string cusomter { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string service { get; set; }
        public string length { get; set; }
    }
}