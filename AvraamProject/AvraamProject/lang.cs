using System;
using System.Collections.Generic;

namespace lang
{
    class t
    {
        public static string text(string key, string language)
        {

            Dictionary<string, Dictionary<string, string>> tran = new Dictionary<string, Dictionary<string, string>>()
            {
                { "welcome", new Dictionary<string, string>()
                    {
                        { "ru", "Путеводитель по\nВладимиру" },
                        { "en", "Guidebook of\nVladimir" },
                    }
                },
                { "start", new Dictionary<string, string>()
                    {
                        { "ru", "Начать" },
                        { "en", "Start" },
                    }
                },
                { "language", new Dictionary<string, string>()
                    {
                        { "ru", "Язык" },
                        { "en", "Language" },
                    }
                },
                { "chooseLang", new Dictionary<string, string>()
                    {
                        { "ru", "Выберите язык" },
                        { "en", "Choose language" },
                    }
                },
                { "always", new Dictionary<string, string>()
                    {
                        { "ru", "Всегда" },
                        { "en", "Always" },
                    }
                },
                { "never", new Dictionary<string, string>()
                    {
                        { "ru", "Никогда" },
                        { "en", "Never" },
                    }
                },
                { "preferences", new Dictionary<string, string>()
                    {
                        { "ru", "Предпочтения" },
                        { "en", "Preferences" },
                    }
                },
                { "appTheme", new Dictionary<string, string>()
                    {
                        { "ru", "Тема приложения" },
                        { "en", "Application theme" },
                    }
                },
                { "fullScreen", new Dictionary<string, string>()
                    {
                        { "ru", "Полный экран" },
                        { "en", "Full screen" },
                    }
                },
                { "highQBG", new Dictionary<string, string>()
                    {
                        { "ru", "Высокое качество фона" },
                        { "en", "High quality background" },
                    }
                },
                { "blurBG", new Dictionary<string, string>()
                    {
                        { "ru", "Размытый фон" },
                        { "en", "Blur background" },
                    }
                },
                { "simpleBG", new Dictionary<string, string>()
                    {
                        { "ru", "Монотонный фон" },
                        { "en", "Simple background" },
                    }
                },
                { "optimization", new Dictionary<string, string>()
                    {
                        { "ru", "Оптимизация" },
                        { "en", "Optimization" },
                    }
                },
                { "bg", new Dictionary<string, string>()
                    {
                        { "ru", "Задний фон" },
                        { "en", "Background" },
                    }
                },
                { "confirm", new Dictionary<string, string>()
                    {
                        { "ru", "Подтвердить" },
                        { "en", "Confirm" },
                    }
                },
                //
                { "entertainment", new Dictionary<string, string>()
                    {
                        { "ru", "Развлечения" },
                        { "en", "Entertainment" },
                    }
                },
                { "gastronomy", new Dictionary<string, string>()
                    {
                        { "ru", "Гастрономия" },
                        { "en", "Gastronomy" },
                    }
                },
                { "rest", new Dictionary<string, string>()
                    {
                        { "ru", "Отдых" },
                        { "en", "Rest" },
                    }
                },
                { "stores", new Dictionary<string, string>()
                    {
                        { "ru", "Магазины" },
                        { "en", "Stores" },
                    }
                },
                { "medicine", new Dictionary<string, string>()
                    {
                        { "ru", "Медицина" },
                        { "en", "Medicine" },
                    }
                },
                { "education", new Dictionary<string, string>()
                    {
                        { "ru", "Образование" },
                        { "en", "Education" },
                    }
                },
                { "favorite", new Dictionary<string, string>()
                    {
                        { "ru", "Избранное" },
                        { "en", "Favorite" },
                    }
                },
                { "choose", new Dictionary<string, string>()
                    {
                        { "ru", "Выберите" },
                        { "en", "Choose" },
                    }
                },
                { "By popularity", new Dictionary<string, string>()
                    {
                        { "ru", "По популярности" },
                        { "en", "By popularity" },
                    }
                },
                { "By rating", new Dictionary<string, string>()
                    {
                        { "ru", "По рейтингу" },
                        { "en", "By rating" },
                    }
                },
                { "By alphabet", new Dictionary<string, string>()
                    {
                        { "ru", "По алфавиту" },
                        { "en", "By alphabet" },
                    }
                },
                { "Random", new Dictionary<string, string>()
                    {
                        { "ru", "Случайно" },
                        { "en", "Random" },
                    }
                },
                { "sort", new Dictionary<string, string>()
                    {
                        { "ru", "Отсортировать" },
                        { "en", "Sort" },
                    }
                },
                { "search", new Dictionary<string, string>()
                    {
                        { "ru", "Поиск" },
                        { "en", "Search" },
                    }
                },
                { "Please, wait", new Dictionary<string, string>()
                    {
                        { "ru", "Пожалуйста, подождите" },
                        { "en", "Please, wait" },
                    }
                },
                { "Search is already beingh", new Dictionary<string, string>()
                    {
                        { "ru", "Поиск уже производится" },
                        { "en", "Search is already being" },
                    }
                },
                { "Not a single place was found", new Dictionary<string, string>()
                    {
                        { "ru", "Не найдено ни одного места" },
                        { "en", "Not a single place was found" },
                    }
                },
                { "Try changing the search parameters", new Dictionary<string, string>()
                    {
                        { "ru", "Попробуйте изменить настройки поиска" },
                        { "en", "Try changing the search parameters" },
                    }
                },
                { "That's it!", new Dictionary<string, string>()
                    {
                        { "ru", "На этом всё!" },
                        { "en", "That's it!" },
                    }
                },
                { "Didn't find what you were looking for? Try changing the search parameters", new Dictionary<string, string>()
                    {
                        { "ru", "Не нашли, что искали? Попробуйте изменить параметры поиска" },
                        { "en", "Didn't find what you were looking for? Try changing the search parameters" },
                    }
                },
                { "Open in browser", new Dictionary<string, string>()
                    {
                        { "ru", "Открыть в браузере" },
                        { "en", "Open in browser" },
                    }
                },
                { "View on map", new Dictionary<string, string>()
                    {
                        { "ru", "Открыть на карте" },
                        { "en", "View on map" },
                    }
                },
                { "Settings", new Dictionary<string, string>()
                    {
                        { "ru", "Настройки" },
                        { "en", "Settings" },
                    }
                },
                { "Map", new Dictionary<string, string>()
                    {
                        { "ru", "Карта" },
                        { "en", "Map" },
                    }
                },
                //
                { "Золотые ворота", new Dictionary<string, string>()
                    {
                        { "ru", "Золотые ворота" },
                        { "en", "Golden Gates" },
                    }
                },
                { "Владимиро-Суздальский музей-заповедник", new Dictionary<string, string>()
                    {
                        { "ru", "Владимиро-Суздальский музей-заповедник" },
                        { "en", "Vladimir-Suzdal Museum-Reserve" },
                    }
                },
                { "Отель Заря Владимир", new Dictionary<string, string>()
                    {
                        { "ru", "Отель Заря Владимир" },
                        { "en", "Zarya Hotel Vladimir" },
                    }
                },
                { "Панорама", new Dictionary<string, string>()
                    {
                        { "ru", "Панорама" },
                        { "en", "Panorama" },
                    }
                },
                { "Клиника \"Твой Доктор\"", new Dictionary<string, string>()
                    {
                        { "ru", "Клиника \"Твой Доктор\"" },
                        { "en", "Clinic \"Your Doctor \"" },
                    }
                },
                { "Памятник князю Владимиру и святителю Федору", new Dictionary<string, string>()
                    {
                        { "ru", "Памятник князю Владимиру и святителю Федору" },
                        { "en", "Monument to Prince Vladimir and Saint Theodore" },
                    }
                },
                { "Патриарший сад", new Dictionary<string, string>()
                    {
                        { "ru", "Патриарший сад" },
                        { "en", "Patriarch's Garden" },
                    }
                },
                { "Торговый комплекс Мегаторг", new Dictionary<string, string>()
                    {
                        { "ru", "Торговый комплекс Мегаторг" },
                        { "en", "Megatorg Shopping Complex" },
                    }
                },
                { "Колесо Обозрения \"Небо33\"", new Dictionary<string, string>()
                    {
                        { "ru", "Колесо Обозрения \"Небо33\"" },
                        { "en", "Observation Wheel \"Sky33\"" },
                    }
                },
                { "Владимирский государственный университет", new Dictionary<string, string>()
                    {
                        { "ru", "Владимирский государственный университет" },
                        { "en", "Vladimir State University" },
                    }
                },
                { "Медицинский центр Палитра", new Dictionary<string, string>()
                    {
                        { "ru", "Медицинский центр Палитра" },
                        { "en", "Palette Medical Center" },
                    }
                },
                { "Музей культурного наследия", new Dictionary<string, string>()
                    {
                        { "ru", "Музей культурного наследия" },
                        { "en", "Museum of Cultural Heritage" },
                    }
                },
                { "Музей-заповедник", new Dictionary<string, string>()
                    {
                        { "ru", "Музей-заповедник" },
                        { "en", "Museum-Reserve" },
                    }
                },
                { "Отель", new Dictionary<string, string>()
                    {
                        { "ru", "Отель" },
                        { "en", "Hotel" },
                    }
                },
                { "Ресторан", new Dictionary<string, string>()
                    {
                        { "ru", "Ресторан" },
                        { "en", "Restaurant" },
                    }
                },
                { "Медицинский центр", new Dictionary<string, string>()
                    {
                        { "ru", "Медицинский центр" },
                        { "en", "Medical Center" },
                    }
                },
                { "Исторический памятник", new Dictionary<string, string>()
                    {
                        { "ru", "Исторический памятник" },
                        { "en", "Historical Monument" },
                    }
                },
                { "Детский клуб", new Dictionary<string, string>()
                    {
                        { "ru", "Детский клуб" },
                        { "en", "Children's Club" },
                    }
                },
                { "Торговый центр", new Dictionary<string, string>()
                    {
                        { "ru", "Торговый центр" },
                        { "en", "Shopping Center" },
                    }
                },
                { "Филер и Шалопай", new Dictionary<string, string>()
                    {
                        { "ru", "Филер и Шалопай" },
                        { "en", "A Filer and a Scamp" },
                    }
                },
                { "Фастфуд", new Dictionary<string, string>()
                    {
                        { "ru", "Фастфуд" },
                        { "en", "Fastfood" },
                    }
                },
                { "Бургер Кинг", new Dictionary<string, string>()
                    {
                        { "ru", "Бургер Кинг" },
                        { "en", "Burger King" },
                    }
                },
                { "Ресторан американской кухни", new Dictionary<string, string>()
                    {
                        { "ru", "Ресторан американской кухни" },
                        { "en", "American Cuisine Restaurant" },
                    }
                },
                { "Парк аттракционов", new Dictionary<string, string>()
                    {
                        { "ru", "Парк аттракционов" },
                        { "en", "Amusement Park" },
                    }
                },
                { "Государственный университет", new Dictionary<string, string>()
                    {
                        { "ru", "Государственный университет" },
                        { "en", "State University" },
                    }
                },
                { "Общественный медицинский центр", new Dictionary<string, string>()
                    {
                        { "ru", "Общественный медицинский центр" },
                        { "en", "Public Medical Center" },
                    }
                },
                { "About", new Dictionary<string, string>()
                    {
                        { "ru", "О приложении" },
                        { "en", "About" },
                    }
                },
                { "The purpose of the application", new Dictionary<string, string>()
                    {
                        { "ru", "Цель приложения" },
                        { "en", "The purpose of the application" },
                    }
                },
                { "Purpose of...", new Dictionary<string, string>()
                    {
                        { "ru", "Цель приложения - предоставить пользователям удобный и эффективный инструмент для поиска, изучения и сохранения интересных мест и достопримечательностей во Владимире. Пользователи могут добавлять места в избранное, изучать новые локации, а также использовать приложение для планирования туристических маршрутов по городу." },
                        { "en", "The purpose of the application is to provide users with a convenient and effective tool for searching, exploring and preserving interesting places and attractions in Vladimir. Users can add places to their favorites, explore new locations, and use the app to plan tourist routes around the city." },
                    }
                },
                { "АДРЕС1", new Dictionary<string, string>()
                    {
                        { "ru", "ул. Большая Московская ул., 1а, Владимир, Владимирская обл., Россия, 600000" },
                        { "en", "Bolshaya Moskovskaya St., 1a, Vladimir, Vladimir Oblast, Russia, 600000" },
                    }
                },
                { "АДРЕС2", new Dictionary<string, string>()
                    {
                        { "ru", "ул. Большая Московская ул., 58, Владимир, Владимирская обл., Россия, 600000" },
                        { "en", "Bolshaya Moskovskaya St., 58, Vladimir, Vladimir Oblast, Russia, 600000" },
                    }
                },
                { "АДРЕС3", new Dictionary<string, string>()
                    {
                        { "ru", "ул., 36А, ул. Студеная Гора, Владимир, Владимирская обл., Россия, 600001" },
                        { "en", "36A, Studenaya Gora St., Vladimir, Vladimir Oblast, Russia, 600001" },
                    }
                },
                { "АДРЕС4", new Dictionary<string, string>()
                    {
                        { "ru", "ул. Большая Московская ул., 44Б, Владимир, Владимирская обл., Россия, 600000" },
                        { "en", "Bolshaya Moskovskaya St., 44B, Vladimir, Vladimir Oblast, Russia, 600000" },
                    }
                },
                { "АДРЕС5", new Dictionary<string, string>()
                    {
                        { "ru", "пр. Строителей, 15 Д, Владимир, Владимирская обл., Россия, 600028" },
                        { "en", "15 D, Stroiteley Ave., Vladimir, Vladimir Oblast, Russia, 600028" },
                    }
                },
                { "АДРЕС6", new Dictionary<string, string>()
                    {
                        { "ru", "Владимир, Владимирская обл., 600000" },
                        { "en", "Vladimir, Vladimir Oblast, 600000" },
                    }
                },
                { "АДРЕС7", new Dictionary<string, string>()
                    {
                        { "ru", "ул. Козлов Вал, 5, Владимир, Владимирская обл., Россия" },
                        { "en", "Kozlov Val St., 5, Vladimir, Vladimir Oblast, Russia" },
                    }
                },
                { "АДРЕС8", new Dictionary<string, string>()
                    {
                        { "ru", "Тракторная ул., 45, Владимир, Владимирская обл., 600005" },
                        { "en", "45, Traktornaya St., Vladimir, Vladimir Oblast, Russia, 600005" },
                    }
                },
                { "АДРЕС9", new Dictionary<string, string>()
                    {
                        { "ru", "Парк 850-летия, ул. Мира, д.36, Владимир, Владимирская обл., 600009" },
                        { "en", "850th Anniversary Park, Mira St., 36, Vladimir, Vladimir Oblast, Russia, 600009" },
                    }
                },
                { "АДРЕС10", new Dictionary<string, string>()
                    {
                        { "ru", "пр. Строителей, 11, Владимир, Владимирская обл., 600024" },
                        { "en", "11, Stroiteley Ave., Vladimir, Vladimir Oblast, Russia, 600024" },
                    }
                },
                { "АДРЕС11", new Dictionary<string, string>()
                    {
                        { "ru", "ул. Горького, 94, Владимир, Владимирская обл., 600026" },
                        { "en", "94, Gorkogo St., Vladimir, Vladimir Oblast, Russia, 600026" },
                    }
                },
                { "АДРЕС12", new Dictionary<string, string>()
                    {
                        { "ru", "ул. Большая Московская ул., 11, Владимир, Владимирская обл., Россия, 600000" },
                        { "en", "11 Bolshaya Moskovskaya st., Vladimir, Vladimir region, Russia, 600000" },
                    }
                },
                { "АДРЕС13", new Dictionary<string, string>()
                    {
                        { "ru", "пр. Ленина, 29, Владимир, Владимирская обл., Россия, 600015" },
                        { "en", "29 Lenin Ave., Vladimir, Vladimir region, Russia, 600015" },
                    }
                },
                { "АДРЕС14", new Dictionary<string, string>()
                    {
                        { "ru", "Георгиевкая ул., 9, Владимир, Владимирская обл., 600000" },
                        { "en", "Georgievskaya St., 9, Vladimir, Vladimir region, 600000" },
                    }
                },

            };

            return tran[key][language];
        }
    }
}