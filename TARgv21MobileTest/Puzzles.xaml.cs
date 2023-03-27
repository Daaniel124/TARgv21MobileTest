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
    public partial class Puzzles : ContentPage
    {
        [Obsolete]
        public Puzzles()
        {
            Label lbl = new Label
            {
                Text = "Загадки",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            Button alertButton = new Button
            {
                Text = "Начать",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertButton.Clicked += AlertButton_Clicked;

            Button alertQuestionButton = new Button
            {
                Text = "Вопросы",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertQuestionButton.Clicked += AlertQuestionButton_Clicked;
            Content = new StackLayout { Children = { lbl, alertQuestionButton } };
        }

        [Obsolete]
        private async void AlertButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Примеры", "Вам будет предложено решить 10 примеров. Хотите начать?", "Да", "Нет");
            if (result == true)
            {
                Random rd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int rand_num_1 = rd.Next(0, 10);
                    int rand_num_2 = rd.Next(0, 10);
                    string userResult = await DisplayPromptAsync("Вопрос #" + i, rand_num_1 + " * " + rand_num_2 + " = ?", "Ответить", "Пропустить", "Ответ", maxLength: 3, keyboard: Keyboard.Numeric);
                    int randResult = rand_num_1 * rand_num_2;
                    int userResultInt = int.Parse(userResult);
                    if (randResult == userResultInt)
                    {

                    }
                }
            }
        }

        private void AlertQuestionButton_Clicked(object sender, EventArgs e)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, 10);

        }
    }
}