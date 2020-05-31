using SQLite;

namespace App1.Models
{
    [Table("Title")]
    public class Title
    {
        [PrimaryKey, AutoIncrement, Column("TitleId")]
        public int TitleId { get; set; }
        [Column("Level")]
        public int Level { get; set; }
        [MaxLength(250), Column("TitleName")]
        public string TitleName { get; set; }
    }
}
