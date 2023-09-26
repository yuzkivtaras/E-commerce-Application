using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbSet.Include(p => p.Category).AsNoTracking().ToList();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _dbSet.Include(p => p.Category).AsNoTracking().Where(predicate).ToList();
        }

        public Product GetById(int id)
        {
            return _dbSet.Include(p => p.Category).AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Product entity)
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
