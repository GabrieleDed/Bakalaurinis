﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class NotesPage : ContentPage
    {
        List<Note> tasks = new List<Note>();
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            tasks = await App.Database.GetNotesNotCompletedAsync();
            listView.ItemsSource = tasks;
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = null
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