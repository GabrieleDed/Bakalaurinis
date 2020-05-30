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
        Note task = new Note();
        User user = new User();
        List<Category> categories = new List<Category>();
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            categories = await App.Database.GetCategoriesAsync();
            categoryPicker.ItemsSource = categories;
            user = await App.Database.GetUserAsync(1);
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            task = (Note)BindingContext;
            task.Date = DateTime.UtcNow;
            task.CompleteTimes = 0;
            AddExpToUser(task.CompleteStatus, task.CategoryId);
            await App.Database.SaveNoteAsync(task);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            task = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(task);
            await Navigation.PopAsync();
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                task.CompleteStatus = true;
                task.CompleteTimes++;
            }
            else
            {
                task.CompleteStatus = false;
            }
        }

        async void AddExpToUser(bool Status, int CategoryId)
        {
            if (Status)
            {
                user.EXP += categories[CategoryId - 1].CategoryExp;

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
            int selectedIndex = categoryPicker.SelectedIndex;
            if (selectedIndex != -1)
            {
                task.CategoryId = categories[selectedIndex].CategoryId;
            }
        }

    }
}