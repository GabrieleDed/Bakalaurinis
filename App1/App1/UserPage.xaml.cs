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
            await App.User_Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }

        
        

    }
}