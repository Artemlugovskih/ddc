using Building_Materials.Command;
using Building_Materials.Core;
using Building_Materials.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Building_Materials.ViewModel
{
    public class AuthViewModel:BaseViewModel
    {
        private string _login;
        private string _password;
        private readonly AuthHelper _authHelper;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand AuthCommand { get; }

        public AuthViewModel()
        {
            AuthCommand = new DelegateCommand(Auth);

            _authHelper = new AuthHelper();

        }

        private async void Auth(object obj)
        {
            if (await _authHelper.AuthHelp(Login, Password))
            {
                MessageBox.Show("Авторизация прошла успешно");
               AppWindow appWindow = new AppWindow();
                appWindow.Show();
                foreach (Window item in App.Current.Windows)
                {
                    if (item is AuthWindow)
                    {
                        item.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Что-то пошло не так , повторите попытку позже");
            }
        }

    }
}
