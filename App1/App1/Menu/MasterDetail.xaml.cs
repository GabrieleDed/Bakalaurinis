using App1.Menu;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            masterpage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterpage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
        protected override async void OnAppearing()
        {
            String databasePath = await Database.GetDatabaseFilePath();

            App.db = new Database(databasePath);

            var table = await App.db.DBInstance.CreateTableAsync<Category>();

            // here Category is a class that models the objects 
            // present in my pre-existent database
            List<Category> categories = new List<Category>();

            categories = await App.db.DBInstance.Table<Category>().ToListAsync();

            base.OnAppearing();
        }
    }
}