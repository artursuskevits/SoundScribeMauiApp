    using SoundScribe;
using SQLite;

    using SoundScribe.Models;
using SoundScribe.Views;
using System;
    using System.IO;

    namespace SoundScribe
    {
        public partial class App : Application
        {
            public const string DATABASE_NAME = "SoundScribe_db";
            public static SoundScribeReprisitory database;
            public static SoundScribeReprisitory Database
            {
                get
                {
                    if (database == null)
                    {
                        database = new SoundScribeReprisitory (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                    }
                    return database;
                }
            }

       

     

        public App()
            {
            MainPage = new Flyuot2();
        }
        }
    }
