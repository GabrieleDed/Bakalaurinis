using System;
using System.IO;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class UserPage : ContentPage
    {
        User user = new User();
        public UserPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            user = await App.User_Database.GetUserAsync(1);
            await this.expBar.ProgressTo(user.EXP / 100, 500, Easing.Linear);
            if (user != null)
            {
                userName.Text = user.Name;
                userEXP.Text = user.EXP.ToString();
                userLevel.Text = user.Level.ToString();
            }
        }
        async void OnUserSaveButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            if (user == null)
            {
                user.EXP = 0;
                user.Level = 0;
            }
            await App.User_Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }
        async void OnUserAddClicked(object sender, EventArgs e)
        {
            if (user != null)
            {
                await Navigation.PushAsync(new UserEditPage
                {
                    BindingContext = user as User
                });
            }
            else
            {
                await Navigation.PushAsync(new UserEditPage
                {
                    BindingContext = new User()
                });
            }
        }
    }
}