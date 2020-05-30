using System;
using System.Collections.Generic;
using System.Text;
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
