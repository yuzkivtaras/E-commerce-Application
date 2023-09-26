using System.ComponentModel.DataAnnotations;


namespace DataAccessLayer.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
