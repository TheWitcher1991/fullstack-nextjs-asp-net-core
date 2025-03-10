﻿namespace backend.Entities
{
    public class TopicEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; }
    }
}
