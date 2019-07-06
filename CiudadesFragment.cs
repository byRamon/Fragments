using System;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Widget;

namespace Fragments
{
    public class CiudadesFragment: Android.Support.V4.App.ListFragment
    {
        ICiudadSeleccionada CiudadSeleccionada;
        string ciudad;
        public void updateCiudades(string[] ciudades)
        {
            ListAdapter = new ArrayAdapter(
                Activity,
                Android.Resource.Layout.SimpleListItem1,
                ciudades);
            ListView.ItemClick += (sender, e) =>
            {
                if (CiudadSeleccionada != null)
                {
                    ciudad = ciudades[e.Id];
                    sendFragment();
                }
            };
        }
        public override void OnStart()
        {
            base.OnStart();
            if (Arguments != null)
                updateCiudades(Arguments.GetStringArray("ciudades"));
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HasOptionsMenu = true;
            if (savedInstanceState != null)
            {
                ciudad = savedInstanceState.GetString("LLAVE_GUARDADA");
                if(!string.IsNullOrEmpty(ciudad))
                {
                    ListAdapter = new ArrayAdapter(
                        Activity,
                        Android.Resource.Layout.SimpleListItem1,
                        ciudad.Split('|'));
                }
            }
        }
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            if (!menu.HasVisibleItems)
                inflater.Inflate(Resource.Menu.menu_ciudades, menu);
        }
        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            string ciudad = "";
            if (ListAdapter != null)
            {
                for (int ind = 0; ind < ListAdapter.Count; ind++)
                {
                    var obj = ListAdapter.GetItem(ind);
                    ciudad += "" + (ciudad.Length > 0 ? "|" : "") + obj.ToString();
                }
                outState.PutString("LLAVE_GUARDADA", ciudad);
            }
        }
        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            CiudadSeleccionada = context as ICiudadSeleccionada;
        }

        private void sendFragment()
        {
            string descripcion = "";
            if (ciudad == "Aguascalientes")
            {
                descripcion = "Es una ciudad de la zona central de México, conocida por los edificios coloniales españoles de su centro histórico";
            }
            if (ciudad == "Calvillo")
            {
                descripcion = "Calvillo es una localidad y cabecera del municipio de Calvillo, en el suroeste del estado de Aguascalientes";
            }
            if (ciudad == "Ocosingo")
            {
                descripcion = "Ocosingo";
            }
            if (ciudad == "Palenque")
            {
                descripcion = "Palenque";
            }
            if (ciudad == "Ahumada")
            {
                descripcion = "Ahumada";
            }
            if (ciudad == "Aldama")
            {
                descripcion = "Aldama";
            }
            if (ciudad == "Abasolo")
            {
                descripcion = "Abasolo";
            }
            if (ciudad == "Allende")
            {
                descripcion = "Allende";
            }
            if (ciudad == "Armería")
            {
                descripcion = "Armería";
            }
            if (ciudad == "Colima")
            {
                descripcion = "Colima";
            }
            if (ciudad == "Irapuato")
            {
                descripcion = "Irapuato";
            }
            if (ciudad == "León")
            {
                descripcion = "León";
            }
            if (ciudad == "Romita")
            {
                descripcion = "Romita";
            }
            if (ciudad == "Silao")
            {
                descripcion = "Silao";
            }
            if (ciudad == "Canatlán")
            {
                descripcion = "Canatlán";
            }
            if (ciudad == "Canelas")
            {
                descripcion = "Canelas";
            }
            if (ciudad == "Apozol")
            {
                descripcion = "Apozol";
            }
            if (ciudad == "Apulco")
            {
                descripcion = "Apulco";
            }
            if (ciudad == "Acaponeta")
            {
                descripcion = "Acaponeta";
            }
            if (ciudad == "Ahuacatlán")
            {
                descripcion = "Ahuacatlán";
            }
            if (ciudad == "Acuitzio")
            {
                descripcion = "Acuitzio";
            }
            if (ciudad == "Aguililla")
            {
                descripcion = "Aguililla";
            }
            string[] items = { ciudad, descripcion };
            CiudadSeleccionada.OnCiudadSeleccionada(items);
        }        
    }
}