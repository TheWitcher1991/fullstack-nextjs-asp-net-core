using AutoMapper;
using backend.Abstractions;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FavoriteRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Favorite>> List()
        {
            var favoriteEntities = await _context.Favorites
                .AsNoTracking()
                .ToListAsync();

            var favorites = favoriteEntities.Select(f => Favorite.Create(
                f.Id,
                _mapper.Map<Book>(f.Book),
                _mapper.Map<User>(f.User)
                ))
                .ToList();

            return favorites;
        }

        public async Task<List<Favorite>> ListByUserId(Guid userId)
        {
            var favoriteEntities = await _context.Favorites
                .AsNoTracking()
                .Where(f => f.UserId == userId)
                .ToListAsync();

            var favorites = favoriteEntities.Select(f => Favorite.Create(
                f.Id,
                _mapper.Map<Book>(f.Book),
                _mapper.Map<User>(f.User)
                ))
                .ToList();

            return favorites;
        }

        public async Task<Guid> Add(Favorite favorite)
        {
            var favoriteEntity = new FavoriteEntity
            {
                Id = favorite.Id,
                BookId = favorite.Book.Id,
                UserId = favorite.User.Id,
            };

            await _context.Favorites.AddAsync(favoriteEntity);
            await _context.SaveChangesAsync();

            return favoriteEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Favorites.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
