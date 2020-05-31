using SQLite;

namespace App1.Models
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("CategoryExp")]
        public int CategoryExp { get; set; }
        [MaxLength(250), Column("CategoryName")]
        public string CategoryName { get; set; }
    }
}
