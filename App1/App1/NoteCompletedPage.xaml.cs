using System;
using System.Collections.Generic;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class NoteCompletedPage : ContentPage
    {
        List<NoteView> tasksView = new List<NoteView>();
        public NoteCompletedPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            tasksView = await App.Database.GetNoteViewsCompletedAsync();

            listView.ItemsSource = tasksView;
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
                var note = await App.Database.GetNoteAsync(tasksView[e.SelectedItemIndex].TaskId);
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = note as Note
                });
            }
        }
    }
}