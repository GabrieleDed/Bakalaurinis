using System;
using System.IO;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        async void OnUserSaveButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            if ( user == null)
            {
                user.EXP = 0;
                user.Level = 0;
            }
            await App.User_Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }
    }
}