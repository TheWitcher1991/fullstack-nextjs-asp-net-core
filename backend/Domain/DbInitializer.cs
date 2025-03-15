using backend.Domain.Entities;
using backend.Domain.Models;
using System.Linq;
using static backend.Domain.Permissions;

namespace backend.Domain
{
    public static class DbInitializer
    {
        private static Guid USER_GUID = Guid.Parse("6ed817db-645d-4fbd-96bc-6984049758d4");

        public static List<TopicEntity> TopicsData()
        {
            return new List<TopicEntity>
            {
                new TopicEntity { Id = Guid.Parse("ceaae55b-1d51-45b5-8a9b-10a4b20720ab"), Title = "Психология" },
                new TopicEntity { Id = Guid.Parse("77a24f9e-92cb-47ea-9081-20e304d0c265"), Title = "Саморазвитие" },
                new TopicEntity { Id = Guid.Parse("2423895f-d942-43c9-a9e6-0780cc8e951f"), Title = "Нон-фикшн" },
                new TopicEntity { Id = Guid.Parse("d8401754-a668-4dfb-bf8f-4285b09f2ae2"), Title = "Романтика" },
                new TopicEntity { Id = Guid.Parse("bbc92f51-4ce7-4951-930b-25c81a077fb1"), Title = "Проза" },
                new TopicEntity { Id = Guid.Parse("bd922041-23f5-4ad2-8ad3-9619acd1987d"), Title = "Детективы" },
                new TopicEntity { Id = Guid.Parse("d0698f7c-bfef-4f30-a207-8ffb81aa9c99"), Title = "Бизнес" },
                new TopicEntity { Id = Guid.Parse("8621520d-751d-453e-a5b8-f159806b3cd6"), Title = "Young Adult" },
                new TopicEntity { Id = Guid.Parse("a7dcde27-4593-4678-b41d-035ac02b50da"), Title = "Фантастика" },
                new TopicEntity { Id = Guid.Parse("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a"), Title = "Фэнтези" },
                new TopicEntity { Id = Guid.Parse("a93cc00e-9698-4b25-8af2-2be8c1419d02"), Title = "Мемуары" },
                new TopicEntity { Id = Guid.Parse("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6"), Title = "Триллеры" },
                new TopicEntity { Id = Guid.Parse("36638e3f-0125-45a5-b319-5168f5204bd6"), Title = "Хорроры" },
                new TopicEntity { Id = Guid.Parse("5267e8c7-a191-417c-93ac-287800972997"), Title = "Здоровье" },
            };
        }

        public static List<CategoryEntity> CategoriesData()
        {
            var topics = TopicsData();
            var categories = new List<CategoryEntity>();

            var topicCategoryMapping = new Dictionary<string, List<string>>
            {
                { "Психология", new() { "Клиническая", "Социальная", "Когнитивная" } },
                { "Саморазвитие", new() { "Личная эффективность", "Мотивация", "Навыки общения" } },
                { "Нон-фикшн", new() { "История", "Наука", "Биографии" } },
                { "Романтика", new() { "Любовные романы", "Драма", "Эротика" } },
                { "Проза", new() { "Современная", "Классическая", "Экспериментальная" } },
                { "Детективы", new() { "Классические", "Полицейские", "Психологические" } },
                { "Бизнес", new() { "Финансы", "Менеджмент", "Стартапы" } },
                { "Young Adult", new() { "Фэнтези", "Реализм", "Дружба" } },
                { "Фантастика", new() { "Научная", "Космическая", "Альтернативная история" } },
                { "Фэнтези", new() { "Эпическое", "Темное", "Мифологическое" } },
                { "Мемуары", new() { "Автобиографии", "Исторические", "Литературные" } },
                { "Триллеры", new() { "Политические", "Шпионские", "Психологические" } },
                { "Хорроры", new() { "Готические", "Паранормальные", "Маньяки" } },
                { "Здоровье", new() { "Питание", "Фитнес", "Психосоматика" } }
            };

            foreach (var topic in topics)
            {
                if (topicCategoryMapping.TryGetValue(topic.Title, out var categoryTitles))
                {
                    categories.AddRange(categoryTitles.Select(title => new CategoryEntity
                    {
                        Id = Guid.NewGuid(),
                        Title = title,
                        TopicId = topic.Id
                    }));
                }
            }

            return categories;
        }

