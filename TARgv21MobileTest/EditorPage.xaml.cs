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
    public partial class EditorPage : ContentPage
    {
        Editor editor;
        Button return_btn;
        Label lbl;
        public EditorPage()
        {
            //Текстовое поле
            editor = new Editor
            {
                TextColor = Color.White,
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.Gray
            };

            //Инициализация label
            editor.TextChanged += Editor_TextChanged;
            lbl = new Label
            {
                Text = "...",
                TextColor = Color.White,
                BackgroundColor = Color.Gray
            };

            //Инициализация кнопки
            return_btn = new Button { Text = "Tagasi" };
            return_btn.Clicked += Return_btn_Clicked;

            StackLayout stack = new StackLayout
            {
                Children = { editor, lbl, return_btn }
            };
            stack.BackgroundColor = Color.White;
            Content = stack;
        }

        int i = 0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbl.Text = editor.Text;
            editor.TextChanged -= Editor_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key == 'A' || key == 'a')
            {
                i++;
                lbl.Text = key.ToString() + ": " + i;
            }
            editor.TextChanged += Editor_TextChanged;
        }

        private async void Return_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}