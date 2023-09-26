using System.ComponentModel.DataAnnotations;


namespace DataAccessLayer.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
