using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RutaSegura.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher =true,NoHistory =true, ConfigurationChanges =ConfigChanges.ScreenSize, Label = "SplashActivity")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //System.Threading.Thread.Sleep(1000);
            //StartActivity(typeof(MainActivity));
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            // Create your application here
        }
    }
}