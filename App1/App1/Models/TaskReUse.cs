using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models
{
    [Table("TaskReUse")]
    public class TaskReUse
    {
        [PrimaryKey, AutoIncrement, Column("UserId")]
        public int ReUseId { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("Times")]
        public int Times { get; set; }
        [Column("PlayerLevel")]
        public int PlayerLevel { get; set; }
        [Column("ExpBonus")]
        public int ExpBonus { get; set; }
        [Column("CompletedTimes")]
        public int CompletedTimes { get; set; }
        
    }
}
