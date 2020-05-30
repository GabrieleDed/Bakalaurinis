using System;
using System.IO;
using Xamarin.Forms;
using App1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using PCLStorage;

namespace App1
{
    public partial class App : Application
    {
        //static NoteDatabase database;
        //static UserDatabase userDatabase;
        public static readonly object Context;

        static DBOperations database;

        public static DBOperations Database
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        var dbName = "EIPFA.db3";

                        var sqliteFilename = "EIPFA.db3";

                        IFolder folder = FileSystem.Current.LocalStorage;

                        string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);

                        database = new DBOperations(Path.Combine(path));
                    }
                    return database;
                }
                catch (Exception ex)
                {
                    var dbName = "EIPFA.db3";

                    var sqliteFilename = "EIPFA.db3";

                    IFolder folder = FileSystem.Current.LocalStorage;

                    string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
                    System.IO.Directory.CreateDirectory(path);

                    database = new DBOperations(Path.Combine(path));
                }

                return database;
            }
        }

       /* public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public static UserDatabase User_Database
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return userDatabase;
            }
        }*/


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MasterDetail());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}