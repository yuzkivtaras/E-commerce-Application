using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Customer>();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public Customer GetById(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Customer entity)
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
