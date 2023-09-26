﻿using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
