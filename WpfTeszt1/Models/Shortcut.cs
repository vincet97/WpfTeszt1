using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeszt1.Helpers;

namespace WpfTeszt1.Models
{
    public partial class Shortcut : MyNotifyPropertyChanged
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

        private String modifier1;
        public string Modifier1
        {
            get { return this.modifier1; }
            set
            {
                if (value != this.modifier1)
                {
                    this.modifier1= value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        private String modifier2;
        public string Modifier2
        {
            get { return this.modifier2; }
            set
            {
                if (value != this.modifier2)
                {
                    this.modifier2 = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public IEnumerable<String> Speeds { get; set; }

        private Boolean isActive;
        public Boolean IsActive
        {
            get { return this.isActive; }
            set
            {
                if (value != this.isActive)
                {
                    this.isActive = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        private String text;
        public String Text
        {
            get { return this.text; }
            set
            {
                if (value != this.text)
                {
                    this.text = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        private String speed;
        public String Speed
        {
            get { return this.speed; }
            set
            {
                if (value != this.speed)
                {
                    this.speed = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        private String combo;
        public String Combo
        {
            get { return this.combo; }
            set
            {
                if (value != this.combo)
                {
                    this.combo= value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public override String ToString()
        {
            String str = Text;
            str += ":";
            str += Speed;
            str += ":";
            str += IsActive.ToString();
            str += ":";
            str += Modifier1;
            str += ":";
            str += Modifier2;
            str += "\n";
            return str;

        }

    }
}