        public static List<EmotionEntity> EmotionsData()
        {
            return new List<EmotionEntity>
            {
                new() { Id = Guid.NewGuid(), Label = "Советую", Name = "thumbsup", Unicode = "👍" },
                new() { Id = Guid.NewGuid(), Label = "Не советую", Name = "thumbsdown", Unicode = "👎" },
                new() { Id = Guid.NewGuid(), Label = "До слез", Name = "droplet", Unicode = "💧" },
                new() { Id = Guid.NewGuid(), Label = "Мило", Name = "panda_face", Unicode = "🐼" },
                new() { Id = Guid.NewGuid(), Label = "Скучно", Name = "zzz", Unicode = "😴" },
                new() { Id = Guid.NewGuid(), Label = "Фууу", Name = "shit", Unicode = "💩" },
                new() { Id = Guid.NewGuid(), Label = "Страшно", Name = "skull", Unicode = "💀" },
                new() { Id = Guid.NewGuid(), Label = "Ничего не понятно", Name = "confusing", Unicode = "🙈" },
                new() { Id = Guid.NewGuid(), Label = "Мудро", Name = "wise", Unicode = "🔮" },
                new() { Id = Guid.NewGuid(), Label = "Познавательно", Name = "bulb", Unicode = "💡" },
                new() { Id = Guid.NewGuid(), Label = "Полезно", Name = "useful", Unicode = "🎯" },
                new() { Id = Guid.NewGuid(), Label = "Романтично", Name = "romantic", Unicode = "💞" },
                new() { Id = Guid.NewGuid(), Label = "В отпуск", Name = "palm_tree", Unicode = "🏝" },
                new() { Id = Guid.NewGuid(), Label = "Не оторваться", Name = "rocket", Unicode = "🚀" },
                new() { Id = Guid.NewGuid(), Label = "Весело", Name = "fun", Unicode = "😆" },
            };
        }

        public static List<UserEntity> UsersData()
        {
            return new List<UserEntity>
            {
                new() { 
                    Id = USER_GUID,
                    Email = "ashot.svazyan@yandex.ru",
                    Phone = "+79097677217",
                    Role = Shared.Enums.Role.User,
                    FirstName = "Ашот",
                    LastName = "Свазян",
                    Password = "$2a$11$6gNRPxWDFoeAaYcCPIvlHunXNKDIjStIjcuxHMJr8dWanHgNVBbq6"
                },
            };
        }

        public static List<AuthorEntity> AuthorsData()
        {
            return new List<AuthorEntity>
            {
                new()
                {
                    Id = Guid.Parse("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"),
                    FullName = "Анджей Сапковский",
                    About = "Анджей Сапковский (1948) — польский писатель-фантаст, автор фэнтези-цикла о ведьмаке, лауреат множества литературных премий, второй самый печатаемый польский автор в мире после Станислава Лема.",
                    AvatarPath = "/authors/sab.jpg",
                },
                new()
                {
                    Id = Guid.Parse("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"),
                    FullName = "Дмитрий Глуховский",
                    About = "Дмитрий Глуховский (1979 г. р.) — российский писатель. С момента окончания университета профессия Дмитрия Глуховского — журналист. Работал на телевидении, радио, в печатных СМИ. Автор фантастического романа «Метро 2033», переведенного на 37 языков.",
                    AvatarPath = "/authors/dgx.jpg",
                },
                new()
                {
                    Id = Guid.Parse("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"),
                    FullName = "Говард Филлипс Лавкрафт",
                    About = "Американский писатель, работавший в жанрах литературы ужасов, мистики и научной фантастики и, на их основе создавший узнаваемый стиль «лавкрафтовского хоррора».",
                    AvatarPath = "/authors/gov.jpg",
                },
                new()
                {
                    Id = Guid.Parse("1b5121c4-fe52-4d22-80f1-2625c00fc484"),
                    FullName = "Джон Рональд Руэл Толкин",
                    About = "Всемирно известный английский писатель, лингвист, профессор Оксфордского университета и один из основателей «высокого фэнтези» Джон Рональд Руэл Толкин родился в 1892 году в Блумфонтейне, Оранжевая республика (сейчас ЮАР). В Англию будущий писатель с мамой и братом переехал четыре года спустя.",
                    AvatarPath = "/authors/tol.jpg",
                },
                new()
                {
                    Id = Guid.Parse("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"),
                    FullName = "Джордж Оруэлл",
                    About = "Английский писатель, автор сатирической повести «Скотный двор» и романа-антиутопии «1984», журналист и общественный деятель. Имя при рождении — Эрик Артур Блэр.",
                    AvatarPath = "/authors/ou.jpg",
                },
                new()
                {
                    Id = Guid.Parse("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"),
                    FullName = "Лев Толстой",
                    About = "Лев Толстой — русский писатель. Родился и провел детство в семейном имении Ясная Поляна. Поступил в университет, но, не окончив его, вернулся домой, чтобы заниматься делами поместья.",
                    AvatarPath = "/authors/lev.jpg",
                },
                new()
                {
                    Id = Guid.Parse("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"),
                    FullName = "Лев Толстой",
                    About = "Лев Толстой — русский писатель. Родился и провел детство в семейном имении Ясная Поляна. Поступил в университет, но, не окончив его, вернулся домой, чтобы заниматься делами поместья.",
                    AvatarPath = "/authors/lev.jpg",
                },
                new()
                {
                    Id = Guid.Parse("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"),
                    FullName = "Аркадий Стругацкий",
                    About = "Советский и российский писатель-фантаст, представитель поджанра твердой научной фантастики, работавший в писательском тандеме со своим братом — Борисом Стругацким.",
                    AvatarPath = "/authors/str.jpg",
                }
            };
        }

