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
    class ClientListAdapter : BaseAdapter<ClientDetails>
    {
        List<ClientDetails> items;
        Context context;

        public ClientListAdapter(Context context, List<ClientDetails> items)
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

        public override ClientDetails this[int position]
        {
            get { return items[position]; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.client_listview_row, null, false);
            }

            TextView fname = row.FindViewById<TextView>(Resource.Id.txtfname);
            fname.Text = items[position].fname+" "+ items[position].lname;

            return row;
        }
    }
}