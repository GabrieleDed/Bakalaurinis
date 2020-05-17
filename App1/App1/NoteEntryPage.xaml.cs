using System;
using System.IO;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class NoteEntryPage : ContentPage
    {
        Note note = new Note();
        public NoteEntryPage()
        {
            InitializeComponent();

            categoryPicker.Items.Add("Vanduo");
            categoryPicker.Items.Add("Elektra");
            categoryPicker.Items.Add("Rūšiavimas");

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            Console.WriteLine(note.Category);
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

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            note.Category = categoryPicker.Items[categoryPicker.SelectedIndex];
        }

    }
}