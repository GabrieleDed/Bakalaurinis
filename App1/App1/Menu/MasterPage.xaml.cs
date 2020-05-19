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
        public ListView ListView { get { return listview; } }
        List<MasterMenuItem> items;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Vartotojo puslapis", "user.png", Color.White, typeof(UserPage)));
            items.Add(new MasterMenuItem("Neatliktos užduotys", "task.png", Color.White, typeof(NotesPage)));
            items.Add(new MasterMenuItem("Atliktos užduotys", "taskcompleted.png", Color.White, typeof(NoteCompletedPage)));
            ListView.ItemsSource = items;
        }
    }
}