using SQLite;

namespace App1.Models
{
    [Table("Quest")]
    public class Quest
    {
        [PrimaryKey, AutoIncrement, Column("QuestId")]
        public int QuestId { get; set; }
        [MaxLength(250), Column("QName")]
        public string QName { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("Times")]
        public int Times { get; set; }
        [Column("ExpBonus")]
        public int ExpBonus { get; set; }
        [Column("CompleteTimes")]
        public int CompleteTimes { get; set; }
    }
}
