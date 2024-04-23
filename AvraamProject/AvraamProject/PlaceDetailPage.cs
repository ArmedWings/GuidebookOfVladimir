using System;
using System.Collections.Generic;
using AvraamProject.Data;
using Xamarin.Forms;

namespace AvraamProject
{
    public class PlaceDetailPage : ContentPage
    {
        private CarouselView carouselView;
        private Label countLabel;
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
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(10, 5)
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
                Children = { countLabel, carouselView, nameLabel, descriptionLabel, ratingLabel, addressLabel, openInBrowserButton, viewOnMapButton },
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
    }
}