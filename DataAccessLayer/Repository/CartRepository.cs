using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<Cart> _dbSet;
        private readonly DbSet<CartItem> _itemDbSet;

        public CartRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Cart>();
            _itemDbSet = _context.Set<CartItem>();
        }

        public IEnumerable<Cart> GetAll()
        {
            return _dbSet.Include(c => c.CartItems)
                         .ThenInclude(ci => ci.Product)
                         .AsNoTracking()
                         .ToList();
        }

        public IEnumerable<Cart> Find(Expression<Func<Cart, bool>> predicate)
        {
            return _dbSet.Include(c => c.CartItems)
                         .ThenInclude(ci => ci.Product)
                         .AsNoTracking()
                         .Where(predicate)
                         .ToList();
        }

        public Cart GetById(int id)
        {
            return _dbSet.Include(c => c.CartItems)
                         .ThenInclude(ci => ci.Product)
                         .AsNoTracking()
                         .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Cart entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Cart entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Cart entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public Cart GetCartByCustomerId(int customerId)
        {
            return _dbSet.Include(c => c.CartItems)
                         .ThenInclude(ci => ci.Product)
                         .AsNoTracking()
                         .FirstOrDefault(c => c.CustomerId == customerId);
        }

        public void AddItemToCart(CartItem cartItem)
        {
            _context.Add(cartItem);
            _context.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _context.Update(cartItem);
            _context.SaveChanges();
        }

        public CartItem GetItemById(int id)
        {
            return _itemDbSet.Include(ci => ci.Product)
                             .AsNoTracking()
                             .FirstOrDefault(ci => ci.Id == id);
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            _itemDbSet.Remove(cartItem);
            _context.SaveChanges();
        }
    }
}
