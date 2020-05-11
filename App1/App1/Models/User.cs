using System;
using SQLite;

namespace App1.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement] 
        public int UserId { get; set; }
        public string Name { get; set; }
        public int EXP { get; set; }
        public int Level { get; set; }

        public Array Notes { get; set; }
    }
}
