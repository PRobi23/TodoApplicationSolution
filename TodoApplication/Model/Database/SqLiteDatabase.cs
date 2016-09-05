using System;
using SQLite;
using SQLite.Net;
using System.IO;
using SQLite.Net.Interop;

namespace TodoApplication.Model.Database
{
    public class SqLiteDatabase
    {
        public static string DbPath
        {
            get
            {
                return Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
            }
        }

        private static readonly Lazy<SQLiteConnection> database
            = new Lazy<SQLiteConnection>(() => new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), DbPath));

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public static SQLiteConnection Database
        {
            get { return database.Value; }
        }

        public SqLiteDatabase()
        {
        }
    }
}