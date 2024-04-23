﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using AvraamProject.Models;
using AvraamProject.Data;
using System.Linq;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Forms;
using System.Collections;
using Xamarin.Essentials;
using FFImageLoading;


namespace AvraamProject
{
    public partial class Main : ContentPage
    {
        private AbsoluteLayout absoluteLayout;
        private BoxView menuBoxView;
        private SvgCachedImage filterImage;
        private SvgCachedImage closeImage;
        private StackLayout menuStackLayout;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private bool isMenuOpen = false;
        private bool isCloseIconVisible = false;
        private double menuWidth;
        private double menuHeight;
        private StackLayout placesStackLayout;
        private double startX;
        private double endX;
        private Frame menuFrame;
        private BoxView swipeBox;
        //private AbsoluteLayout backgroundLayout;
        private bool isToggleMenuItemsVisibilityRunning = false;
        private bool IsSortInversed = false;
        private Picker sortPicker;
        private bool isFunctionRunning;
        private HashSet<string> selectedItems = new HashSet<string>
        {
            "Развлечения",
            "Гастрономия",
            "Отдых",
            "Магазины",
            "Больницы",
            "Образование"
        };
        private string[] labelTexts =
        {
            "Развлечения",
            "Гастрономия",
            "Отдых",
            "Магазины",
            "Больницы",
            "Образование"
        };
        string[] iconSources =
        {
            "AvraamProject/Resources/drawable/attraction.svg",
            "AvraamProject/Resources/drawable/restaurant.svg",
            "AvraamProject/Resources/drawable/hotel.svg",
            "AvraamProject/Resources/drawable/shop.svg",
            "AvraamProject/Resources/drawable/hospital.svg",
            "AvraamProject/Resources/drawable/school.svg"
        };

        public Main()
        {
            

            absoluteLayout = new AbsoluteLayout();

            Image image = new Image { Source = "pano.png", Aspect = Aspect.AspectFill,Opacity=1 };

            menuWidth = Application.Current.MainPage.Width * 0.55;
            menuHeight = Application.Current.MainPage.Height * menuWidth / Application.Current.MainPage.Width;


            filterImage = new SvgCachedImage
            {
                Source = "AvraamProject/Resources/drawable/filter.svg",
                WidthRequest = 40,
                HeightRequest = 40,
                Margin = new Thickness(0, 100, 0, 100),
                ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } }
            };

            closeImage = new SvgCachedImage
            {
                Source = "AvraamProject/Resources/drawable/krest.svg",
                WidthRequest = 50,
                HeightRequest = 50,
                Opacity = 0,
                Margin = new Thickness(0, 100, 0, 100)
            };

            menuStackLayout = new StackLayout
            {
                Spacing = 10,
                Children =
                {
                    new AbsoluteLayout
                    {
                        Children =
                        {
                            { filterImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional },
                            { closeImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional }
                        },
                        HeightRequest = 100,
                        HorizontalOptions = LayoutOptions.Center
                    }
                    // Добавьте другие элементы StackLayout здесь, если они есть
                }
            };

            ScrollView menuScrollView = new ScrollView
            {
                Content = menuStackLayout
            };

            menuFrame = new Frame
            {
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                WidthRequest = menuWidth,
                Content = menuScrollView
            };

            //AbsoluteLayout.SetLayoutBounds(menuFrame, new Rectangle(0, 0, menuWidth, Application.Current.MainPage.Height));

