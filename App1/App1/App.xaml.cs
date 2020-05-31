using System;
using System.IO;
using Xamarin.Forms;
using App1.Data;
using PCLStorage;

namespace App1
{
    public partial class App : Application
    {
        // Apibrežiama DB
        static DBOperations database;

        // Užkraunamas DB failas iš lokacijos, arba sukuriamas
        public static DBOperations Database
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        var dbName = "EIPFAv0.db3";

                        var sqliteFilename = "EIPFAv0.db3";

                        IFolder folder = FileSystem.Current.LocalStorage;

                        string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);

                        database = new DBOperations(Path.Combine(path));
                    }
                    return database;
                }
                catch (Exception ex)
                {
                    var dbName = "EIPFAv0.db3";

                    var sqliteFilename = "EIPFAv0.db3";

                    IFolder folder = FileSystem.Current.LocalStorage;

                    string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
                    System.IO.Directory.CreateDirectory(path);

                    database = new DBOperations(Path.Combine(path));
                }

                return database;
            }
        }


        public App()
        {
            InitializeComponent();
            // Sukuriamas MasterDetail, kad veiktų navigacijos menu
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