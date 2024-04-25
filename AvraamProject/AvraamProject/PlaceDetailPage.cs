using System;
using System.Collections.Generic;
using System.Linq;
using AvraamProject.Data;
using AvraamProject.Models;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace AvraamProject
{
    public class PlaceDetailPage : ContentPage
    {
        private CarouselView carouselView;
        private Label countLabel;
        private SvgCachedImage favoriteIco;
        private List<int> favoritePlacesIds = new List<int>();
        private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
            var images = carouselView.ItemsSource as List<string>;
            if (images != null)
            {
                countLabel.Text = $"{carouselView.Position + 1}/{images.Count}";
            }
        }
        public PlaceDetailPage(int placeId)
        {
            var place = PlaceData.GetPlaceById(placeId);  // Получение информации о месте по Id

            Title = place.Name;  // Название страницы

            BackgroundColor = Color.FromHex(AccentManager.SideAppAccent);  // Установка фона страницы

            favoriteIco = new SvgCachedImage
            {
                Source = "AvraamProject/Resources/drawable/star.svg",
                ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } },
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 50,
                HeightRequest = 50,
                Margin = new Thickness(15)
            };

            favoriteIco.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnFavoriteIconTapped(place.Id))
            });

            if (Application.Current.Properties.ContainsKey("favoritePlacesIds"))
            {
                string idsString = Application.Current.Properties["favoritePlacesIds"] as string;
                favoritePlacesIds = idsString.Split(',').Select(id => int.TryParse(id, out int parsedId) ? parsedId : 0).Where(id => id != 0).ToList();
            }
            if (favoritePlacesIds.Contains(placeId))
            {
                favoriteIco.Source = "AvraamProject/Resources/drawable/starfull.svg"; // Изменяем иконку на пустую звезду
            }
            else
            {
                favoriteIco.Source = "AvraamProject/Resources/drawable/star.svg"; // Изменяем иконку на заполненную звезду
            }


            var images = new List<string>
            {
                $"lowplace{place.Id}_1",
                $"lowplace{place.Id}_2",
                $"lowplace{place.Id}_3"
            };

            carouselView = new CarouselView
            {
                HeightRequest = 300,
                ItemsSource = images,
                ItemTemplate = new DataTemplate(() =>
                {
                    var image = new Image
                    {
                        Aspect = Aspect.AspectFit,
                        HeightRequest = 300,
                        WidthRequest = Application.Current.MainPage.Width
                    };
                    image.SetBinding(Image.SourceProperty, ".");
                    return image;
                })
            };

            

            countLabel = new Label
            {
                Text = $"{carouselView.Position + 1}/{images.Count}",
                TextColor = Color.FromHex(AccentManager.MainTextAccent),
                FontSize = 14,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(0, 5)
            };

            carouselView.PositionChanged += OnCarouselPositionChanged;

            var nameLabel = new Label
            {
                Text = place.Name,
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(10),
                TextColor = Color.FromHex(AccentManager.MainTextAccent)
            };

            var descriptionLabel = new Label
            {
                Text = place.Description,
                FontSize = 18,
                Margin = new Thickness(10),
                TextColor = Color.FromHex(AccentManager.SideTextAccent)
            };

            var ratingLabel = new Label
            {
                Text = $"{place.Rating} ({place.Popularity})",
                FontSize = 16,
                Margin = new Thickness(10),
                TextColor = Color.FromHex(AccentManager.SideTextAccent)
            };

            var addressLabel = new Label
            {
                Text = place.Address,
                FontSize = 16,
                Margin = new Thickness(10),
                TextColor = Color.FromHex(AccentManager.SideTextAccent)
            };

            var openInBrowserButton = new Button
            {
                Text = "Открыть в интернете",
                BackgroundColor = Color.FromHex(AccentManager.SideAppAccent),
                TextColor = Color.FromHex(AccentManager.MainTextAccent),
                Margin = new Thickness(15),
                BorderWidth = 3, // Ширина обводки
                BorderColor = Color.FromHex(AccentManager.SideAppAccent), // Цвет обводки
                CornerRadius = 15 // Радиус закругления углов
            };

            openInBrowserButton.Clicked += (sender, e) =>
            {
                Device.OpenUri(new Uri(place.Site));
            };

            var viewOnMapButton = new Button
            {
                Text = "Посмотреть на карте",
                BackgroundColor = Color.FromHex(AccentManager.SideAppAccent),
                TextColor = Color.FromHex(AccentManager.MainTextAccent),
                Margin = new Thickness(15),
                BorderWidth = 3, // Ширина обводки
                BorderColor = Color.FromHex(AccentManager.SideAppAccent), // Цвет обводки
                CornerRadius = 15 // Радиус закругления углов
            };

            viewOnMapButton.Clicked += (sender, e) =>
            {
                var webView = new WebView
                {
                    Source = new UrlWebViewSource { Url = place.Url },
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                var webViewPage = new ContentPage
                {
                    Content = webView,
                    Title = "Карта"
                };

                Navigation.PushAsync(webViewPage);
            };

            var contentStack = new StackLayout
            {
                Children = { countLabel, carouselView, nameLabel, descriptionLabel, ratingLabel, addressLabel, favoriteIco, openInBrowserButton, viewOnMapButton },
                Padding = new Thickness(0)
            };

            var frame = new Frame
            {
                Content = contentStack,
                CornerRadius = 10,
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),  // Установка фона
                HasShadow = true,
                Margin = new Thickness(20, 20, 20, 20)
            };

            Content = new ScrollView  // Добавляем ScrollView для прокрутки содержимого
            {
                Content = frame,
                Padding = new Thickness(0, 0, 0, 20)
            };
        }
        private async void OnFavoriteIconTapped(int placeId)
        {
            // Проверяем, содержится ли placeId в списке избранных мест
            if (Application.Current.Properties.ContainsKey("favoritePlacesIds"))
            {
                string idsString = Application.Current.Properties["favoritePlacesIds"] as string;
                favoritePlacesIds = idsString.Split(',').Select(id => int.TryParse(id, out int parsedId) ? parsedId : 0).Where(id => id != 0).ToList();
            }

            // Проверяем, содержится ли placeId в списке избранных мест
            if (favoritePlacesIds.Contains(placeId))
            {
                favoritePlacesIds.Remove(placeId);
                // Удалите placeId из списка избранных
                favoriteIco.Source = "AvraamProject/Resources/drawable/star.svg"; // Изменяем иконку на пустую звезду
            }
            else
            {
                favoritePlacesIds.Add(placeId);
                // Добавьте placeId в список избранных
                favoriteIco.Source = "AvraamProject/Resources/drawable/starfull.svg"; // Изменяем иконку на заполненную звезду
            }

            // Сохраняем список в свойствах приложения
            Application.Current.Properties["favoritePlacesIds"] = string.Join(",", favoritePlacesIds);
            await Application.Current.SavePropertiesAsync();

            // Обновляем иконку
        }
    }
}