using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfTeszt1.Models
{
    public class Profile
    {


        public string Path { get; set; }
        public ICollection<Shortcut> ShortCuts { get; set; }

        public String Name { get; set; }

        

        

    }
}
