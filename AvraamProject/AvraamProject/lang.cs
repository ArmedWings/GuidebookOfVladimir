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
                }
            };

            return tran[key][language];
        }
    }
}