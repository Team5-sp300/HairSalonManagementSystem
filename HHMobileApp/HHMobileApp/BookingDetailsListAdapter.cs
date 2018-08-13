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
    class BookingDetailsListAdapter : BaseAdapter<string>
    {
        List<string> items;
        Context context;

        public BookingDetailsListAdapter(Context context, List<string> items)
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

        public override string this[int position]
        {
            get { return items[position]; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.details_listview_row, null, false);
            }

            TextView txtname = row.FindViewById<TextView>(Resource.Id.txtnameid);
            switch (position)
            {
                case 0:
                    txtname.Text = "Customer Name";
                    break;
                case 1:
                    txtname.Text = "Stylist Name";
                    break;
                case 2:
                    txtname.Text = "Appointment Date";
                    break;
                case 3:
                    txtname.Text = "Appointment Time";
                    break;
            }

            TextView txtvalue = row.FindViewById<TextView>(Resource.Id.txtvalue);
            txtvalue.Text = items[position];

            return row;
        }
    }
}