using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundScribe.Models
{
    public class SoundScribeReprisitory
    {
        SQLiteConnection database;
        public SoundScribeReprisitory(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Songs>();
            database.CreateTable<Users>();
        }
        public IEnumerable<Songs> GetItemsSongs()
        {
            return database.Table<Songs>().ToList();
        }
        public Songs GetItemSongs(int id)
        {
            return database.Get<Songs>(id);
        }
        public int DeleteItemSongs(int id)
        {
            return database.Delete<Songs>(id);
        }
        public int SaveItemSongs(Songs item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<Users> GetItemUserss()
        {
            return database.Table<Users>().ToList();
        }
        public Users GetItemUsers(int id)
        {
            return database.Get<Users>(id);
        }
        public int DeleteItemUsers(int id)
        {
            return database.Delete<Users>(id);
        }
        public int SaveItemUsers(Users item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}