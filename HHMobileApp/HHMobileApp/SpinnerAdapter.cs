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
    class SpinnerAdapter : BaseAdapter<SpinnerDetails>
    {
        List<SpinnerDetails> items;
        Context context;

        public SpinnerAdapter(Context context, List<SpinnerDetails> items)
        {
            this.items = items;
            this.context = context;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override SpinnerDetails this[int position]
        {
            get { return items[position]; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.spinner_row, null, false);
            }

            TextView txtname = row.FindViewById<TextView>(Resource.Id.txtspinnername);
            txtname.Text = items[position].fname+" "+ items[position].lname;

            return row;
        }
    }
}