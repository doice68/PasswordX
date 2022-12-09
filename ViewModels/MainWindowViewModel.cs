using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using System.Text.Json;
using System.IO;
using Avalonia.Controls;
//using MessageBox;
//using MessageBox.Avalonia;

namespace AvaloniaApplication21.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel instance;
        public MainWindowViewModel() 
        {
            instance = this;
            if (Design.IsDesignMode) return;

            try
            {
                var savedJson = File.ReadAllText("save.json");
                passwords = JsonSerializer.Deserialize<ObservableCollection<PasswordItem>>(savedJson)!;
            }
            catch (Exception)
            {
                //im the best programmer
            }
        }

        bool _isSaved = true;
        public bool isSaved 
        {
            get => _isSaved;
            set => this.RaiseAndSetIfChanged(ref _isSaved, value);
        }

        string _name = "";
        string name 
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        string _password = "";
        string password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }
        //string _searchText = "";
        //string searchText 
        //{
        //    get => _searchText;
        //    set 
        //    {
        //        this.RaiseAndSetIfChanged(ref _searchText, value);
        //    }
        //}

        ObservableCollection<PasswordItem> _passwords = new ObservableCollection<PasswordItem>();
        public ObservableCollection<PasswordItem> passwords 
        {
            get => _passwords;
            set => this.RaiseAndSetIfChanged(ref _passwords, value);
        }

        void Add() 
        {
            passwords.Add(new PasswordItem(name, password, this));
            name = "";
            password = "";
            isSaved = false;
        }
        void Save() 
        {
            var jsonText = JsonSerializer.Serialize(passwords);
            File.WriteAllText("save.json", jsonText);
            isSaved = true;
        }
        void RandomPassword()
        {
            password = GeneratePassword();
        }
        string GeneratePassword() 
        {
            var res = "";
            for (int i = 0; i < 8; i++)
            {
                res += (char)Random.Shared.Next('a', 'z');
            }
            return res;
        }
    }
}
