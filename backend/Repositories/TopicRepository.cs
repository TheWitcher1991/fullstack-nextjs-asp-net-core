using AutoMapper;
using backend.Abstractions;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TopicRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Topic>> List()
        {
            var topicEntities = await _context.Topics.AsNoTracking().ToListAsync();

            var topics = topicEntities.Select(b => Topic.Create(b.Id, b.Title)).ToList();

            return topics;
        }

        public async Task<Topic> GetById(Guid id)
        {
            var topicEntity = await _context.Topics.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return _mapper.Map<Topic>(topicEntity);
        }

        public async Task<Guid> Create(Topic topic)
        {
            var topicEntity = new TopicEntity
            {
                Id = topic.Id,
                Title = topic.Title,
            };

            await _context.Topics.AddAsync(topicEntity);
            await _context.SaveChangesAsync();

            return topicEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Topics.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
