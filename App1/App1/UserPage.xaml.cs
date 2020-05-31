using System;
using Xamarin.Forms;
using App1.Models;

namespace App1
{
    public partial class UserPage : ContentPage
    {
        User user;
        public UserPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            user = await App.Database.GetUserAsync(1);
            if (user != null)
            {
                userName.Text = user.Name;
                userEXP.Text = user.EXP.ToString();
                userLevel.Text = user.Level.ToString();
                await expBar.ProgressTo(((double)user.EXP / 100), 500, Easing.Linear);
            }
            else
            {
                await expBar.ProgressTo(0, 500, Easing.Linear);
            }
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