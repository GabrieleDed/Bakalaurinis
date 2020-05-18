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
        
        public NoteCompletedPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //listView.ItemsSource = await App.Database.GetNotesAsync();
            listView.ItemsSource = await App.Database.GetNotesCompletedAsync();
            //listViewNotCompleted.ItemsSource = await App.Database.GetNotesNotCompletedAsync();
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