using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("TDSofiya.otf", Alias = "Sofia")]
[assembly: ExportFont("Seminaria.ttf", Alias = "Seminaria")]
namespace AvraamProject
{
    public partial class App : Application
    {
        public App()
        {
            
            //Application.Current.Properties.Remove("IsFirstRun");
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("IsFirstRun") && (bool)Application.Current.Properties["IsFirstRun"] == false)
            { }
            else
            {
                Application.Current.Properties["IsFirstRun"] = false;
                Application.Current.Properties["Accent"] = "1";
                Application.Current.Properties["Language"] = "ru";
                Application.Current.Properties["Screen"] = "1";

                // Сохранение изменений
                Application.Current.SavePropertiesAsync();
            }


            AccentManager.ApplyAccentColors();
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                var myService = DependencyService.Get<IBar>();
                myService.SetStatusBarColor(Color.FromHex(AccentManager.MainAppAccent));
                myService.SetFullScreen();
            }
            MainPage = new NavigationPage(new StartPage())
            {
                BarBackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                BarTextColor = Color.FromHex(AccentManager.MainTextAccent)
            };

        }

        protected override void OnStart()
        {
            base.OnStart();
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
