using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listViewCompleted.ItemsSource = await App.Database.GetNotesCompletedAsync();
            //listViewNotCompleted.ItemsSource = await App.Database.GetNotesNotCompletedAsync();
        }

        async void OnUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPage
            {
                BindingContext = new User()
            });
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