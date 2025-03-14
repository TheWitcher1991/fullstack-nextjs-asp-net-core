using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain;
using backend.Domain.Abstractions;
using backend.Domain.Entities;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Communication.Repositories
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
                _mapper.Map<User>(i.User),
                _mapper.Map<Book>(i.Book),
                _mapper.Map<List<Emotion>>(i.Emotions)
                ))
                .ToList();

            return impressions;
        }

        public async Task<List<Impression>> ListByUserId(Guid userId)
        {
            var impressionEntities = await _context.Impressions.AsNoTracking().Where(i => i.UserId == userId).ToListAsync();

            var impressions = impressionEntities.Select(i => Impression.Create(
                i.Id,
                i.Text,
                _mapper.Map<User>(i.User),
                _mapper.Map<Book>(i.Book),
                _mapper.Map<List<Emotion>>(i.Emotions)))
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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var impressionEntity = new ImpressionEntity
                    {
                        Id = impression.Id,
                        Text = impression.Text,
                        UserId = impression.User.Id,
                        BookId = impression.Book.Id,
                    };

                    foreach (var emotion in impression.Emotions)
                    {
                        var emotionEntity = new EmotionEntity
                        {
                            Id = emotion.Id,
                            Name = emotion.Name,
                            Label = emotion.Label,
                            Unicode = emotion.Unicode
                        };

                        impressionEntity.Emotions.Add(emotionEntity);
                    }

                    await _context.Impressions.AddAsync(impressionEntity);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return impressionEntity.Id;
                }
                catch
                {
                    transaction.Rollback();
                    return Guid.Empty;
                }
            }
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
