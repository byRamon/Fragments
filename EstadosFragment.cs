using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Fragments
{
    public class EstadosFragment : Android.Support.V4.App.ListFragment
    {
        IEstadoSeleccionado estadoSeleccionado;
        long id;
        public override void OnStart()
        {
            base.OnStart();
            ListAdapter = new ArrayAdapter(
                Activity,
                Android.Resource.Layout.SimpleListItem1,
                new[] { "Aguascalientes","Chiapas","Chihuahua","Coahuila","Colima","Guanajuato", "Durango", "Zacatecas", "Nayarit", "Michoacan" });

            ListView.ItemClick += (sender, e) => {
                if (estadoSeleccionado != null)
                {
                    sendFragment(e.Id);
                }
            };
        }
        private void sendFragment(long idSeleccionado)
        {
            string[] items = null;
            if (idSeleccionado == 0)
                items = new string[] { "Aguascalientes", "Calvillo" };
            if (idSeleccionado == 1)
                items = new string[] { "Ocosingo", "Palenque" };
            if (idSeleccionado == 2)
                items = new string[] { "Ahumada", "Aldama" };
            if (idSeleccionado == 3)
                items = new string[] { "Abasolo", "Allende" };
            if (idSeleccionado == 4)
                items = new string[] { "Armería", "Colima" };
            if (idSeleccionado == 5)
                items = new string[] { "Irapuato", "León", "Silao", "Romita" };
            if (idSeleccionado == 6)
                items = new string[] { "Canatlán", "Canelas" };
            if (idSeleccionado == 7)
                items = new string[] { "Apozol", "Apulco" };
            if (idSeleccionado == 8)
                items = new string[] { "Acaponeta", "Ahuacatlán" };
            if (idSeleccionado == 9)
                items = new string[] { "Acuitzio", "Aguililla" };
            id = idSeleccionado;
            estadoSeleccionado.OnEstadoSeleccionado(items);
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            estadoSeleccionado = context as IEstadoSeleccionado;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (savedInstanceState != null)
            {
                //id = -1;
                //long.TryParse(savedInstanceState.GetString("LLAVE_GUARDADA"), out id);
                //if (id > -1)
                //    sendFragment(id);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString("LLAVE_GUARDADA", "" + id);
        }
    }
}