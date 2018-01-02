using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Lekcja3._1.Fragments;

namespace Lekcja3._1
{
    [Activity(Label = "Nazwa_Activity", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainActivity);
            // dostajemy sie do toolbara
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Witamy w aplikacji Xamarin - 1 PK";
            SetSupportActionBar(toolbar);

            // powór do poprzedniego ekranu - strzałka
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            toolbar.NavigationClick += (s, e) =>
            {
                OnBackPressed();
            };
            // fragment manager - 
            // wyświetlamy mainfragment
            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();

            MainFragment mainFragment = new MainFragment();

            fragmentTransaction.Add(Resource.Id.fragment_container, mainFragment, "MAIN_FRAGMENT");
            fragmentTransaction.Commit();

            // obsługa przejść miedzy fragmentami
            FragmentManager.BackStackChanged += (s, e) =>
            {
                if(FragmentManager.BackStackEntryCount > 0)
                {
                    SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(true);
                }
                else
                {
                    SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(false);
                }
            };
        }
    }
}

