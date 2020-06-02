using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Models;
using System.Collections;
using System.Collections.Generic;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEditPage : ContentPage
    {
        User user = new User();
        List<Title> titles = new List<Title>();
        public UserEditPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Duomenų gavimas iš DB
            user = (User)BindingContext;
            titles = await App.Database.GetTitlesByLevelAsync(user.Level);

            // Užpildomas picker duomenimis
            titlePicker.ItemsSource = titles;

            // Nustatomas picker pradinė reikšmė
            titlePicker.SelectedIndex = 0;

            // Nustatoma Picker reikšmė, kuri yra user duomenyse
            if(user != null)
            {
                titlePicker.SelectedIndex = (user.TitleId - 1);
            }
        }
        async void OnUserSaveButtonClicked(object sender, EventArgs e)
        {
            if (user == null)
            {
                user.EXP = 0;
                user.Level = 0;
            }
            await App.Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }

        // picker metodas, kai pakeičia reikšmę, kad kartu pakeistų ir pačiame user
        void titlePicker_OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = titlePicker.SelectedIndex;
            if (selectedIndex != -1)
            {
                user.TitleId = titles[selectedIndex].TitleId;
            }
        }
    }
}