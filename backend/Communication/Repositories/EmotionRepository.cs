using AutoMapper;
using backend.Domain;
using backend.Domain.Abstractions;
using backend.Domain.Entities;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Communication.Repositories
{
    public class EmotionRepository : IEmotionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmotionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private Emotion MapToEmotion(EmotionEntity e)
        {
            return Emotion.Create(
                e.Id,
                e.Label,
                e.Name,
                e.Unicode
            );
        }

        public async Task<List<Emotion>> List()
        {
            var emotionEntities = await _context.Emotions.AsNoTracking().ToListAsync();

            var emotions = emotionEntities
                .Select(e => MapToEmotion(e))
                .ToList();

            return emotions;
        }

        public async Task<List<Emotion>> GetByIds(List<Guid> ids)
        {
            var emotionEntities = await _context.Emotions
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();

            return emotionEntities
                .Select(e => MapToEmotion(e))
                .ToList();
        }

        public async Task<List<Emotion>> GetByNames(List<string> names)
        {
            var emotionEntities = await _context.Emotions
                .Where(e => names.Contains(e.Name))
                .ToListAsync();

            return emotionEntities
                .Select(e => MapToEmotion(e))
                .ToList();
        }

        public async Task<Emotion> GetById(Guid id)
        {
            var emotionEntity = await _context.Emotions.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return _mapper.Map<Emotion>(emotionEntity);
        }

        public async Task<Guid> Create(Emotion emotion)
        {
            var emotionEntity = new EmotionEntity
            {
                Id = emotion.Id,
                Name = emotion.Name,
                Label = emotion.Label,
                Unicode = emotion.Unicode
            };

            await _context.Emotions.AddAsync(emotionEntity);
            await _context.SaveChangesAsync();

            return emotionEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Emotions.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
