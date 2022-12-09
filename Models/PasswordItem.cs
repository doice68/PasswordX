using Avalonia;

namespace AvaloniaApplication21.ViewModels
{
    public class PasswordItem
    {
        string _name = "";
        public string name 
        {
            get => _name;
            set => _name = value; 
        }

        string _password = "";
        public string password
        {
            get => _password;
            set => _password = value;
        }
        public PasswordItem() { }

        public PasswordItem(string name, string password, MainWindowViewModel mainWindow)
        {
            this.name = name;
            this.password = password;
        }

        void Delete() 
        {
            MainWindowViewModel.instance.passwords.Remove(this);
            MainWindowViewModel.instance.isSaved = false;
        }
        async void Copy() 
        {
            await Application.Current!.Clipboard!.SetTextAsync(password);
        }
    }
}
