using SQLite;

namespace App1.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("UserId")]
        public int UserId { get; set; }
        [MaxLength(250),  Column("Name")]
        public string Name { get; set; }
        [Column("Exp")]
        public int EXP { get; set; }
        [Column("Level")]
        public int Level { get; set; }
        [Column("TitleId")]
        public int TitleId { get; set; }

    }
}
