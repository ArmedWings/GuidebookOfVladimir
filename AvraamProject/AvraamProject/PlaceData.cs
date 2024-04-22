using System.Collections.Generic;
using System.Numerics;
using AvraamProject.Models;

namespace AvraamProject.Data
{
    public static class PlaceData
    {
        public static List<Models.Place> GetPlaces()
        {
            return new List<Models.Place>
            {
                new Models.Place { Id = 1, Name = "Золотые ворота", Description = "Музей культурного наследия", Type = "Развлечения", Category = "Музей", Address = "ул. Большая Московская ул., 1а, Владимир, Владимирская обл., Россия, 600000", Site = "http://vladmuseum.ru", Popularity = 5522, Rating = 4.8f, Url = "https://www.google.ru/maps/place/%D0%97%D0%BE%D0%BB%D0%BE%D1%82%D1%8B%D0%B5+%D0%B2%D0%BE%D1%80%D0%BE%D1%82%D0%B0/@56.126913,40.3975124,17z/data=!4m6!3m5!1s0x414c7bd8411a9def:0x153d3e61ad7bb076!8m2!3d56.1268222!4d40.397311!16zL20vMDd3el9y?entry=ttu" },
                new Models.Place { Id = 2, Name = "Владимиро-Суздальский музей-заповедник", Description = "Музей-заповедник", Type = "Развлечения", Category = "Музей", Address = "ул. Большая Московская ул., 58, Владимир, Владимирская обл., Россия, 600000", Site = "http://vladmuseum.ru", Popularity = 136, Rating = 4.7f, Url = "https://www.google.ru/maps/place/%D0%92%D0%BB%D0%B0%D0%B4%D0%B8%D0%BC%D0%B8%D1%80%D0%BE-%D0%A1%D1%83%D0%B7%D0%B4%D0%B0%D0%BB%D1%8C%D1%81%D0%BA%D0%B8%D0%B9+%D0%BC%D1%83%D0%B7%D0%B5%D0%B9-%D0%B7%D0%B0%D0%BF%D0%BE%D0%B2%D0%B5%D0%B4%D0%BD%D0%B8%D0%BA/@56.128364,40.4113133,15z/data=!4m6!3m5!1s0x414c7bd06fd67683:0x75d8077e4fbc5bd4!8m2!3d56.1284868!4d40.410232!16s%2Fg%2F121qslkd?entry=ttu" },
                new Models.Place { Id = 3, Name = "Отель Заря Владимир", Description = "Отель", Type = "Отдых", Category = "Отель", Address = "ул., 36А, ул. Студеная Гора, Владимир, Владимирская обл., Россия, 600001", Site = "http://hotel-zarya.ru", Popularity = 1014, Rating = 3.5f, Url = "https://www.google.ru/maps/place/%D0%9E%D1%82%D0%B5%D0%BB%D1%8C+%D0%97%D0%B0%D1%80%D1%8F+%D0%92%D0%BB%D0%B0%D0%B4%D0%B8%D0%BC%D0%B8%D1%80/@56.122391,40.3832272,15z/data=!4m9!3m8!1s0x414c796476a389fd:0x2d00d385a8f9b334!5m2!4m1!1i2!8m2!3d56.122694!4d40.3833239!16s%2Fg%2F1tgpr4vp?entry=ttu" },
                new Models.Place { Id = 4, Name = "Панорама", Description = "Ресторан", Type = "Гастрономия", Category = "Ресторан", Address = "ул. Большая Московская ул., 44Б, Владимир, Владимирская обл., Россия, 600000", Site = "http://панорама33.рф/restaurant/", Popularity = 1292, Rating = 4.5f, Url = "https://www.google.ru/maps/place/%D0%9F%D0%B0%D0%BD%D0%BE%D1%80%D0%B0%D0%BC%D0%B0/@56.1271214,40.4046437,15z/data=!4m9!3m8!1s0x414c7bd73ee70ac3:0x46f68cedd834b44!5m2!4m1!1i2!8m2!3d56.1273441!4d40.4054007!16s%2Fg%2F1s04b2qwn?entry=ttu" },
                new Models.Place { Id = 5, Name = "Клиника \"Твой Доктор\"", Description = "Медицинский центр", Type = "Больницы", Category = "Клиника", Address = "пр. Строителей, 15 Д, Владимир, Владимирская обл., Россия, 600028", Site = "http://tvoi-doctor33.ru", Popularity = 20, Rating = 3.9f, Url = "https://www.google.ru/maps/place/%D0%9A%D0%BB%D0%B8%D0%BD%D0%B8%D0%BA%D0%B0+%22%D0%A2%D0%B2%D0%BE%D0%B9+%D0%94%D0%BE%D0%BA%D1%82%D0%BE%D1%80%22/@56.1345968,40.3642013,15z/data=!4m6!3m5!1s0x414c79584eeb135d:0xd253ad342c44145e!8m2!3d56.1349299!4d40.365143!16s%2Fg%2F1hd_pp4f8?entry=ttu" },
                
                // Добавьте другие места
            };
        }
        public static Place GetPlaceById(int id)
        {
            var places = GetPlaces();  // Получаем список всех мест
            return places.Find(p => p.Id == id);
        }
    }
}