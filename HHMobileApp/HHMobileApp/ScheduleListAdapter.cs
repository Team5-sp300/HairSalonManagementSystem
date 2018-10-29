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
    class ScheduleListAdapter : BaseAdapter<ScheduleDetails>
    {
        List<ScheduleDetails> items;
        Context context;
        int type;

        public ScheduleListAdapter(Context context, List<ScheduleDetails> items, int type)
        {
            this.items = items;
            this.context = context;
            this.type = type;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ScheduleDetails this[int position]
        {
            get { return items[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.schedule_listview_row, null, false);
            }

            TextView txtname = row.FindViewById<TextView>(Resource.Id.txtName);
            txtname.Text = items[position].cusomter;

            TextView txtdate = row.FindViewById<TextView>(Resource.Id.txtDate);
            txtdate.Text = items[position].date;

            TextView txttime = row.FindViewById<TextView>(Resource.Id.txtTime);
            txttime.Text = items[position].time;

            TextView txtduration = row.FindViewById<TextView>(Resource.Id.txtduration);
            txtduration.Text = items[position].length + " Minutes";

            return row;
        }
    }
}