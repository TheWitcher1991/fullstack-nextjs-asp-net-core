using AutoMapper;
using backend.Abstractions;
using backend.Contracts;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ImpressionRepository : IImpressionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ImpressionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Impression>> ListByBookId(Guid bookId)
        {
            var impressionEntities = await _context.Impressions.AsNoTracking().Where(i => i.BookId == bookId).ToListAsync();

            var impressions = impressionEntities.Select(i => Impression.Create(
                i.Id,
                i.Text,
                i.IsAdvise,
                i.IsNoAsdvise,
                i.IsToTearss,
                i.IsNice,
                i.IsBoring,
                i.IsScary,
                i.IsWisely,
                i.IsUnclear,
                _mapper.Map<User>(i.User),
                _mapper.Map<Book>(i.Book)))
                .ToList();

            return impressions;
        }

        public async Task<List<Impression>> ListByUserId(Guid userId)
        {
            var impressionEntities = await _context.Impressions.AsNoTracking().Where(i => i.UserId == userId).ToListAsync();

            var impressions = impressionEntities.Select(i => Impression.Create(
                i.Id,
                i.Text,
                i.IsAdvise,
                i.IsNoAsdvise,
                i.IsToTearss,
                i.IsNice,
                i.IsBoring,
                i.IsScary,
                i.IsWisely,
                i.IsUnclear,
                _mapper.Map<User>(i.User),
                _mapper.Map<Book>(i.Book)))
                .ToList();

            return impressions;
        }

        public async Task<Impression> GetById(Guid id)
        {
            var impressionEntity = await _context.Impressions.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id) ?? throw new Exception();

            return _mapper.Map<Impression>(impressionEntity);
        }

        public async Task<Guid> Create(Impression impression)
        {
            var impressionEntity = new ImpressionEntity
            {
                Id = impression.Id,
                Text = impression.Text,
                IsAdvise = impression.IsAdvise,
                IsNoAsdvise = impression.IsNoAsdvise,
                IsToTearss = impression.IsToTearss,
                IsNice = impression.IsNice,
                IsBoring = impression.IsBoring,
                IsScary = impression.IsScary,
                IsWisely = impression.IsWisely,
                IsUnclear = impression.IsUnclear,
                UserId = impression.User.Id,
                BookId = impression.Book.Id,
            };

            await _context.Impressions.AddAsync(impressionEntity);
            await _context.SaveChangesAsync();

            return impressionEntity.Id;
        }

        public async Task<Guid> Update(Guid id, UpdateImpressionDto impression)
        {
            await _context.Impressions
                .Where(i => i.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(i => i.Text, i => impression.Text));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Impressions.Where(i => i.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
