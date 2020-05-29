using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    [Table("Statistics")]
    public class Statistics
    {
        [PrimaryKey, AutoIncrement, Column("StatId")]
        public int StatId { get; set; }
        [Column("Day")]
        public DateTime Day { get; set; }
        [Column("Terminated")]
        public int Terminated { get; set; }
        [Column("Created")]
        public int Created { get; set; }
        [Column("Completed")]
        public int Completed { get; set; }
    }
}
