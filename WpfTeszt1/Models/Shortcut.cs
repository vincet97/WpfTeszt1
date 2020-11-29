using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTeszt1.Models
{
    public partial class Shortcut
    {
        public Shortcut()
        {
            {
                List<String> setter = new List<String>();
                setter.Add("0");
                setter.Add("2");
                setter.Add("4");
                setter.Add("6");
                setter.Add("8");
                setter.Add("10");
                Speeds = setter;

                List<String> setter2 = new List<String>();
                setter2.Add("Ctr");
                setter2.Add("Shift");
                setter2.Add("Alt");
                Modifiers = setter2;
            }
        }


        public IEnumerable<String> Modifiers { get; set; }
        public string Modifier1 { get; set; }
        public string Modifier2 { get; set; }

        public IEnumerable<String> Speeds { get; set; }


        public Boolean IsActive { get; set; }

        public String Text { get; set; }

        public String Speed { get; set; }

        public String Combo { get; set; }

    }
}
