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

namespace Fragments
{
    public class ContentDetallesCiudad : Android.Support.V4.App.ListFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.content_detalles_ciudad, container, false);

        }
        public void updatedDetallesCiudad(string texto)
        {
            var textView = Activity.FindViewById<TextView>(Resource.Id.textView);
            textView.Text = texto;
        }
    }
}