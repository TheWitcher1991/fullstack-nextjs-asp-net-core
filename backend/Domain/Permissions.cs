namespace backend.Domain
{
    public class Permissions
    {
        public static class Books
        {
            public const string READ_BOOKS = "books.read";
            public const string CREATE_BOOKS = "books.create";
            public const string UPDATE_BOOKS = "books.update";
            public const string DELETE_BOOKS = "books.delete";
        }

        public static class Categories
        {
            public const string READ_CATEGORIES = "categories.read";
            public const string CREATE_CATEGORIES = "categories.create";
            public const string UPDATE_CATEGORIES = "categories.update";
            public const string DELETE_CATEGORIES = "categories.delete";
        }

        public static class Emotions
        {
            public const string READ_EMOTIONS = "emotions.read";
            public const string CREATE_EMOTIONS = "emotions.create";
            public const string UPDATE_EMOTIONS = "emotions.update";
            public const string DELETE_EMOTIONS = "emotions.delete";
        }

        public static class Favorites
        {
            public const string READ_FAVORITES = "favorites.read";
            public const string CREATE_FAVORITES = "favorites.create";
            public const string UPDATE_FAVORITES = "favorites.update";
            public const string DELETE_FAVORITES = "favorites.delete";
        }

        public static class Impressions
        {
            public const string READ_IMPRESSIONS = "impressions.read";
            public const string CREATE_IMPRESSIONS = "impressions.create";
            public const string UPDATE_IMPRESSIONS = "impressions.update";
            public const string DELETE_IMPRESSIONS = "impressions.delete";
        }

        public static class Topics
        {
            public const string READ_TOPICS = "topics.read";
            public const string CREATE_TOPICS = "topics.create";
            public const string UPDATE_TOPICS = "topics.update";
            public const string DELETE_TOPICS = "topics.delete";
        }

        public static class Accounts
        {
            public const string ENROLL_ACCOUNT = "accounts.enroll";
            public const string READ_ACCOUNT = "accounts.read";
            public const string UPDATE_ACCOUNT = "accounts.update";
        }
    }
}
