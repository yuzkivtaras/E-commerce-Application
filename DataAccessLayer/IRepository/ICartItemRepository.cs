﻿using DataAccessLayer.Entities;

namespace DataAccessLayer.IRepository
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        IEnumerable<CartItem> GetAllCartItems();
    }
}
