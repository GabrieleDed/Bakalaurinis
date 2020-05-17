using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView;  } }
        public List<MasterMenuItem> items;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItems("Vartotojo puslapis", "user.png".Color.White, typeof(UserPage)));
            items.Add(new MasterMenuItems("Neatliktos užduotys", "Tasks.png".Color.White, typeof(NotePage)));
            items.Add(new MasterMenuItems("Pridėti užduotys", "AddTask.png".Color.White, typeof(NoteEntryPage)));
            ListView.ItemsSource = items;
        }
    }
}