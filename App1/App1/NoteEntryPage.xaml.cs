using System;
using System.IO;
using Xamarin.Forms;
using App1.Models;
using System.ComponentModel;
using System.Collections.Generic;

namespace App1
{
    public partial class NoteEntryPage : ContentPage
    {
        Note note = new Note();
        User user = new User();
        List<Category> categories = new List<Category>();
        public NoteEntryPage()
        {
            InitializeComponent();
            categoryPicker.ItemsSource = categories;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            categories = await App.Database.GetCategoriesAsync();
            user = await App.Database.GetUserAsync(1);
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.CompleteTimes = 0;
            //AddExpToUser(note.CompleteStatus, note.CategoryId);
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                note.CompleteStatus = true;
                note.CompleteTimes++;
            }
            else
            {
                note.CompleteStatus = false;
            }
        }

        async void AddExpToUser(bool Status, string Category)
        {
            if (Status)
            {
                if (Category == "Vanduo")
                {
                    user.EXP += 20;
                }
                else if (Category == "Elektra")
                {
                    user.EXP += 20;
                }
                else if (Category == "Rūšiavimas")
                {
                    user.EXP += 20;
                }

                if (user.EXP >= 100)
                {
                    user.Level += 1;
                    user.EXP -= 100;
                }
                await App.Database.SaveUserAsync(user);
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            //note.CategoryId = categoryPicker.Items[categoryPicker.SelectedIndex];
        }

    }
}