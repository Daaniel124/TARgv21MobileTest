using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        TableView table;
        SwitchCell sc, sc2;
        ImageCell ic;
        TableSection foto, num;
        public TablePage()
        {
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;

            sc2 = new SwitchCell { Text = "Hellista" };
            sc2.OnChanged += Sc2_OnChanged;

            num = new TableSection();

            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("cat.jpg"),
                Text = "Foto nimetus",
                Detail = "Kirjeldus"
            };
            foto = new TableSection();


            table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisetamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        new EntryCell
                        {
                            Label= "Nimi:",
                            Placeholder = "Sisesta nimi",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        new EntryCell
                        {
                            Label= "Telefon:",
                            Placeholder = "Sisesta oma telefon number",
                            Keyboard = Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label= "Email:",
                            Placeholder = "Sisesta email",
                            Keyboard = Keyboard.Email
                        },
                        sc,
                        sc2
                    },
                    foto
                }
            };
            Content = table;
            
        }

        private void Sc2_OnChanged(object sender, ToggledEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                foto.Title = "Foto";
                foto.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                foto.Title = "";
                foto.Remove(ic);
                sc.Text = "Näita";
            }
        }
        
    }
}