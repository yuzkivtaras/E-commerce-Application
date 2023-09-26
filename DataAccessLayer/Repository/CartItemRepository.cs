using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<CartItem> _dbSet;

        public CartItemRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<CartItem>();
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _dbSet.Include(ci => ci.Cart)
                         .Include(ci => ci.Product)
                         .AsNoTracking().ToList();
        }

        public IEnumerable<CartItem> Find(Expression<Func<CartItem, bool>> predicate)
        {
            return _dbSet.Include(ci => ci.Cart)
                         .Include(ci => ci.Product)
                         .AsNoTracking().Where(predicate).ToList();
        }

        public CartItem GetById(int id)
        {
            return _dbSet.Include(ci => ci.Cart)
                         .Include(ci => ci.Product)
                         .AsNoTracking().FirstOrDefault(ci => ci.Id == id);
        }

        public void Add(CartItem entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CartItem entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(CartItem entity)
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
