using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class NoteCompletedPage : ContentPage
    {
        List<Note> tasks = new List<Note>();
        public NoteCompletedPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            tasks = await App.Database.GetNotesCompletedAsync();
            listView.ItemsSource = tasks;
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}