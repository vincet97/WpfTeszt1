using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeszt1.Models;
using WpfTeszt1.ViewModels;
using WpfTeszt1.Helpers;
using System.Collections.ObjectModel;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Microsoft.Win32;

namespace WpfTeszt1.ViewModels
{
    public class MainWindowViewModel : MyNotifyPropertyChanged
    {
        public RelayCommand LoadProfileCommand { get; set; }
        public RelayCommand SaveProfileCommand { get; set; }
        public RelayCommand NewProfileCommand { get; set; }
        public RelayCommand TrackingCommand { get; set; }

        private String tracking;
        public String Tracking
        {
            get
            {
                return tracking;
            }
            set
            {
                if (value != null) {
                    tracking = value;
                NotifyPropertyChanged(); 
                }
            }
        }
        public String ProfileName {
            get { return _loadedProfile.Name; }
            set
            {
                if (value != null)
                {
                    _loadedProfile.Name = value;
                    NotifyPropertyChanged();
                }
            }

        }

        public Thread t1;
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
            LoadProfileCommand= new RelayCommand(LoadProfile);
            SaveProfileCommand = new RelayCommand(SaveProfile);
            NewProfileCommand = new RelayCommand(NewProfile);
            TrackingCommand = new RelayCommand(TrackingOpt);
            Tracking = "NoTracking";

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
                IsActive = true
            };
            Shortcut c2 = new Shortcut()
            {
                Text = "Csami okosabb",
                Combo = "B",
                Modifier1 = "Alt",
                Modifier2 = "Alt",
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
 
        public void LoadProfile(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Updated");
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory=AppDomain.CurrentDomain.BaseDirectory + @"Profiles\";
            o.ShowDialog();
            String sr = o.FileName;
            System.Diagnostics.Debug.WriteLine("Updated : " + sr);

            _loadedProfile = DataService.loadData(sr);
            ScList.Clear();
            ScList = DataService.updateScList(_loadedProfile);


        }
        public void SaveProfile(object parameter)
        {

            _loadedProfile = DataService.updateProfile(_loadedProfile, ScList);
            string jsonString = JsonSerializer.Serialize(_loadedProfile);
            DataService.saveData(_loadedProfile);
        }
        public void NewProfile(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Updated");
            ScList.Clear();
            LoadedProfile = new Profile();
            NotifyPropertyChanged();
        }
        public void TrackingOpt(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Tracking");

            if (Tracking == "NoTracking")
            {
                Tracking = "Tracking";
                Hook.Pr = ScList;
                
                t1 = new Thread(Hook.Init);
                t1.IsBackground = true;
                t1.Start();

            }
            else
            {
                Tracking = "NoTracking";
                t1.Abort();

            }
        }


    }
}
