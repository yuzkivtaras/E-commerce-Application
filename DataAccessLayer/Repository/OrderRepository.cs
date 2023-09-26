using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Order>();
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbSet.Include(o => o.Customer).AsNoTracking().ToList();
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return _dbSet.Include(o => o.Customer).AsNoTracking().Where(predicate).ToList();
        }

        public Order GetById(int id)
        {
            return _dbSet.Include(o => o.Customer).AsNoTracking().FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Order entity)
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
