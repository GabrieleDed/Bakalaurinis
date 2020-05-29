using System;
using SQLite;

namespace App1.Models
{
    [Table("Task")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("TaskId")]
        public int ID { get; set; }
        [MaxLength(250), Column("Name")]
        public string Text { get; set; }
        [MaxLength(250), Column("Description")]
        public string Description { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("CompleteStatus")]
        public bool CompleteStatus { get; set; }
        [Column("Exp")]
        public int Exp { get; set; }
        [Column("Level")]
        public int Level { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("CompleteTimes")]
        public int CompleteTimes { get; set; }
    }
}
