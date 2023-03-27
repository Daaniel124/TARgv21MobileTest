using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpPage : ContentPage
    {
        Button alertButton, alertListButton;
        public PopUpPage()
        {
            alertButton = new Button
            {
                Text = "Info",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertButton.Clicked += AlertButton_Clicked;
            Button alertYesNoButton = new Button
            {
                Text = "Yes or No",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertYesNoButton.Clicked += AlertYesNoButton_Clicked;
            alertListButton = new Button
            {
                Text = "Choose",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertListButton.Clicked += AlertListButton_Clicked;
            Button alertQuestionButton = new Button
            {
                Text = "Question",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertQuestionButton.Clicked += AlertQuestionButton_Clicked;
            Content = new StackLayout { Children = { alertButton, alertYesNoButton, alertListButton, alertQuestionButton } };
        }

        private async void AlertQuestionButton_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Question #1", "What day is today?", "Ok", "Cancel", "Day", keyboard: Keyboard.Chat);
            string result2 = await DisplayPromptAsync("Question #2", "2 + 2 = ?", "Answer", "Cancel", "Day", initialValue: "10", maxLength: 3, keyboard: Keyboard.Numeric); ;
        }

        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("What to do?", "Exit", "Ok", "Dance", "Sing", "Paint");
            if (action == "Dance") { alertListButton.BackgroundColor = Color.Blue; } 
            if (action == "Sing") { alertListButton.BackgroundColor = Color.Green; } 
            if (action == "Paint") { alertListButton.BackgroundColor = Color.Red; }
            if (action == "Exit") { alertListButton.BackgroundColor = Color.Default; }
        }

        private async void AlertYesNoButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Question", "Are you sure?", "Yes", "No");
            await DisplayAlert("Info", "Your choice: " + (result ? "Yes" : "No"), "Ok");
        }

        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Information", "You have a new notification", "Ok");
        }
    }
}