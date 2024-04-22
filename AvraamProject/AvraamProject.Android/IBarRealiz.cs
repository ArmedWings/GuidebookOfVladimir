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

using AvraamProject;
using AvraamProject.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(IBarRealiz))]
namespace AvraamProject
{
    public class IBarRealiz : IBar
    {
        public async void SetStatusBarColor(Xamarin.Forms.Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var window = Xamarin.Essentials.Platform.CurrentActivity.Window;
                
                window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                window.SetStatusBarColor(color.ToAndroid());
                window.SetNavigationBarColor(color.ToAndroid());
                var navigationPage = Xamarin.Forms.Application.Current.MainPage as NavigationPage;
            }
        }
        public void SetFullScreen()
        {
            var window = Xamarin.Essentials.Platform.CurrentActivity.Window;
            Android.Views.View decorView = window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;


            if (Xamarin.Forms.Application.Current.Properties.TryGetValue("Screen", out object screenValue))
            {
                switch (screenValue.ToString())
                {
                    case "1":
                        // Скрыть навигационную панель и сделать экран полноэкранным с поверхностью статус-бара
                        uiOptions |= (int)SystemUiFlags.HideNavigation | (int)SystemUiFlags.Fullscreen | (int)SystemUiFlags.LayoutFullscreen | (int)SystemUiFlags.ImmersiveSticky;

                        // Обновить системный интерфейс
                        decorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
                        break;
                    default:
                        // Сбросить флаги для полноэкранного режима и скрытия навигационной панели
                        uiOptions &= ~((int)SystemUiFlags.HideNavigation | (int)SystemUiFlags.Fullscreen | (int)SystemUiFlags.LayoutFullscreen | (int)SystemUiFlags.ImmersiveSticky);
                        
                        // Обновить системный интерфейс
                        decorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
                        break;
                }
            }
        }
    }
}
