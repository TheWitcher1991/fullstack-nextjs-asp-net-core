using backend.Domain.Entities;

namespace backend.Domain
{
    public static class DbInitializer
    {
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
    }
}
