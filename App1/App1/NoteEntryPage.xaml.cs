using System;
using System.IO;
using Xamarin.Forms;
using App1.Models;
using System.ComponentModel;

namespace App1
{
    public partial class NoteEntryPage : ContentPage
    {
        Note note = new Note();
        User user = new User();
        public NoteEntryPage()
        {
            InitializeComponent();
            categoryPicker.Items.Add("Vanduo");
            categoryPicker.Items.Add("Elektra");
            categoryPicker.Items.Add("Rūšiavimas");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            user = await App.User_Database.GetUserAsync(1);
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            AddExpToUser(note.CompleteStatus, note.Category);
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
                await App.User_Database.SaveUserAsync(user);
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            note.Category = categoryPicker.Items[categoryPicker.SelectedIndex];
        }

    }
}