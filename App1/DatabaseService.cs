using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;

namespace App1
{
    public class DatabaseService
    {
        SQLiteConnection db;

        public DatabaseService()
        {

        }

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydatabase.db3");
            db = new SQLiteConnection(dbPath);
        }

        public void CreateTableWithData()
        {
            db.CreateTable<SocialPost>();
            if (db.Table<SocialPost>().Count() == 0)
            {
                var newPost = new SocialPost();
            }
        }

        public TableQuery<SocialPost> GetAllPosts()
        {
            var table = db.Table<SocialPost>();
            return table;
        }
    }
}