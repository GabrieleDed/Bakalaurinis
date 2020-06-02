using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class NoteView
    {
        public int TaskId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool CompleteStatus { get; set; }
        public int CompleteTimes { get; set; }
        public string CategoryName { get; set; }
        public string DifficultyName { get; set; }
        public string TaskReUseTime { get; set; }
    }
}
