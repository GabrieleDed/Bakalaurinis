using SQLite;

namespace App1.Models
{
    [Table("TaskReUse")]
    public class TaskReUse
    {
        [PrimaryKey, AutoIncrement, Column("ReUseId")]
        public int ReUseId { get; set; }
        [Column("Time")]
        public int Time { get; set; }
        [MaxLength(250), Column("TaskReUseTime")]
        public string TaskReUseTime { get; set; }

    }
}
