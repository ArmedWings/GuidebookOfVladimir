using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using System;
using lang;

namespace AvraamProject
{
    public class AboutPage : ContentPage
    {
        private string uiLang = Application.Current.Properties["Language"].ToString();
        public AboutPage()
        {
            BackgroundColor = Color.FromHex(AccentManager.SideAppAccent);
            Title = t.text("About", uiLang);

            var mainLayout = new StackLayout
            {
                Padding = new Thickness(20),
                Children =
                {
                    new ScrollView
                    {
                        Content = new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    Text = t.text("The purpose of the application", uiLang),
                                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                    TextColor = Color.FromHex(AccentManager.MainTextAccent)
                                },
                                new Label
                                {
                                    Text = t.text("Purpose of...", uiLang),
                                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                                    TextColor = Color.FromHex(AccentManager.SideTextAccent)
                                }
                            }
                        }
                    },
                    new SvgCachedImage
                    {
                        Source = "AvraamProject/Resources/drawable/github.svg",
                        ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string>
                        {
                            { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" }
                        },
                        HeightRequest = 50,
                        WidthRequest = 50,
                        HorizontalOptions = LayoutOptions.Center,
                        GestureRecognizers =
                        {
                            new TapGestureRecognizer
                            {
                                Command = new Command(() => Device.OpenUri(new Uri("https://github.com/ArmedWings/GuidebookOfVladimir")))
                            }
                        },
                        Margin = new Thickness(0, 100, 0, 0)
                    },
                    new Label
                    {
                        Text = "v1.3.0",
                        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                        TextColor = Color.FromHex(AccentManager.SideTextAccent),
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 0, 0, 50)
                    }
                }
            };

            Content = mainLayout;
        }
    }
}