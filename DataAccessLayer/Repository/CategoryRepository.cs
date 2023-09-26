using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DataAccessLayer.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbSet.Include(c => c.Products).AsNoTracking().ToList();
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return _dbSet.Include(c => c.Products).AsNoTracking().Where(predicate).ToList();
        }

        public Category GetById(int id)
        {
            return _dbSet.Include(c => c.Products).AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void Add(Category entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Category entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
