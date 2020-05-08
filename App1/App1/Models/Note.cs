using System;
using SQLite;

namespace App1.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool CompleteStatus { get; set; }
    }
}
