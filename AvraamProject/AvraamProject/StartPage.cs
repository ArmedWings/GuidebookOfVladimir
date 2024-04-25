using System;
using System.IO;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using SkiaSharp.Extended.Svg;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms.PlatformConfiguration;
using System.Runtime.InteropServices;
using lang;



namespace AvraamProject
{
    public class StartPage : ContentPage
    {
        
        private ScrollView scrollView;
        private Image panoramaImage;
        private double currentX = 0;

        public StartPage()
        {
            var uiLang = Application.Current.Properties["Language"].ToString();
            NavigationPage.SetHasNavigationBar(this, false);
            AbsoluteLayout AbsoluteLayout = new AbsoluteLayout();

            BackgroundColor = Color.FromHex(AccentManager.SideAppAccent);

            panoramaImage = new Image
            {
                Source = SetBackground(Application.Current.Properties["Accent"].ToString(), Application.Current.Properties["Opt"].ToString()),
                Aspect = Aspect.AspectFill,
                Opacity = Application.Current.Properties["Opt"].ToString() == "3" ? 0 : 1
            };

            scrollView = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                Content = panoramaImage
            };
            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0.5),
                EndPoint = new Point(1, 0.5),
                GradientStops = new GradientStopCollection
                {
                    new GradientStop { Color = Color.FromHex(AccentManager.MainAppAccent), Offset = 0.0f },
                    new GradientStop { Color = Color.FromHex(AccentManager.SideTextAccent), Offset = 3.0f }
                }
            };
            Button button1 = new Button
            {
                Text = t.text("start", uiLang),
                FontSize = 30,
                FontFamily = "Seminaria",
                BorderWidth = 3,
                Background = gradientBrush,  // Устанавливаем цвет фона
                TextColor = Color.FromHex(AccentManager.MainTextAccent),       // Устанавливаем цвет текста
                CornerRadius = 20                                            // Устанавливаем радиус скругления углов
            };
            button1.Clicked += ToMain;

            var settingIco = new SvgCachedImage
            {
                Source = "AvraamProject/Resources/drawable/settings.svg",
                ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } },
            };

            settingIco.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new SettingsPage());
                })
            });

            var aboutIco = new SvgCachedImage
            {
                Source = "AvraamProject/Resources/drawable/info.svg",
                ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } },
            };

            aboutIco.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AboutPage());
                })
            });

            Label Welcome = new Label
            {
                Text = t.text("welcome", uiLang),
                FontFamily  = "Seminaria",
                FontSize = 50,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.FromHex(AccentManager.MainTextAccent)
            };

            AbsoluteLayout.SetLayoutBounds(Welcome, new Rectangle(0.5, 0.25, 350, 100));
            AbsoluteLayout.SetLayoutFlags(Welcome, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(settingIco, new Rectangle(0.97, 0.02, 40, 40));
            AbsoluteLayout.SetLayoutFlags(settingIco, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(aboutIco, new Rectangle(0.02, 0.02, 40, 40));
            AbsoluteLayout.SetLayoutFlags(aboutIco, AbsoluteLayoutFlags.PositionProportional);


            AbsoluteLayout.Children.Add(scrollView);
            AbsoluteLayout.Children.Add(button1);
            AbsoluteLayout.Children.Add(settingIco);
            AbsoluteLayout.Children.Add(aboutIco);
            AbsoluteLayout.Children.Add(Welcome);

            Content = AbsoluteLayout;
            //NavigationPage.SetHasNavigationBar(this, false);

            AbsoluteLayout.SetLayoutBounds(scrollView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(scrollView, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(button1, new Rectangle(0.5, 0.75, 0.65, 0.13));
            AbsoluteLayout.SetLayoutFlags(button1, AbsoluteLayoutFlags.All);
            if (!(Application.Current.Properties["Opt"].ToString() == "3")) ScrollToEndAsync();
        }


        private async void ScrollToEndAsync()
        {
            await Task.Delay(2000);
            double scrollStep = (scrollView.ContentSize.Width - scrollView.Width) / 100; // начальное значение шага

            while (true)
            {
                double currentPosition = scrollView.ScrollX;

                while (currentPosition < scrollView.ContentSize.Width - scrollView.Width)
                {
                    if ((currentPosition - scrollView.ScrollX) > 1 | (currentPosition - scrollView.ScrollX) < -1)
                    {
                        currentPosition = scrollView.ScrollX;
                        await Task.Delay(3000);
                        continue;
                    }
                    currentPosition = scrollView.ScrollX;
                    currentPosition += scrollStep;

                    if (currentPosition > scrollView.ContentSize.Width - scrollView.Width)
                    {
                        currentPosition = scrollView.ContentSize.Width - scrollView.Width;
                    }

                    await scrollView.ScrollToAsync(currentPosition, 0, true);
                    await Task.Delay(30);
                }

                while (currentPosition > 0)
                {
                    if ((currentPosition - scrollView.ScrollX) > 1 | (currentPosition - scrollView.ScrollX) < -1)
                    {
                        currentPosition = scrollView.ScrollX;
                        await Task.Delay(3000);
                        continue;
                    }
                    currentPosition = scrollView.ScrollX;
                    currentPosition -= scrollStep;

                    if (currentPosition < 0)
                    {
                        currentPosition = 0;
                    }

                    await scrollView.ScrollToAsync(currentPosition, 0, true);
                    await Task.Delay(30);
                }
            }
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Нажато!";
            button.BackgroundColor = Color.Red;

            // Анимация перемещения изображения влево
            currentX += panoramaImage.Width;
            if (currentX > panoramaImage.Width)
            {
                currentX = 0;
            }

            await scrollView.ScrollToAsync(currentX, 0, true);
        }

        private async void ToMain(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Main());
        }
        public static string SetBackground(string accent, string opt)
        {
            string optString = "";

            if (accent == "1") {
                optString = opt == "1" ? "pano1.jpg" : opt == "2" ? "lowpano1.jpg" : "";
            }

            if (accent == "2") {
                optString = opt == "1" ? "pano2.jpg" : opt == "2" ? "lowpano2.jpg" : "";
            }

            if (accent == "3") {
                optString = opt == "1" ? "pano3.jpg" : opt == "2" ? "lowpano3.jpg" : "";
            }
            Console.WriteLine(accent,opt,optString);
            return optString;
            
        }
    }
}
