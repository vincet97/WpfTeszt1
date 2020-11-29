using System;
using System.Timers;
using System.Windows.Forms;

namespace WpfTeszt1.Models
{
    public class Timer
    {
        private static System.Timers.Timer aTimer;
        String text;
        int interval;
        int index;
        bool paste;

        public Timer(String t, int i, bool p)
        {
            this.text = t;
            this.interval = i;
            this.paste = p;
            index = 0;


        }


        public void setIndex(int i)
        {
            this.index = 0;
        }
        public void SetTimer(int time , string t)
        {
            if (aTimer != null)
            {
                aTimer.Dispose();
            }
            interval = time;
            text = t;
            
            if (interval == 0)
            {
                paste = true;
            }
            else
            {
                paste = false;
            }
            // Create a timer with the selected interval.
            if (paste)
            {
                aTimer = new System.Timers.Timer(200);
            }
            else
            {
                aTimer = new System.Timers.Timer(interval * 100);
            }
            

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            index = 0;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {


            if (index < text.Length)
            {
                if (paste)
                {
                    SendKeys.SendWait(text);
                    index = text.Length;
                }
                else
                {
                    SendKeys.SendWait(text[index].ToString());
                    index++;
                }

            }



        }
    }
}