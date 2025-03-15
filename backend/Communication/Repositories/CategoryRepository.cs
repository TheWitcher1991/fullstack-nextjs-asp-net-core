using AutoMapper;
using backend.Domain;
using backend.Domain.Abstractions;
using backend.Domain.Entities;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Communication.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Category>> List()
        {
            var categoryEntities = await _context.Categories.AsNoTracking().ToListAsync();

            var categories = categoryEntities.Select(c => Category.Create(
                c.Id,
                c.Title,
                _mapper.Map<Topic>(c.Topic)))
                .ToList();

            return categories;
        }

        public async Task<List<Category>> GetByIds(List<Guid> ids)
        {
            var categoryEntities = await _context.Categories
                .AsNoTracking()
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();

            return categoryEntities.Select(c => Category.Create(c.Id, c.Title, _mapper.Map<Topic>(c.Topic))).ToList();
        }

        public async Task<Category> GetById(Guid id)
        {
            var c = await _context.Categories
                .AsNoTracking()
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    Topic = c.Topic != null ? new TopicEntity { Id = c.Topic.Id, Title = c.Topic.Title, CreatedAt = c.Topic.CreatedAt } : null
                })
                .FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return Category.Create(c.Id, c.Title, _mapper.Map<Topic>(c.Topic));
        }

        public async Task<Guid> Create(Category category)
        {
            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Title = category.Title,
                TopicId = category.TopicId,
            };

            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();

            return categoryEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Categories.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
