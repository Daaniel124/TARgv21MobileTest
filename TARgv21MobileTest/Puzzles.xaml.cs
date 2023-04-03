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
        int answersTrue;
        int answers;

        [Obsolete]
        public Puzzles()
        {
            Label lbl = new Label
            {
                Text = "Примеры",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label))
            };

            Button alertButton = new Button
            {
                Text = "Начать",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertButton.Clicked += AlertButton_Clicked;

            Content = new StackLayout { Children = { lbl, alertButton } };
        }

        [Obsolete]
        private async void AlertButton_Clicked(object sender, EventArgs e)
        {
            answers = 0;
            answersTrue = 0;
            bool result = await DisplayAlert("Примеры", "Вам будет предложено решить 10 примеров. Хотите начать?", "Да", "Нет");
            if (result == true)
            {
                Random rd = new Random();
                int i;
                for (i = 1; i < 11;)
                {
                    int rand_num_1 = rd.Next(0, 10);
                    int rand_num_2 = rd.Next(0, 10);
                    string userResult = await DisplayPromptAsync("Вопрос #" + (i), rand_num_1 + " * " + rand_num_2 + " = ?", "Ответить", "Выйти", "Ответ", maxLength: 3, keyboard: Keyboard.Numeric);
                    int randResult = rand_num_1 * rand_num_2;
                    int userResultInt = int.Parse(userResult);
                    bool resultAnswer;
                    if (randResult == userResultInt)
                    {
                        resultAnswer = await DisplayAlert("Вопрос #" + (i), "Ответ правильный", "Продолжить", "Выйти");
                        answersTrue++;
                        answers++;
                    }
                    else
                    {
                        resultAnswer = await DisplayAlert("Вопрос #" + (i), "Ответ не правильный", "Продолжить", "Выйти");
                        answers++;
                    }
                    if (resultAnswer == true)
                    {
                        i++;
                    }
                    else
                    {
                        i = 11;
                    }
                   
                }
                _ = DisplayAlert("Примеры", "Вы ответили правильно на " + answersTrue + " пример/ов из " + answers, "Ок");
            }
        }

        private void AlertQuestionButton_Clicked(object sender, EventArgs e)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, 10);

        }
    }
}