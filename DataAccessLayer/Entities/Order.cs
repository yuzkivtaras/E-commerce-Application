using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
