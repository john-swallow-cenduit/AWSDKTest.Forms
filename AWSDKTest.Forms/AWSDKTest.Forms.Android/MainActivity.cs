using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Com.Airwatch.Sdk;

namespace AWSDKTest.Forms.Droid
{
    [Activity(Label = "AWSDKTest.Forms", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            try
            {
                var sdkmanager = SDKManager.Init(this);
                var deviceId = sdkmanager.DeviceUid;
                Console.WriteLine($"DeviceId: {deviceId}");
            }
            catch (AirWatchSDKException ex)
            {
                var resultCode = ex.ErrorCode;
                throw;
            }           

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}