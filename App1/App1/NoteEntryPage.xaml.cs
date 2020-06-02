using System;
using Xamarin.Forms;
using App1.Models;
using System.Collections.Generic;
using System.Linq;

namespace App1
{
    public partial class NoteEntryPage : ContentPage
    {
        // Apibrežiami kintamieji pagal modelius
        Note task = new Note();
        User user = new User();
        List<Category> categories = new List<Category>();
        List<Difficulty> difficulties = new List<Difficulty>();
        List<TaskReUse> taskReUses = new List<TaskReUse>();
        List<Quest> quests = new List<Quest>();
        Boolean initialCompleteStatus;
        public NoteEntryPage()
        {
            // Užkraunamas komponentas
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            // Metodo iškvietimas, pakeistas į async, kad būtų galima iš eilės vykdyti kodą
            base.OnAppearing();

            // Gaunami duomenys iš serviso/DB
            categories = await App.Database.GetCategoriesAsync();
            difficulties = await App.Database.GetDifficulitiesAsync();
            taskReUses = await App.Database.GetTaskReUsesAsync();
            quests = await App.Database.GetQuestsAsync();

            // Užpildomi pickers duomenimis
            categoryPicker.ItemsSource = categories;
            difficultyPicker.ItemsSource = difficulties;
            taskReUsePicker.ItemsSource = taskReUses;

            // Nustatomos picker pradinės reikšmės
            categoryPicker.SelectedIndex = 0;
            difficultyPicker.SelectedIndex = 0;
            taskReUsePicker.SelectedIndex = 0;

            // Gaunamas vartotojas
            user = await App.Database.GetUserAsync(1);

            // Jeigu atkeliauja Note duomenys iš kito page, tada vykdomi šie metodai
            if (BindingContext != null)
            {
                // Priskiriami visi task duomenys atkeliave iš kito puslapio
                task = (Note)BindingContext;
                initialCompleteStatus = task.CompleteStatus;

                // Užpildomi picker task duomenimis (-1 nes prasideda nuo 0, DB nuo 1)
                categoryPicker.SelectedIndex = (task.CategoryId - 1);
                difficultyPicker.SelectedIndex = (task.DifficultyId - 1);
                taskReUsePicker.SelectedIndex = (task.ReUseId - 1);
            }
        }

        // Metodas, kai paspaudžiamas Išsaugoti mygtukas
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Užpildomi duomenys iš xaml failo pagal x:Name
            task.Text = textEditor.Text;
            task.Description = descriptionEditor.Text;
            task.CompleteStatus = statusBox.IsChecked;
            // Užpildomi duomenys pagal default
            task.Date = DateTime.UtcNow;
            if (BindingContext != null)
            {
                task.CompleteTimes++;
            } else
            {
                task.CompleteTimes = 0;
            }
            task.TerminationStatus = false;

            quests = quests.Where(q => q.CategoryId == task.CategoryId).ToList();

            // Iškviečiamas metodas pridėti exp pagal category
            if (initialCompleteStatus != true)
            {
                AddExpToUser(task.CompleteStatus, task.CategoryId, task.DifficultyId);
            }

            // Išsaugojamas task
            await App.Database.SaveNoteAsync(task);

            // Grįžtą į buvusį puslapį
            await Navigation.PopAsync();
        }

        // Metodas, kai paspaudžiamas mygtukas Pašalinti
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // Gaunami task duomenys iš praeito page
            task = (Note)BindingContext;

            // Ištrinamas note pagal pateiką modelį
            await App.Database.DeleteNoteAsync(task);

            // Grįžtą į buvusį puslapį
            await Navigation.PopAsync();
        }

        // Priskirama reikšmė pagal checkbox būseną
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

        // Pridedami EXP pagal gautą kategoriją
        async void AddExpToUser(bool Status, int CategoryId, int DifficultyId)
        {
            if (Status)
            {
                user.EXP += (categories[CategoryId - 1].CategoryExp * difficulties[DifficultyId - 1].DifficultyId);

                foreach (var q in quests)
                {
                    q.Times--;
                    if (q.Times == 0)
                    {
                        user.EXP += q.ExpBonus;
                        q.CompleteTimes++;
                        if (q.QuestId <= 3)
                        {
                            q.Times = 1;
                        } else if (q.QuestId > 3 && q.QuestId <= 6)
                        {
                            q.Times = 2;
                        } else if (q.QuestId > 6 && q.QuestId <= 9)
                        {
                            q.Times = 3;
                        }
                    }
                    await App.Database.SaveQuestAsync(q);
                }

                if (user.EXP >= 100)
                {
                    user.Level += 1;
                    user.EXP -= 100;
                }

                // Išsaugojami user pakeitimai
                await App.Database.SaveUserAsync(user);
            }
        }

        // picker metodas, kai pakeičia reikšmę, kad kartu pakeistų ir pačiame task
        void categoryPicker_OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = categoryPicker.SelectedIndex;
            if (selectedIndex != -1)
            {
                task.CategoryId = categories[selectedIndex].CategoryId;
            }
        }

        // picker metodas, kai pakeičia reikšmę, kad kartu pakeistų ir pačiame task
        void difficultyPicker_OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = difficultyPicker.SelectedIndex;
            if (selectedIndex != -1)
            {
                task.DifficultyId = difficulties[selectedIndex].DifficultyId;
            }
        }

        // picker metodas, kai pakeičia reikšmę, kad kartu pakeistų ir pačiame task
        void taskReUsePicker_OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = taskReUsePicker.SelectedIndex;
            if (selectedIndex != -1)
            {
                task.ReUseId = taskReUses[selectedIndex].ReUseId;
            }
        }

    }
}