namespace backend.Models
{
    public class Impression
    {
        private Impression (
            Guid id,
            string text,
            bool isAdvise,
            bool isNoAsdvise,
            bool isToTearss,
            bool isNice,
            bool isBoring,
            bool isScary,
            bool isWisely,
            bool isUnclear,
            User user,
            Book book) {
            Id = id;
            Text = text;
            IsAdvise = isAdvise;
            IsNoAsdvise = isNoAsdvise;
            IsToTearss = isToTearss;
            IsNice = isNice;
            IsBoring = isBoring;
            IsScary = isScary;
            IsWisely = isWisely;
            IsUnclear = isUnclear;
            User = user;
            Book = book;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }
        public string Text { get; } = string.Empty;
        public bool IsAdvise { get; }
        public bool IsNoAsdvise { get; }
        public bool IsToTearss { get; }
        public bool IsNice { get; }
        public bool IsBoring { get; }
        public bool IsScary { get; }
        public bool IsWisely { get; }
        public bool IsUnclear { get; }
        public Guid UserId { get; }
        public Guid BookId { get; }
        public DateTime CreatedAt { get; }
        public virtual User User { get; }
        public virtual Book Book { get; }

        public static Impression Create(
            Guid id,
            string text,
            bool isAdvise,
            bool isNoAsdvise,
            bool isToTearss,
            bool isNice,
            bool isBoring,
            bool isScary,
            bool isWisely,
            bool isUnclear,
            User user,
            Book book)
        {
            return new Impression(id, text, isAdvise, isNoAsdvise, isToTearss, isNice, isBoring, isScary, isWisely, isUnclear, user, book);
        }
    }
}
