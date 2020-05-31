﻿using SQLite;
using System;
using System.Collections.Generic;
using App1.Models;
using System.Threading.Tasks;

namespace App1.Data
{
    public class DBOperations
    {
        readonly SQLiteAsyncConnection _database;

        public DBOperations(string dbPath)
        {
            try
            {
                // Sujungiama su DB
                _database = new SQLiteAsyncConnection(dbPath);

                // Sukuriamos lentelės pagal modelius
                _database.CreateTableAsync<Category>().Wait();
                _database.CreateTableAsync<Difficulty>().Wait();
                _database.CreateTableAsync<Note>().Wait();
                _database.CreateTableAsync<Quest>().Wait();
                _database.CreateTableAsync<Statistics>().Wait();
                _database.CreateTableAsync<TaskReUse>().Wait();
                _database.CreateTableAsync<Title>().Wait();
                _database.CreateTableAsync<User>().Wait();
            }
            catch (Exception ex)
            {

            }
        }

        //Note Service
        public Task<List<Note>> GetNotesCompletedAsync()
        {
            return _database.Table<Note>()
            .Where(i => i.CompleteStatus == true)
            .ToListAsync();
        }

        public Task<List<Note>> GetNotesNotCompletedAsync()
        {
            return _database.Table<Note>()
            .Where(i => i.CompleteStatus == false)
            .ToListAsync();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.TaskId == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.TaskId != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }

        //User Service
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.UserId == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.UserId != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        //Category Service
        public Task<List<Category>> GetCategoriesAsync()
        {
            return _database.Table<Category>().ToListAsync();
        }
        public Task<Category> GetCategoryAsync(int id)
        {
            return _database.Table<Category>()
                            .Where(i => i.CategoryId == id)
                            .FirstOrDefaultAsync();
        }

        //Difficulty Service
        public Task<List<Difficulty>> GetDifficulitiesAsync()
        {
            return _database.Table<Difficulty>().ToListAsync();
        }
        public Task<Difficulty> GetDifficultyAsync(int id)
        {
            return _database.Table<Difficulty>()
                            .Where(i => i.DifficultyId == id)
                            .FirstOrDefaultAsync();
        }

        //TaskReUse Service
        public Task<List<TaskReUse>> GetTaskReUsesAsync()
        {
            return _database.Table<TaskReUse>().ToListAsync();
        }
        public Task<TaskReUse> GetTaskReUseAsync(int id)
        {
            return _database.Table<TaskReUse>()
                            .Where(i => i.ReUseId == id)
                            .FirstOrDefaultAsync();
        }
    }
}
