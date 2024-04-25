using System;
using System.Threading.Tasks;
using lang;
using Xamarin.Forms;

namespace AvraamProject
{
    public class SettingsPage : ContentPage
    {
        int languageIndex = 0;
        private Picker languagePicker;
        private Button firstButton;
        private Button secondButton;
        private Button thirdButton;
        private string uiLang = Application.Current.Properties["Language"].ToString();
        private int selectedButtonIndex = int.Parse(Application.Current.Properties["Accent"].ToString()); // Изначально выбрана кнопка в соответствии с сохраненным параметром
        public SettingsPage()
        {
            BackgroundColor = Color.FromHex(AccentManager.SideAppAccent);
            Title = t.text("Settings", uiLang);
            // Создаем основной StackLayout с отступом слева 20 пикселей

            var mainLayout = new StackLayout
            {
                Margin = new Thickness(10, 5, 10, 0)
            };
            var mainScrollView = new ScrollView
            { 
                Content = mainLayout 
            };
            // Лэйбл "Язык"
            var languageLabel = new Label
            {
                Text = t.text("language", uiLang),
                TextColor = Color.FromHex(AccentManager.MainTextAccent)
            };
            mainLayout.Children.Add(languageLabel);

            switch (uiLang as string)
            {
                case "ru":
                    languageIndex = 0;
                    break;
                case "en":
                    languageIndex = 1;
                    break;
                    // другие языки, если нужно
            }

            languagePicker = new Picker
            {
                Title = t.text("chooseLang", uiLang),
                Items = { "Русский", "English" },
                SelectedIndex = languageIndex,
                TitleColor = Color.Black,
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent), // Установка фона всплывающего окна
                TextColor = Color.FromHex(AccentManager.MainTextAccent) // Установка цвета текста выбранного элемента
            };

