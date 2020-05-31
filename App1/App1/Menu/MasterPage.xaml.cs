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
            items.Add(new MasterMenuItem("Vartotojo puslapis", "User2.png", Color.Transparent, typeof(UserPage)));
            items.Add(new MasterMenuItem("Neatliktos užduotys", "AddTask2.png", Color.Transparent, typeof(NotesPage)));
            items.Add(new MasterMenuItem("Atliktos užduotys", "CompleteTask2.png", Color.Transparent, typeof(NoteCompletedPage)));
            items.Add(new MasterMenuItem("Papildomos užduotys", "Award2.png", Color.Transparent, typeof(QuestPage)));
            items.Add(new MasterMenuItem("Statistika", "Statistics2.png", Color.Transparent, typeof(StatisticsPage)));
            
            ListView.ItemsSource = items;
        }
    }
}