            for (int i = 0; i < 6; i++)
            {
                CheckBox checkbox = new CheckBox { WidthRequest = 25, HeightRequest = 25, Color = Color.FromHex(AccentManager.MainTextAccent), IsChecked = true };
                SvgCachedImage icon = new SvgCachedImage { Source = iconSources[i], WidthRequest = 35, HeightRequest = 35, ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } } };
                Label label = new Label { Text = labelTexts[i], VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex(AccentManager.MainTextAccent) };

                StackLayout stack = new StackLayout { Orientation = StackOrientation.Horizontal, Spacing = 10 };

                if (checkbox != null && icon != null && label != null)
                {
                    stack.Children.Add(checkbox);
                    stack.Children.Add(icon);
                    stack.Children.Add(label);

                    menuStackLayout.Children.Add(stack);

                    checkBoxes.Add(checkbox);

                    checkbox.CheckedChanged += (s, e) =>
                    {
                        var selectedCheckbox = s as CheckBox;
                        var correspondingLabel = (Label)((StackLayout)selectedCheckbox.Parent).Children[2];
                        if (selectedCheckbox.IsChecked)
                        {
                            selectedItems.Add(correspondingLabel.Text);
                        }
                        else
                        {
                            selectedItems.Remove(correspondingLabel.Text);
                        };
                    };
                }
            }

            sortPicker = new Picker
            {
                Title = "Выберите",
                Items = { "По популярности", "По рейтингу", "По алфавиту", "Случайно" },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(AccentManager.MainTextAccent),
            };

            sortPicker.SelectedIndexChanged += (sender, args) =>
            {
                var selectedItem = sortPicker.Items[sortPicker.SelectedIndex];
            };

            sortPicker.SelectedIndex = 0;

            // Label "Отсортировать:"
            var sortLabel = new Label
            {
                Text = "Отсортировать:",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(AccentManager.SideTextAccent)
            };

            // Стрелка для сортировки
            var arrowImage = new SvgCachedImage
            {
                Source = "arrow.svg",  // Укажите свой путь к изображению
                WidthRequest = 25,
                HeightRequest = 25,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } }
            };
            arrowImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    IsSortInversed = !IsSortInversed;

                    await arrowImage.RotateTo(IsSortInversed ? 180 : 0, 250, Easing.Linear);
                })
            });

            // Горизонтальный StackLayout для сортировки
            var sortStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { arrowImage, sortPicker }
            };

            var confirmButton = new Button
            {
                Text = "Подтвердить",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0),
                TextColor = Color.FromHex(AccentManager.MainTextAccent),
                BackgroundColor = Color.FromHex(AccentManager.SideAppAccent)
            };

            isFunctionRunning = false;

            confirmButton.Clicked += async (sender, e) =>
            {
                if (!isFunctionRunning)  // Проверка, не запущена ли функция
                {
                    
                    isFunctionRunning = true;  // Установка флага в true перед запуском функции
                    CreatePlaceBlocks();
                    await Task.Delay(2000);
                    isFunctionRunning = false;  // Сброс флага после завершения функции
                }
                else
                {
                    await DisplayAlert("Пожалуйста, подождите", "Поиск уже производится", "OK");
                }
            };

            menuStackLayout.Children.Add(sortLabel);
            menuStackLayout.Children.Add(sortStackLayout);  // Добавляем горизонтальный StackLayout в меню
            menuStackLayout.Children.Add(confirmButton);

            placesStackLayout = new StackLayout();

            var searchBlock = new Frame
            {
                HeightRequest = Application.Current.MainPage.Height * 0.05,
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                Margin = new Thickness(0, 0, 0, 10), // Отступ снизу для разделения с контентом
                Padding = new Thickness(10),
                HasShadow = true
            };

            // Элемент ввода текста для поиска
            var searchEntry = new Entry
            {
                Placeholder = "Поиск",
                TextColor = Color.FromHex(AccentManager.MainTextAccent),
                PlaceholderColor = Color.FromHex(AccentManager.SideTextAccent),
                WidthRequest = Application.Current.MainPage.Width * 0.7 // Ширина в 70% от ширины экрана
            };

            // Кнопка фильтра с SVG изображением
            var filterButton = new SvgCachedImage
            {
                Source = "AvraamProject/Resources/drawable/filter.svg",
                WidthRequest = 35,
                HeightRequest = 35,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } }
            };

            // Добавляем TapGestureRecognizer
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += async (s, e) => await OpenMenu();
            
            filterButton.GestureRecognizers.Add(tapGesture);

            var searchImage = new SvgCachedImage
            {
                Source = "AvraamProject/Resources/drawable/search.svg",
                WidthRequest = 35,
                HeightRequest = 35,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } }
            };

            var SearchtapGesture = new TapGestureRecognizer();
            SearchtapGesture.Tapped += async (s, e) => {
                if (!isFunctionRunning)  // Проверка, не запущена ли функция
                {

                    isFunctionRunning = true;  // Установка флага в true перед запуском функции
                    CreatePlaceBlocks(searchEntry.Text);
                    await Task.Delay(2000);
                    isFunctionRunning = false;  // Сброс флага после завершения функции
                }
                else
                {
                    await DisplayAlert("Пожалуйста, подождите", "Поиск уже производится", "OK");
                }
            };
            searchImage.GestureRecognizers.Add(SearchtapGesture);

            // Добавляем элементы в блок поиска
            searchBlock.Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { filterButton, searchImage, searchEntry }
            };

            // Добавляем блок поиска в верхнюю часть экрана
            placesStackLayout.Children.Insert(0, searchBlock);

            CreatePlaceBlocks();

            var scrollView = new ScrollView
            {
                Content = placesStackLayout,
                Padding = new Thickness(0, 0, 0, 20)
            };

            swipeBox = new BoxView
            {
                Color = Color.FromHex(AccentManager.SideAppAccent),
                WidthRequest = Application.Current.MainPage.Width * 0.1,
                HeightRequest = Application.Current.MainPage.Height,
                Opacity = 0
            };

            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(scrollView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(scrollView, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(menuFrame, new Rectangle(Application.Current.MainPage.Width, 0, menuWidth, Application.Current.MainPage.Height));
            AbsoluteLayout.SetLayoutFlags(menuFrame, AbsoluteLayoutFlags.HeightProportional);

            AbsoluteLayout.SetLayoutBounds(swipeBox, new Rectangle(1, 0, 0.2, 1));
            AbsoluteLayout.SetLayoutFlags(swipeBox, AbsoluteLayoutFlags.All);

            absoluteLayout.Children.Add(image);
            absoluteLayout.Children.Add(scrollView);
            absoluteLayout.Children.Add(swipeBox);
            absoluteLayout.Children.Add(menuFrame);

            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;

            closeImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    if (!isToggleMenuItemsVisibilityRunning) 
                    {
                        selectedItems = new HashSet<string>
                        {
                            "Развлечения",
                            "Гастрономия",
                            "Отдых",
                            "Магазины",
                            "Больницы",
                            "Образование"
                        };
                        await ToggleCloseImageVisibility();
                        await ToggleMenuItemsVisibility();
                    }
                })
            });

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            swipeBox.GestureRecognizers.Add(panGesture);
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                if (isMenuOpen)
                {
                    await CloseMenu();
                }
            };
            swipeBox.GestureRecognizers.Add(tapGestureRecognizer);

            this.Content = absoluteLayout;
        }

        private async void CreatePlaceBlocks(string searchText = null)
        {
            // Очищаем все дочерние элементы scrollView
            for (int i = placesStackLayout.Children.Count - 1; i > 0; i--)
            {
                placesStackLayout.Children.RemoveAt(i);
            }

            var tempPlaces = PlaceData.GetPlaces().Where(p => selectedItems.Contains(p.Type)).ToList();

            if (sortPicker.SelectedIndex == 0) tempPlaces = tempPlaces.OrderByDescending(p => p.Popularity).ToList();
            else if (sortPicker.SelectedIndex == 1) tempPlaces = tempPlaces.OrderByDescending(p => p.Rating).ToList();
            else if (sortPicker.SelectedIndex == 2) tempPlaces = tempPlaces.OrderBy(p => p.Name).ToList();
            else if (sortPicker.SelectedIndex == 3) tempPlaces = tempPlaces.OrderBy(p => Guid.NewGuid()).ToList();

            if (IsSortInversed) tempPlaces.Reverse();

            if (!string.IsNullOrEmpty(searchText))
            {
                tempPlaces = tempPlaces.Where(p => p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                                 || p.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                                 || p.Type.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                                 || p.Category.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                                 || p.Address.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (tempPlaces.Count == 0)
            {
                await DisplayAlert("Не найдено ни одного места", "Попробуйте изменить параметры поиска", "Ок");
            }
            else
            {
                foreach (var place in tempPlaces)
                {
                    var image = new Image
                    {
                        Source = $"lowplace{place.Id}_1",
                        Aspect = Aspect.AspectFill,
                        HeightRequest = 200,
                        WidthRequest = Application.Current.MainPage.Width * 0.9  // 90% ширины экрана
                    };

                    var nameLabel = new Label
                    {
                        Text = place.Name,
                        FontSize = 18,
                        FontAttributes = FontAttributes.Bold,
                        Margin = new Thickness(5, 5, 5, 0),
                        TextColor = Color.FromHex(AccentManager.MainTextAccent)
                    };

                    var descriptionLabel = new Label
                    {
                        Text = place.Description,
                        FontSize = 16,
                        Margin = new Thickness(5, 0, 5, 0),  // Убрал отступ снизу
                        TextColor = Color.FromHex(AccentManager.SideTextAccent)
                    };

                    var ratingLabel = new Label
                    {
                        Text = $"{place.Rating} ({place.Popularity})",
                        FontSize = 14,
                        Margin = new Thickness(5, 0, 5, 0),  // Убрал отступ снизу
                        TextColor = Color.FromHex(AccentManager.SideTextAccent)
                    };

                    var addressLabel = new Label
                    {
                        Text = place.Address,
                        FontSize = 14,
                        Margin = new Thickness(5, 0, 5, 3),
                        TextColor = Color.FromHex(AccentManager.SideTextAccent)
                    };

                    var textStack = new StackLayout
                    {
                        Children = { nameLabel, descriptionLabel, ratingLabel, addressLabel },
                        Padding = new Thickness(0)  // Убираем отступы внутри текстового блока
                    };

                    var frame = new Frame
                    {
                        Content = new StackLayout
                        {
                            Children = { image, textStack },
                            Padding = new Thickness(0)  // Убираем отступы внутри основного блока
                        },
                        CornerRadius = 10,
                        BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                        HasShadow = true,  // Добавим тень для отделения блоков
                        Margin = new Thickness(20, 10, 20, 0)  // Отступы от краев экрана
                    };

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        await Navigation.PushAsync(new PlaceDetailPage(place.Id));  // Переход на новую страницу с Id места
                    };

                    frame.GestureRecognizers.Add(tapGestureRecognizer);

                    placesStackLayout.Children.Add(frame);

                    await Task.Delay(100);
                }
            }

            // Блок с текстом "На этом всё!"
            var endLabelFrame = new Frame
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(0, 20, 0, 20),  // Увеличенные отступы сверху и снизу
                    Children =
                    {
                        new Label
                        {
                            Text = "На этом всё!",
                            FontSize = 20,
                            TextColor = Color.FromHex(AccentManager.MainTextAccent),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center
                        },
                        new Label
                        {
                            Text = "Не нашли, что искали? Попробуйте изменить параметры поиска",
                            FontSize = 18,
                            TextColor = Color.FromHex(AccentManager.SideTextAccent),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center
                        }
                    }
                },
                CornerRadius = 10,
                BackgroundColor = Color.FromHex(AccentManager.MainAppAccent),
                HasShadow = true,  // Добавим тень для отделения блоков
                Margin = new Thickness(20, 10, 20, 0)  // Отступы от краев экрана
            };

            placesStackLayout.Children.Add(endLabelFrame);
        }

        private async Task ToggleCloseImageVisibility()
        {
            isToggleMenuItemsVisibilityRunning = true;
            if (closeImage.Opacity == 1)
            {
                await closeImage.FadeTo(0, 250);  // За 250 миллисекунд установить Opacity в 0
            }
            else
            {
                await closeImage.FadeTo(1, 250);  // За 250 миллисекунд установить Opacity в 1
            }
        }

        private async Task RotateIcon(Image icon, bool isReversed)
        {
            if (isReversed)
            {
                await icon.RotateTo(180, 250, Easing.Linear);
            }
            else
            {
                await icon.RotateTo(0, 250, Easing.Linear);
            }
        }

        private async Task ToggleMenuItemsVisibility()
        {
            if (closeImage.Opacity == 1)
            {
                List<StackLayout> stacksToRemove = new List<StackLayout>();

                foreach (var child in menuStackLayout.Children)
                {
                    if (child is StackLayout stack && stack.Children.Count > 2)
                    {
                        await stack.FadeTo(0, 200, Easing.Linear);  // Анимация исчезновения
                        stacksToRemove.Add(stack);
                    }
                }

                await Task.Delay(200);  // Даем время для завершения анимации

                foreach (var stack in stacksToRemove)
                {
                    menuStackLayout.Children.Remove(stack);
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    CheckBox checkbox = new CheckBox { WidthRequest = 25, HeightRequest = 25, Color = Color.FromHex(AccentManager.MainTextAccent), IsChecked = true };
                    SvgCachedImage icon = new SvgCachedImage { Source = iconSources[i], WidthRequest = 35, HeightRequest = 35, ReplaceStringMap = new System.Collections.Generic.Dictionary<string, string> { { "fill=\"#000000\"", $"fill=\"{AccentManager.MainTextAccent}\"" } } };
                    Label label = new Label { Text = labelTexts[i], VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex(AccentManager.MainTextAccent) };

                    StackLayout stack = new StackLayout { Orientation = StackOrientation.Horizontal, Spacing = 10, Opacity = 0 };

                    if (checkbox != null && icon != null && label != null)
                    {
                        stack.Children.Add(checkbox);
                        stack.Children.Add(icon);
                        stack.Children.Add(label);

                        menuStackLayout.Children.Insert(1 + i, stack);  // Вставляем после первого элемента

                        checkBoxes.Add(checkbox);

                        checkbox.CheckedChanged += (s, e) =>
                        {
                            var selectedCheckbox = s as CheckBox;
                            var correspondingLabel = (Label)((StackLayout)selectedCheckbox.Parent).Children[2];
                            if (selectedCheckbox.IsChecked)
                            {
                                selectedItems.Add(correspondingLabel.Text);
                            }
                            else
                            {
                                selectedItems.Remove(correspondingLabel.Text);
                            };
                        };

                        await stack.FadeTo(1, 200, Easing.Linear);  // Анимация появления
                        
                    }
                }
            }
            isToggleMenuItemsVisibilityRunning = false;
        }

        private async void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    startX = e.TotalX;
                    break;
                case GestureStatus.Running:
                    endX = e.TotalX;
                    break;
                case GestureStatus.Completed:
                    if (startX - endX > 50 && !isMenuOpen) // свайп влево и меню не открыто
                    {
                        await OpenMenu();
                    }
                    else if (endX - startX > 50 && isMenuOpen) // свайп вправо и меню открыто
                    {
                        await CloseMenu();
                    }
                    break;
            }
        }

        private async Task OpenMenu()
        {
            var menuAnimation = menuFrame.LayoutTo(new Rectangle(Application.Current.MainPage.Width - menuWidth, 0, menuWidth, Application.Current.MainPage.Height), 250, Easing.SinIn);
            var swipeBoxAnimation = swipeBox.LayoutTo(new Rectangle(0, 0, menuFrame.Bounds.Left, swipeBox.Height), 70, Easing.SinIn);
            var opacityAnimation = swipeBox.FadeTo(0.5, 250, Easing.SinIn);

            await Task.WhenAll(menuAnimation, swipeBoxAnimation, opacityAnimation);

            isMenuOpen = true;
        }

        private async Task CloseMenu()
        {
            var menuAnimation = menuFrame.LayoutTo(new Rectangle(Application.Current.MainPage.Width, 0, menuWidth, Application.Current.MainPage.Height), 250, Easing.SinOut);
            var swipeBoxAnimation = swipeBox.LayoutTo(new Rectangle(Application.Current.MainPage.Width - (int)(Application.Current.MainPage.Width * 0.1), 0, (int)(Application.Current.MainPage.Width * 0.2), swipeBox.Height), 350, Easing.SinOut);
            var opacityAnimation = swipeBox.FadeTo(0, 150, Easing.SinOut);

            await Task.WhenAll(menuAnimation, swipeBoxAnimation, opacityAnimation);

            isMenuOpen = false;
        }
        private void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            UpdateMenuFrameLayout();
        }
        private async void UpdateMenuFrameLayout()
        {
            await Task.Delay(250);
            menuWidth = Application.Current.MainPage.Width * 0.55;
            if (Application.Current.MainPage.Width > Application.Current.MainPage.Height) // Горизонтальная ориентация
            {
                if (isMenuOpen)
                {
                    await menuFrame.LayoutTo(new Rectangle(Application.Current.MainPage.Width - menuWidth, 0, menuWidth, Application.Current.MainPage.Height), 1, Easing.SinIn);
                    await swipeBox.LayoutTo(new Rectangle(0, 0, menuFrame.Bounds.Left, swipeBox.Height), 1, Easing.SinIn);
                }
                else
                {
                    await menuFrame.LayoutTo(new Rectangle(Application.Current.MainPage.Width, 0, menuWidth, Application.Current.MainPage.Height), 1, Easing.SinOut);
                    await swipeBox.LayoutTo(new Rectangle(Application.Current.MainPage.Width - (int)(Application.Current.MainPage.Width * 0.1), 1, (int)(Application.Current.MainPage.Width * 0.2), swipeBox.Height), 350, Easing.SinOut);
                }
            }
            else // Вертикальная ориентация
            {
                if (isMenuOpen)
                {
                    await menuFrame.LayoutTo(new Rectangle(Application.Current.MainPage.Width - menuWidth, 0, menuWidth, Application.Current.MainPage.Height), 250, Easing.SinIn);
                    await swipeBox.LayoutTo(new Rectangle(0, 0, menuFrame.Bounds.Left, swipeBox.Height), 70, Easing.SinIn);
                }
                else
                {
                    await menuFrame.LayoutTo(new Rectangle(Application.Current.MainPage.Width, 0, menuWidth, Application.Current.MainPage.Height), 250, Easing.SinOut);
                    await swipeBox.LayoutTo(new Rectangle(Application.Current.MainPage.Width - (int)(Application.Current.MainPage.Width * 0.1), 0, (int)(Application.Current.MainPage.Width * 0.2), swipeBox.Height), 350, Easing.SinOut);
                }
            }
        }
    }
}