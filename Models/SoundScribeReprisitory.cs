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
        public List<Songs> GetSortedSongs()
        {
            var query = @"
    SELECT *,
           (Rhymes + Structure + Style_realization + Individuality) AS a,
           ((Atmosphere * 10.0 / 100.0) + (Rhymes + Structure + Style_realization + Individuality)) AS b,
           ((Trendiness * 10.0 / 100.0) + ((Atmosphere * 10.0 / 100.0) + (Rhymes + Structure + Style_realization + Individuality))) AS c
    FROM Songs
    ORDER BY c DESC";

            var result = database.Query<Songs>(query);

            // Debug: Print the result to check if sorting is correct
            foreach (var song in result)
            {
                System.Diagnostics.Debug.WriteLine($"Song: {song.Song_Name}, Score (c): {song.C}");
            }

            return result.Select(song => new Songs
            {
                Id = song.Id,
                Artist = song.Artist,
                Song_Name = song.Song_Name,
                Image = song.Image,
                Rhymes = song.Rhymes,
                Structure = song.Structure,
                Style_realization = song.Style_realization,
                Individuality = song.Individuality,
                Atmosphere = song.Atmosphere,
                Trendiness = song.Trendiness,
                C = ((song.Trendiness * 10.0 / 100.0) + ((song.Atmosphere * 10.0 / 100.0) + (song.Rhymes + song.Structure + song.Style_realization + song.Individuality)))
            }).ToList();
        }


        public List<Songs> GetBestSong()
        {
            var query = @"
        SELECT *,
               (Rhymes + Structure + Style_realization + Individuality) AS a,
               ((Atmosphere * 10.0 / 100.0) + (Rhymes + Structure + Style_realization + Individuality)) AS b,
               ((Trendiness * 10.0 / 100.0) + ((Atmosphere * 10.0 / 100.0) + (Rhymes + Structure + Style_realization + Individuality))) AS c
        FROM Songs
        ORDER BY c DESC
        Limit 1";

            var result = database.Query<Songs>(query);

            return result.Select(song => new Songs
            {
                Id = song.Id,
                Artist = song.Artist,
                Song_Name = song.Song_Name,
                Image = song.Image,
                Rhymes = song.Rhymes,
                Structure = song.Structure,
                Style_realization = song.Style_realization,
                Individuality = song.Individuality,
                Atmosphere = song.Atmosphere,
                Trendiness = song.Trendiness,
                C = ((song.Trendiness * 10.0 / 100.0) + ((song.Atmosphere * 10.0 / 100.0) + (song.Rhymes + song.Structure + song.Style_realization + song.Individuality)))
            }).ToList();
        }
        public List<Songs> GetLastSong()
        {
            var query = @"SELECT * FROM Songs
WHERE _id = (SELECT MAX(_id) FROM Songs)";

            var result = database.Query<Songs>(query);

            return result.Select(song => new Songs
            {
                Id = song.Id,
                Artist = song.Artist,
                Song_Name = song.Song_Name,
                Image = song.Image,
                Rhymes = song.Rhymes,
                Structure = song.Structure,
                Style_realization = song.Style_realization,
                Individuality = song.Individuality,
                Atmosphere = song.Atmosphere,
                Trendiness = song.Trendiness,
                C = ((song.Trendiness * 10.0 / 100.0) + ((song.Atmosphere * 10.0 / 100.0) + (song.Rhymes + song.Structure + song.Style_realization + song.Individuality)))
            }).ToList();
        }
    }
}
