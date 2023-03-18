using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }



        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (tryLogin.Text == "admin" && tryPassword.Text == "admin")
            {
                DisplayAlert("Поздравляю!", "Вы зашли в систему", "Хорошо");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Упс.", "Такого пользователя не найдено", "Ок");
                tryLogin.Text = "";
                tryPassword.Text = "";
            }
        }
    }
}