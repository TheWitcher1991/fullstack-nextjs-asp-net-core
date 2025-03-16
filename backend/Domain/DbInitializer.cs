using backend.Domain.Entities;
using backend.Domain.Models;

namespace backend.Domain
{
    public static class DbInitializer
    {
        private static Guid USER_GUID = Guid.Parse("6ed817db-645d-4fbd-96bc-6984049758d4");

        private record AuthorBook(string Title, string Path);

        private static int GetRandomAge()
        {
            int[] numbers = { 12, 16, 18 };
            Random random = new Random();
            return numbers[random.Next(numbers.Length)];
        }

        private static int GetRandomPages()
        {
            Random random = new Random();
            return random.Next(120, 301);
        }

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

            /*
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
            */

            return new List<CategoryEntity>
            {
                new CategoryEntity { Id = Guid.Parse("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc"), Title = "Клиническая", TopicId = topics[0].Id },
                new CategoryEntity { Id = Guid.Parse("4f9728af-2514-465b-b14c-4153a3e9b624"), Title = "Социальная", TopicId = topics[0].Id },
                new CategoryEntity { Id = Guid.Parse("4bc78904-c521-4c9a-a141-c02c28e5fd8b"), Title = "Когнитивная", TopicId = topics[0].Id },

                new CategoryEntity { Id = Guid.Parse("139e8271-39bd-48c5-aad2-d62ee20ffaf0"), Title = "Личная эффективность", TopicId = topics[1].Id },
                new CategoryEntity { Id = Guid.Parse("e00dc6e2-efff-4891-aa5e-84dcdbd3dec2"), Title = "Мотивация", TopicId = topics[1].Id },
                new CategoryEntity { Id = Guid.Parse("d6d3e8e2-7cb4-44c6-aeb9-3653fb0988cd"), Title = "Навыки общения", TopicId = topics[1].Id },

                new CategoryEntity { Id = Guid.Parse("570e742c-fad0-4f6f-a6c9-539897ee17d6"), Title = "История", TopicId = topics[2].Id },
                new CategoryEntity { Id = Guid.Parse("186ac534-4c6e-4c16-9a44-1fa73f8db668"), Title = "Наука", TopicId = topics[2].Id },
                new CategoryEntity { Id = Guid.Parse("bf17f164-8b99-4973-8fc9-3d10d6ac1609"), Title = "Биографии", TopicId = topics[2].Id },

                new CategoryEntity { Id = Guid.Parse("1f9bc60a-27a7-426f-88db-3c1341aabc16"), Title = "Любовные романы", TopicId = topics[3].Id },
                new CategoryEntity { Id = Guid.Parse("5bafd2c6-d952-46b2-9ae6-508d4c9de2f0"), Title = "Драма", TopicId = topics[3].Id },
                new CategoryEntity { Id = Guid.Parse("7f05a0db-dd14-4df2-a6ef-ba0ccb99de49"), Title = "Эротика", TopicId = topics[3].Id },

                new CategoryEntity { Id = Guid.Parse("b3a7ee49-0c15-4c26-b0a5-63d03d5e1c47"), Title = "Современная", TopicId = topics[4].Id },
                new CategoryEntity { Id = Guid.Parse("25b4fe4f-4a30-4fed-a5cd-db7fdab89c8f"), Title = "Классическая", TopicId = topics[4].Id },
                new CategoryEntity { Id = Guid.Parse("7b3fe946-dac1-40f9-8828-11b1c1c4ed75"), Title = "Экспериментальная", TopicId = topics[4].Id },

                new CategoryEntity { Id = Guid.Parse("9a7b6af2-79f3-457d-bbfa-2b6bf5726db4"), Title = "Классические", TopicId = topics[5].Id },
                new CategoryEntity { Id = Guid.Parse("0f323869-f631-4c91-ba12-c812f8358e92"), Title = "Полицейские", TopicId = topics[5].Id },
                new CategoryEntity { Id = Guid.Parse("032dfe50-1dfc-40aa-a17b-9415b0e0343c"), Title = "Психологические", TopicId = topics[5].Id },

                new CategoryEntity { Id = Guid.Parse("62973166-cc3b-44fd-8bdd-76ac5b1f7922"), Title = "Финансы", TopicId = topics[6].Id },
                new CategoryEntity { Id = Guid.Parse("ebe0653c-b3f7-43d8-a4db-ba8df169936d"), Title = "Менеджмент", TopicId = topics[6].Id },
                new CategoryEntity { Id = Guid.Parse("894fcac2-4b8e-40e2-b03d-119d77c3be14"), Title = "Стартапы", TopicId = topics[6].Id },

                new CategoryEntity { Id = Guid.Parse("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a"), Title = "Фэнтези", TopicId = topics[7].Id },
                new CategoryEntity { Id = Guid.Parse("8e637311-c3f4-4e5b-82fc-0a1a0d3a6bb1"), Title = "Реализм", TopicId = topics[7].Id },
                new CategoryEntity { Id = Guid.Parse("3c50913b-a568-4de3-92fd-41577604e70b"), Title = "Дружба", TopicId = topics[7].Id },

                new CategoryEntity { Id = Guid.Parse("b1d38b75-4f26-482a-b017-b8ee2b838fdc"), Title = "Научная", TopicId = topics[8].Id },
                new CategoryEntity { Id = Guid.Parse("dfb76f27-1727-4c03-8886-afd8e80183de"), Title = "Космическая", TopicId = topics[8].Id },
                new CategoryEntity { Id = Guid.Parse("fff5aefc-fecb-4402-a23b-e2455ed1808d"), Title = "Альтернативная история", TopicId = topics[8].Id },

                new CategoryEntity { Id = Guid.Parse("683da31e-af9b-43b7-8654-7da110c19428"), Title = "Эпическое", TopicId = topics[9].Id },
                new CategoryEntity { Id = Guid.Parse("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34"), Title = "Темное", TopicId = topics[9].Id },
                new CategoryEntity { Id = Guid.Parse("ddf8c566-a91b-4c83-9f6a-afcbb634f881"), Title = "Мифологическое", TopicId = topics[9].Id },

                new CategoryEntity { Id = Guid.Parse("2e5cf54d-8717-42b4-8dd3-5e01790daa26"), Title = "Автобиографии", TopicId = topics[10].Id },
                new CategoryEntity { Id = Guid.Parse("9c3405fc-368b-4082-9cee-c02fe6fa87c1"), Title = "Исторические", TopicId = topics[10].Id },
                new CategoryEntity { Id = Guid.Parse("06d5f66c-7896-4c24-9843-dba6021b2a64"), Title = "Литературные", TopicId = topics[10].Id },

                new CategoryEntity { Id = Guid.Parse("bc6fb040-506d-46df-a040-ea370c5ca6b0"), Title = "Политические", TopicId = topics[11].Id },
                new CategoryEntity { Id = Guid.Parse("c0127b2a-777a-44f2-863a-f09b80ebd577"), Title = "Шпионские", TopicId = topics[11].Id },
                new CategoryEntity { Id = Guid.Parse("b273dccc-8d62-433e-9d58-e567e373dfa3"), Title = "Психологические", TopicId = topics[11].Id },

                new CategoryEntity { Id = Guid.Parse("2bc30f2b-cba3-453e-839c-24bee14f945d"), Title = "Готические", TopicId = topics[12].Id },
                new CategoryEntity { Id = Guid.Parse("9ad32ac1-8e8f-423e-b02d-73ddc353c339"), Title = "Паранормальные", TopicId = topics[12].Id },
                new CategoryEntity { Id = Guid.Parse("b8b69d68-d0b8-4e2f-96ca-7ca2f715b52b"), Title = "Маньяки", TopicId = topics[12].Id },

                new CategoryEntity { Id = Guid.Parse("f322cd5d-4841-45ba-845e-90c1a2ff967f"), Title = "Питание", TopicId = topics[13].Id },
                new CategoryEntity { Id = Guid.Parse("03aa504c-c8c9-45e1-b456-f196834ace41"), Title = "Фитнес", TopicId = topics[13].Id },
                new CategoryEntity { Id = Guid.Parse("58401406-bca2-4ff4-a77a-ff30d0905535"), Title = "Психосоматика", TopicId = topics[13].Id },
            };
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
                    Id = Guid.Parse("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"),
                    FullName = "Аркадий Стругацкий",
                    About = "Советский и российский писатель-фантаст, представитель поджанра твердой научной фантастики, работавший в писательском тандеме со своим братом — Борисом Стругацким.",
                    AvatarPath = "/authors/str.jpg",
                }
            };
        }

        public static (List<BookEntity>, List<object>) BooksData()
        {
            var authors = AuthorsData();
            var categories = CategoriesData();
            var books = new List<BookEntity>();
            var bookCategories = new List<object>();

            var booksByAuthor = new Dictionary<Guid, List<AuthorBook>>
            {
                { authors[0].Id, new()
                    {
                        new("Последнее желание", "/books/pos.jpg"),
                        new("Меч Предназначения", "/books/sword.jpg"),
                        new("Кровь эльфов", "/books/blood.jpg"),
                        new("Час презрения", "/books/hour.jpg"),
                        new("Крещение огнем", "/books/fire.jpg"),
                        new("Башня ласточки", "/books/tower.jpg"),
                        new("Сезон гроз", "/books/sezon.jpg"),
                        new("Владычица озера", "/books/ozero.jpg")
                    }
                },
                { authors[1].Id, new()
                    {
                        new("Метро 2033", "/books/2033.jpg"),
                        new("Метро 2034", "/books/2034.jpg"),
                        new("Метро 2035", "/books/2035.jpg"),
                        new("Третий Рим. ВДНХ", "/books/rim.jpg"),
                        new("Метро 2033: Последнее убежище", "/books/lost.jpg")
                    }
                },
                { authors[2].Id, new()
                    {
                        new("Зов Ктулху", "/books/zov.jpg"),
                        new("Тень над Иннсмутом", "/books/innsmouth.jpg"),
                        new("Хребты безумия", "/books/bez.jpg"),
                        new("Дагон", "/books/dagon.jpg"),
                        new("Шепчущий во тьме", "/books/vo_tme.jpg"),
                        new("Некрономикон", "/books/nekro.jpg"),
                        new("Цвет из иных миров", "/books/chvet.jpg"),
                        new("Таящийся у порога", "/books/porog.jpg")
                    }
                },
                { authors[4].Id, new()
                    {
                        new("Сильмариллион", "/books/sim.jpg"),
                        new("Природа Средиземья", "/books/prid.jpg"),
                        new("Две твердыни", "/books/dvet.jpg"),
                        new("Две крепости", "/books/devk.jpg"),
                        new("Дети Хурина", "/books/child.jpg"),
                        new("Хоббит", "/books/xob.jpg"),
                        new("Властелин колец", "/books/vlas.jpg"),
                        new("Падение Гондолина", "/books/gondor.jpg")
                    }
                },
                { authors[5].Id, new()
                    {
                        new("1984", "/books/1984.jpg"),
                        new("Скотный двор", "/books/skot.jpg"),
                        new("Дочь священника", "/books/doch.jpg"),
                        new("Дни в Бирме", "/books/birma.jpg"),
                        new("Глотнуть воздуха", "/books/voz.jpg"),
                        new("Фунты лиха в Париже и Лондоне", "/books/funt.jpg"),
                        new("Дорога на Уиган-Пирс", "/books/doroga.jpg")
                    }
                },
                { authors[6].Id, new()
                    {
                        new("Воскресенье", "/books/vosk.jpg"),
                        new("Анна Каренина", "/books/anna.jpg"),
                        new("Детство", "/books/det.jpg"),
                        new("Война и мир", "/books/w.jpg"),
                        new("Смерть Ивана Ильича", "/books/dead.jpg"),
                        new("Крейцерова соната", "/books/son.jpg"),
                        new("Хаджи-Мурат", "/books/murat.jpg"),
                        new("Дьявол", "/books/dia.jpg")
                    }
                },
                { authors[7].Id, new()
                    {
                        new("Пикник на обочине", "/books/pick.jpeg"),
                        new("Забытый эксперимент", "/books/zab.jpg"),
                        new("Трудно быть богом", "/books/god.jpg"),
                        new("Врата космоса", "/books/kos.jpg"),
                        new("Звездолет Астра-12", "/books/a12.jpg"),
                        new("Экспедиция в преисподнюю", "/books/spes.jpg")
                    }
                }
            };

            foreach (var (authorId, booksList) in booksByAuthor)
            {
                var author = authors.FirstOrDefault(a => a.Id == authorId);

                if (author == null)
                    continue;

                foreach (var book in booksList)
                {
                    var entity = new BookEntity
                    {
                        Id = Guid.NewGuid(),
                        ImagePath = book.Path,
                        FilePath = "/books/book.pdf",
                        Title = $"{book.Title}",
                        Description = $"Описание книги {book.Title}",
                        Publisher = "Издательство АСТ",
                        Holder = author.FullName,
                        Translator = "Костина Анна",
                        Age = GetRandomAge(),
                        Pages = GetRandomPages(),
                        UserId = USER_GUID,
                        AuthorId = authorId,
                    };

                    var category = categories[new Random().Next(categories.Count)];

                    bookCategories.Add(new
                    {
                        BookId = entity.Id,
                        CategoryId = category.Id
                    });


                    books.Add(entity);
                }
            }

            return (books, bookCategories);
        }

        public static List<ImpressionEntity> ImpressionsData()
        {
            return new List<ImpressionEntity>
            {

            };
        }
    }
}
