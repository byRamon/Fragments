using Android.Widget;
using Android.OS;
using System;

namespace Fragments
{
    public class InformacionFragment : Android.Support.V4.App.ListFragment
    {
        public void updateInformacion(string[] ciudades)
        {
            ListAdapter = new ArrayAdapter(
                Activity,
                Android.Resource.Layout.SimpleListItem1,
                ciudades);
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (savedInstanceState != null)
            {
                string ciudad = savedInstanceState.GetString("LLAVE_GUARDADA");
                if (!string.IsNullOrEmpty(ciudad))
                {
                    string[] ciudades = ciudad.Split('|');
                    ListAdapter = new ArrayAdapter(
                        Activity,
                        Android.Resource.Layout.SimpleListItem1,
                        ciudades);
                    System.Threading.Tasks.Task.Run(() => { ponerImagen(ciudades[0]); });                    
                }
            }
        }
        private void ponerImagen(string value)
        {
            var informacionFragment = this as InformacionFragment;
            bool mostrado = false;
            while(!mostrado)
            {
                if (informacionFragment.View != null)
                {
                    mostrado = true;
                    if (value == "Aguascalientes")
                        informacionFragment.View.SetBackgroundResource(Resource.Drawable.Aguascalientes);
                    else if (value == "Calvillo")
                        informacionFragment.View.SetBackgroundResource(Resource.Drawable.Calvillo);
                    else
                        informacionFragment.View.SetBackgroundResource(Resource.Drawable.propiedades);
                }
            }
        }
        public override void OnStart()
        {
            base.OnStart();
            if (Arguments != null)
                updateInformacion(Arguments.GetStringArray("ciudades"));
        }
        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            string ciudad = "";
            if (ListAdapter != null) {
                for (int ind = 0; ind < ListAdapter.Count; ind++)
                {
                    var obj = ListAdapter.GetItem(ind);
                    ciudad += "" + (ciudad.Length > 0 ? "|" : "") + obj.ToString();
                }
                outState.PutString("LLAVE_GUARDADA", ciudad);
            }
        }

    }
}