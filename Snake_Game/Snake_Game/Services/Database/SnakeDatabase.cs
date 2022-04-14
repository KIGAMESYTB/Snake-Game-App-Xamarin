using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

using Snake_Game.Models;
using System.Threading.Tasks;

namespace Snake_Game.Services.Database
{
    public class SnakeDatabase
    {
        readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPath">path database</param>
        public SnakeDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Music>().Wait();
            _database.CreateTableAsync<Display>().Wait();
        }


        /*//////////////////////////////////
                DATABASE TABLE MUSIC 
        //////////////////////////////////*/

        /// <summary>
        /// Get list table Music async
        /// </summary>
        /// <returns>List Music</returns>
        public Task<List<Music>> GetMusicAsync()
        {
            return _database.Table<Music>().ToListAsync();
        }

        /// <summary>
        /// Get Music with variable id
        /// </summary>
        /// <param name="id">id Music</param>
        /// <returns>Music</returns>
        public Task<Music> GetMusicAsync(int id)
        {
            return _database.Table<Music>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Update or Insert Music
        /// </summary>
        /// <param name="music">Music</param>
        /// <returns></returns>
        public Task<int> SaveMusicAsync(Music music)
        {
            if (music.Id != 0)
                return _database.UpdateAsync(music);
            else
            {
                return _database.InsertAsync(music);
            }
        }

        /// <summary>
        /// Delete Music
        /// </summary>
        /// <param name="music">Music</param>
        /// <returns></returns>
        public Task<int> DeleteMusiclAsync(Music music)
        {
            return _database.DeleteAsync(music);
        }


        /*//////////////////////////////////
                DATABASE TABLE DISPLAY 
        //////////////////////////////////*/

        /// <summary>
        /// Get list table Display async
        /// </summary>
        /// <returns>List Display</returns>
        public Task<List<Display>> GetDisplayAsync()
        {
            return _database.Table<Display>().ToListAsync();
        }

        /// <summary>
        /// Get Display with variable id
        /// </summary>
        /// <param name="id">id Display</param>
        /// <returns>Display</returns>
        public Task<Display> GetDisplayAsync(int id)
        {
            return _database.Table<Display>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Update or Insert Display
        /// </summary>
        /// <param name="display">Display</param>
        /// <returns></returns>
        public Task<int> SaveDisplayAsync(Display display)
        {
            if (display.Id != 0)
                return _database.UpdateAsync(display);
            else
            {
                return _database.InsertAsync(display);
            }
        }

        /// <summary>
        /// Delete Display
        /// </summary>
        /// <param name="display">Display</param>
        /// <returns></returns>
        public Task<int> DeleteDisplaylAsync(Display display)
        {
            return _database.DeleteAsync(display);
        }
    }
}