            // Frame для выбора языка
            var languageFrame = new Frame
            {
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                CornerRadius = 10, // Скругляем углы
                Padding = new Thickness(10),
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = t.text("language", uiLang),
                            TextColor = Color.FromHex(AccentManager.SideTextAccent)
                        },
                        languagePicker
                    }
                }
            };
            mainLayout.Children.Add(languageFrame);

            // Лэйбл "Предпочтения"
            var preferencesLabel = new Label
            {
                Text = t.text("preferences", uiLang),
                TextColor = Color.FromHex(AccentManager.MainTextAccent)
            };
            mainLayout.Children.Add(preferencesLabel);

            firstButton = new Button
            {
                WidthRequest = 70,
                HeightRequest = 70,
                BackgroundColor = Color.FromHex("#2E3034"),
                CornerRadius = 35
            };
            firstButton.Clicked += CircleButtonClicked;

            secondButton = new Button
            {
                WidthRequest = 70,
                HeightRequest = 70,
                BackgroundColor = Color.FromHex("#0F0F0F"),
                CornerRadius = 35
            };
            secondButton.Clicked += CircleButtonClicked;

            thirdButton = new Button
            {
                WidthRequest = 70,
                HeightRequest = 70,
                BackgroundColor = Color.FromHex("#D9D9D9"),
                CornerRadius = 35
            };
            thirdButton.Clicked += CircleButtonClicked;

            var alwaysRadio = new RadioButton { Content = t.text("always", uiLang), TextColor = Color.FromHex(AccentManager.MainTextAccent) };
            var neverRadio = new RadioButton { Content = t.text("never", uiLang), TextColor = Color.FromHex(AccentManager.MainTextAccent) };

            var preferencesFrame = new Frame
            {
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                CornerRadius = 10, // Скругляем углы
                Padding = new Thickness(10),
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = t.text("appTheme", uiLang),
                            TextColor = Color.FromHex(AccentManager.SideTextAccent)
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.Center,
                            Children =
                            {
                                // Первый StackLayout
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Vertical,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        firstButton,
                                        new BoxView { Color = Color.FromHex(AccentManager.MainTextAccent), WidthRequest = 70, HeightRequest = 5, CornerRadius = 2.5, IsVisible = selectedButtonIndex == 1 }
                                    },
                                    Margin = new Thickness(0, 0, Application.Current.MainPage.Width / 10, 0)
                                },
                                // Второй StackLayout
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Vertical,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        secondButton,
                                        new BoxView { Color = Color.FromHex(AccentManager.MainTextAccent), WidthRequest = 70, HeightRequest = 5, CornerRadius = 2.5, IsVisible = selectedButtonIndex == 2 }
                                    }
                                },
                                // Третий StackLayout
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Vertical,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        thirdButton,
                                        new BoxView { Color = Color.FromHex(AccentManager.MainTextAccent), WidthRequest = 70, HeightRequest = 5, CornerRadius = 2.5, IsVisible = selectedButtonIndex == 3 }
                                    },
                                    Margin = new Thickness(Application.Current.MainPage.Width / 10, 0, 0, 0)
                                },
                                
                            }
                        },
                        new Label
                        {
                            Text = t.text("fullScreen", uiLang),
                            TextColor = Color.FromHex(AccentManager.SideTextAccent),
                            Margin = new Thickness(0, 10, 0, 5)
                        },
                        alwaysRadio,
                        neverRadio
                    }
                }
            };
            mainLayout.Children.Add(preferencesFrame);


            switch (Application.Current.Properties["Screen"] as string)
            {
                case "1":
                    alwaysRadio.IsChecked = true;
                    break;
                case "2":
                    neverRadio.IsChecked = true;
                    break;
            }

            var FullRadio = new RadioButton { Content = t.text("highQBG", uiLang), TextColor = Color.FromHex(AccentManager.MainTextAccent) };
            var LowRadio = new RadioButton { Content = t.text("blurBG", uiLang), TextColor = Color.FromHex(AccentManager.MainTextAccent) };
            var SimpleRadio = new RadioButton { Content = t.text("simpleBG", uiLang), TextColor = Color.FromHex(AccentManager.MainTextAccent) };

            var optLabel = new Label
            {
                Text = t.text("optimization", uiLang),
                TextColor = Color.FromHex(AccentManager.MainTextAccent)
            };
            mainLayout.Children.Add(optLabel);

            var OptimizationFrame = new Frame
            {
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                CornerRadius = 10, // Скругляем углы
                Padding = new Thickness(10),
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = t.text("bg", uiLang),
                            TextColor = Color.FromHex(AccentManager.SideTextAccent)
                        },
                        FullRadio,
                        LowRadio,
                        SimpleRadio
                    }
                }
            };
            mainLayout.Children.Add(OptimizationFrame);

            switch (Application.Current.Properties["Opt"] as string)
            {
                case "1":
                    FullRadio.IsChecked = true;
                    break;
                case "2":
                    LowRadio.IsChecked = true;
                    break;
                case "3":
                    SimpleRadio.IsChecked = true;
                    break;
            }

            // Кнопка "Подтвердить"
            var confirmButton = new Button
            {
                Text = t.text("confirm", uiLang),
                TextColor = Color.FromHex(AccentManager.MainTextAccent),
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                CornerRadius = 10
            };

            confirmButton.Clicked += async (sender, args) =>
            {
                // Сохранение выбранного акцента в свойствах приложения
                Application.Current.Properties["Accent"] = selectedButtonIndex.ToString();

                switch (languagePicker.SelectedIndex)
                {
                    case 0:
                        if (uiLang == "en") await App.Current.MainPage.DisplayAlert("", t.text("To change the language, restart the applications", uiLang), "OK");
                        Application.Current.Properties["Language"] = "ru";
                        break;
                    case 1:
                        if (uiLang == "ru") await App.Current.MainPage.DisplayAlert("", t.text("To change the language, restart the applications", uiLang), "OK");
                        Application.Current.Properties["Language"] = "en";
                        break;
                }

                if (alwaysRadio.IsChecked)
                {
                    Application.Current.Properties["Screen"] = "1"; // "Всегда"
                }
                else
                {
                    Application.Current.Properties["Screen"] = "2"; // "Никогда"
                }

                if (FullRadio.IsChecked)
                {
                    Application.Current.Properties["Opt"] = "1"; // "Всегда"
                }
                else if (LowRadio.IsChecked)
                {
                    Application.Current.Properties["Opt"] = "2"; // "Никогда"
                }
                else
                {
                    Application.Current.Properties["Opt"] = "3"; // "Никогда"
                }

                await Application.Current.SavePropertiesAsync();
                AccentManager.ApplyAccentColors();
                // Задержка для завершения асинхронной операции сохранения свойств
                await Task.Delay(100);
                if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
                {
                    var myService = DependencyService.Get<IBar>();
                    myService.SetStatusBarColor(Color.FromHex(AccentManager.MainAppAccent));
                    myService.SetFullScreen();
                }

                Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new StartPage())
                {
                    BarBackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                    BarTextColor = Color.FromHex(AccentManager.MainTextAccent)
                };
            };
            mainLayout.Children.Add(confirmButton);

            

            Content = mainScrollView;
        }
        private async void CircleButtonClicked(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            var parentStack = (StackLayout)clickedButton.Parent;

            // Обновляем значение переменной в зависимости от нажатой кнопки
            if (clickedButton == firstButton)
            {
                selectedButtonIndex = 1;
            }
            else if (clickedButton == secondButton)
            {
                selectedButtonIndex = 2;
            }
            else if (clickedButton == thirdButton)
            {
                selectedButtonIndex = 3;
            }

            // Обновляем сохраненный параметр "Accent"

            // Скрываем полоски у всех стеков на этом уровне с анимацией
            var grandParentStack = (StackLayout)parentStack.Parent;
            foreach (var child in grandParentStack.Children)
            {
                if (child is StackLayout stack && stack != parentStack)
                {
                    foreach (var innerChild in stack.Children)
                    {
                        if (innerChild is BoxView bar && bar.HeightRequest == 5 && bar.IsVisible)
                        {
                            await bar.FadeTo(0, 250); // Исчезновение с анимацией
                            bar.IsVisible = false;
                        }
                    }
                }
            }

            // Показываем полоску для выбранного круга с анимацией
            var selectedBar = parentStack.Children[1] as BoxView;
            if (selectedBar != null)
            {
                if (!selectedBar.IsVisible)
                {
                    selectedBar.Opacity = 0; // Установка нулевой прозрачности перед анимацией
                    selectedBar.IsVisible = true;
                    await selectedBar.FadeTo(1, 250); // Появление с анимацией
                }
            }
        }
    }
}