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
            };

            return tran[key][language];
        }
    }
}