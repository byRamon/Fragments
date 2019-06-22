using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Fragments
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IEstadoSeleccionado, ICiudadSeleccionada
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            FrameLayout contenedor = FindViewById<FrameLayout>(Resource.Id.contenedorFragment);
            if (contenedor != null)
            {
                Android.Support.V4.App.Fragment estados = SupportFragmentManager.FindFragmentById(Resource.Id.estados);
                if (savedInstanceState == null || estados == null)
                {
                    estados = new EstadosFragment();
                    SupportFragmentManager.BeginTransaction().Add(Resource.Id.contenedorFragment, estados).Commit();
                }
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void OnEstadoSeleccionado(string[] ciudades)
        {
            FrameLayout contenedor = FindViewById<FrameLayout>(Resource.Id.contenedorFragment);
            if (contenedor != null)
            {
                Bundle args = new Bundle();
                args.PutStringArray("ciudades", ciudades);
                CiudadesFragment ciudadesFragment = new CiudadesFragment();
                ciudadesFragment.Arguments = args;
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.contenedorFragment, ciudadesFragment).AddToBackStack(null).Commit();
            }
            else
            {
                var ciudadesFragment = SupportFragmentManager.FindFragmentById(Resource.Id.ciudades) as CiudadesFragment;
                ciudadesFragment.updateCiudades(ciudades);
            }
        }
        public void OnCiudadSeleccionada(string[] ciudades)
        {
            var informacionFragment = SupportFragmentManager.FindFragmentById(Resource.Id.Informacion) as InformacionFragment;
            informacionFragment.View.SetBackgroundResource(Resource.Drawable.propiedades);
            if (ciudades[0] == "Aguascalientes")
                informacionFragment.View.SetBackgroundResource(Resource.Drawable.Aguascalientes);
            if (ciudades[0] == "Calvillo")
                informacionFragment.View.SetBackgroundResource(Resource.Drawable.Calvillo);
            //android:background="#ddffffff"
            //LinearLayout l = (LinearLayout)FindViewById(Resource.Id.Informacion);
            //l.SetBackgroundResource(Resource.Drawable.propiedades);            
            informacionFragment.updateInformacion(ciudades);
        }
    }
}