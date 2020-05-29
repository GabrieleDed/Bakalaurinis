using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Data
{
    public class Database
    {
        // Create a SQLiteAsyncConnection property to be accessed 
        // publicly thru your App.
        public SQLiteAsyncConnection DBInstance { get; set; }

        public Database(String databasePath)
        {
            DBInstance = new SQLiteAsyncConnection(databasePath);

        }


        private async Task<string> GetDatabaseFilePath()
        {
            return await DependencyService.Get<IPathFinder>().GetDBPath();
        }
    }
}
