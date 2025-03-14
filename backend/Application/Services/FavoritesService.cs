using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain.Abstractions;
using backend.Domain.Models;

namespace backend.Application.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IFavoriteRepository repository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;

        public FavoritesService(
            IFavoriteRepository favoriteRepository,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IJwtProvider jwtProvider,
            IMapper mapper)
        {
            repository = favoriteRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }

        private async Task<User> DecodeUserToken(string token)
        {
            var userId = _jwtProvider.Decode(token);

            if (userId == Guid.Empty)
                throw new BadHttpRequestException("Invalid token");

            var user = await _userRepository.GetById(userId);

            return user;
        }

        public async Task<List<FavoriteDto>> GetAllFavorites(string token)
        {
            var user = await DecodeUserToken(token);

            var favorites = await repository.ListByUserId(user.Id);

            var response = favorites.Select(f => new FavoriteDto(
                    f.Id,
                    _mapper.Map<FavoriteBookDto>(f.Book),
                    f.CreatedAt
                ))
                .ToList();

            return response;
        }

        public async Task<Guid> AddFavorite(string token, CreateFavoriteDto dto)
        {
            var user = await DecodeUserToken(token);
            var book = await _bookRepository.GetById(dto.Book);

            if (book == null || user == null)
                throw new BadHttpRequestException("Bad request");

            var favorite = Favorite.Create(
                Guid.NewGuid(),
                book,
                user
            );

            return await repository.Add(favorite);
        }

        public async Task<Guid> DeleteFavorite(Guid id)
        {
            return await repository.Delete(id);
        }
    }
}
