using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain.Entities;
using backend.Domain.Models;

namespace backend.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEntity, Book>();
            CreateMap<BookEntity, BookDto>();
            CreateMap<BookEntity, FavoriteBookDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Book, FavoriteBookDto>();

            CreateMap<TopicEntity, Topic>();
            CreateMap<TopicEntity, TopicDto>();
            CreateMap<Topic, TopicDto>();

            CreateMap<CategoryEntity, Category>();
            CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<Category, CategoryDto>();

            CreateMap<FavoriteEntity, Favorite>();
            CreateMap<FavoriteEntity, FavoriteDto>();

            CreateMap<EmotionEntity, Emotion>();
            CreateMap<EmotionEntity, EmotionDto>();
            CreateMap<Emotion, EmotionDto>();

            CreateMap<UserEntity, User>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserBookDto>();
            CreateMap<User, UserDto>();
            CreateMap<User, UserBookDto>();

            CreateMap<ImpressionEntity, Impression>();
            CreateMap<ImpressionEntity, ImpressionDto>();
            CreateMap<ImpressionEntity, ImpressionUserDto>();
            CreateMap<Impression, ImpressionDto>();
            CreateMap<Impression, ImpressionUserDto>();
        }
    }
}
