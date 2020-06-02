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
    public partial class QuestPage : ContentPage
    {
        List<Quest> quests = new List<Quest>();
        public QuestPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            quests = await App.Database.GetQuestsAsync();

            listView.ItemsSource = quests;
        }
    }
}