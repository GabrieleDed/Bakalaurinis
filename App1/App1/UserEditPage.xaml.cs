using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Models;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEditPage : ContentPage
    {
        public UserEditPage()
        {
            InitializeComponent();
        }
        async void OnUserSaveButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            if (user == null)
            {
                user.EXP = 0;
                user.Level = 0;
            }
            await App.Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }
    }
}