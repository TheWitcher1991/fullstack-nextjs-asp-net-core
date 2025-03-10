using AutoMapper;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
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

            var categories = categoryEntities.Select(b => Category.Create(b.Id, b.Title)).ToList();

            return categories;
        }

        public async Task<Category> GetById(Guid id)
        {
            var categoryEntity = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return _mapper.Map<Category>(categoryEntity);
        }

        public async Task<Guid> Create(Category category)
        {
            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Title = category.Title,
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
