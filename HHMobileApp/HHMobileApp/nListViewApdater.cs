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

namespace HHMobileApp
{
    class nListViewApdater : BaseAdapter<Employee>
    {
        List<Employee> items;
        Context context;

        public nListViewApdater(Context context, List<Employee> items)
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

        public override Employee this[int position] {
            get { return items[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null){
                row = LayoutInflater.From(context).Inflate(Resource.Layout.listview_row,null,false);
            }

            TextView txtname = row.FindViewById<TextView>(Resource.Id.txtName);
            txtname.Text = items[position].name;

            TextView txtPassword = row.FindViewById<TextView>(Resource.Id.txtPasword);
            txtPassword.Text = items[position].password;

            return row;
        }
    }
}