        public static List<BookEntity> BooksData()
        {
            var authors = AuthorsData();
            var categories = CategoriesData();
            var books = new List<BookEntity>();

            var booksByAuthor = new Dictionary<Guid, List<string>>
            {
                { authors[0].Id, new() { "Последнее желание", "Меч Предназначения", "Кровь эльфов", "Час презрения", "Крещение огнем", "Башня ласточки", "Сезон гроз", "Владычица озера" } },
                { authors[1].Id, new() { "Метро 2033", "Метро 2034", "Метро 2035", "Третий Рим. ВДНХ", "Метро 2033: Последнее убежище" } },
                { authors[2].Id, new() { "Зов Ктулху", "Тень над Иннсмутом", "Хребты безумия", "Дагон", "Шепчущий во тьме", "Некрономикон", "Цвет из иных миров", "Таящийся у порога" } },
                { authors[4].Id, new() { "Сильмариллион", "Природа Средиземья", "Две твердыни", "Две крепости", "Дети Хурина", "Хоббит", "Властелин колец", "Падение Гондолина", } },
                { authors[5].Id, new() { "1984", "Скотный двор", "Дочь сващенника", "Дни в Бирме", "Глотнуть воздуха", "Фунты лиха в Париже и Лондоне", "Дорога на Уиган-Пирс", } },
                { authors[6].Id, new() { "Воскресенье", "Анна Каренина", "Детство", "Война и мир", "Смерть Ивана Ильича", "Крейцерова соната", "Хаджи-Мурат", "Дьявол" } },
                { authors[7].Id, new() { "Пикник на обочине", "Забытий эксперимент", "Трудно быть богом", "Врата космоса", "Звездолет Астра-12", "Экспедиция в преисподнюю" } },
            };

            var i = 0;

            foreach (var (authorId, booksList) in booksByAuthor)
            {
                i++;

                var author = authors.FirstOrDefault(a => a.Id == authorId);

                if (author == null)
                    continue;

                books.AddRange(booksList.Select(book => new BookEntity
                {
                    Id = Guid.NewGuid(),
                    ImagePath = "",
                    FilePath = "",
                    Title = book,
                    Description = $"Описание книги {book}",
                    Publisher = "Издательство АСТ",
                    Holder = author.FullName,
                    Translator = "Костина Анна",
                    Age = 16,
                    Pages = 305,
                    UserId = USER_GUID,
                    AuthorId = authorId,
                }));
            }

            return books;
        }

        public static List<ImpressionEntity> ImpressionsData()
        {
            return new List<ImpressionEntity>
            {

            };
        }
    }
}
