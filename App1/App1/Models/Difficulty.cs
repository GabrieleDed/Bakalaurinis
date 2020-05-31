using SQLite;

namespace App1.Models
{
    [Table("Difficulty")]
    public class Difficulty
    {
        [PrimaryKey, AutoIncrement, Column("DifficultyId")]
        public int DifficultyId { get; set; }
        [MaxLength(250), Column("DifficultyName")]
        public string DifficultyName { get; set; }
        [Column("ExpMultiply")]
        public int ExpMultiply { get; set; }
    }
}
