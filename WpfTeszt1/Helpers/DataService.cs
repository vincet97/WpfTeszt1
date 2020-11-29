using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfTeszt1.Models;

namespace WpfTeszt1.Helpers
{
    class DataService
    {

        public static Profile loadData(string path)
        {
            string jsonString = File.ReadAllText(path);
            Profile _loadedProfile = JsonSerializer.Deserialize<Profile>(jsonString);
            return _loadedProfile;
        }
        public static ObservableCollection<Shortcut> updateScList(Profile p)
        {
            ObservableCollection<Shortcut> temp = new ObservableCollection<Shortcut>();
            foreach (var sc in p.ShortCuts)
            {
                temp.Add(sc);
            }
            return temp;
        }
    }
}
