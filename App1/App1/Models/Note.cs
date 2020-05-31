using System;
using SQLite;

namespace App1.Models
{
    [Table("Task")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("TaskId")]
        public int TaskId { get; set; }
        [MaxLength(250), Column("Text")]
        public string Text { get; set; }
        [MaxLength(250), Column("Description")]
        public string Description { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("CompleteStatus")]
        public bool CompleteStatus { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("TerminationStatus")]
        public bool TerminationStatus { get; set; }
        [Column("DifficultyId")]
        public int DifficultyId { get; set; }
        [Column("ReUseId")]
        public int ReUseId { get; set; }
        [Column("CompleteTimes")]
        public int CompleteTimes { get; set; }
    }
}
