using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeszt1.Models;
using WpfTeszt1.ViewModels;
using WpfTeszt1.Helpers;
using System.Collections.ObjectModel;

namespace WpfTeszt1.ViewModels
{
    public class MainWindowViewModel : MyNotifyPropertyChanged
    {

        public RelayCommand UpdateCommand { get; set; }

        public ObservableCollection<Shortcut> _scList;
        public ObservableCollection<Shortcut> ScList
        {
            get { return _scList; }
            set
            {
                _scList = value;
                NotifyPropertyChanged();
            }
        }
        public Profile _loadedProfile;
        public Profile LoadedProfile
        {
            get { return _loadedProfile; }
            set
            {
                _loadedProfile = value;
                NotifyPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            UpdateCommand = new RelayCommand(UpdateShortcut);
            _loadedProfile = new Profile();
            _loadedProfile.Name = "First";
            _scList = new ObservableCollection<Shortcut>();
            Shortcut c1 = new Shortcut()
            {
                Text = "Csami okos",
                Combo = "A",
                Modifier1 = "Alt",
                Modifier2 = "Shift",
                Speed = "2",
                IsActive = false
            };
            Shortcut c2 = new Shortcut()
            {
                Text = "Csami okosabb",
                Combo = "B",
                Modifier1 = "Alt",
                Modifier2 = "Ctr",
                Speed = "4",
                IsActive = true
            };
            Shortcut c3 = new Shortcut()
            {
                Text = "Csami okosabbika",
                Combo = "C",
                Modifier1 = "Alt",
                Modifier2 = "Shift",
                Speed = "0",
                IsActive = false
            };
            ScList.Add(c1);
            ScList.Add(c2);
            ScList.Add(c3);


        }
        public override String ToString()
        {
            String str = "Shorcutok Listája:\n";
            foreach (var item in ScList)
                str += item.ToString();
            return str;
            
        }




        public async Task LoadDataAsync()
        {

        }
        public void UpdateShortcut(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Updated");
        }

    }
}
