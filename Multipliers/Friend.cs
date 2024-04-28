using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace LlamaClicker.Multipliers
{
    [Serializable()]
    class Friend
    {
        private String description;
        public int level { get; set; } //what level it is at

        private double bonus; //how much per second it increases by

        public double totalBonus { get; set; } //level and bonus multiplied together 

        private double timeInterval; //how often it happens

        public int cost { get; set; }

        [NonSerialized()]
        private DispatcherTimer dispatcherTimer;

        public double totalClicked { get; set; } //total bonus it has helped

        public Friend()
        {
            level = 0;
            bonus = 5;
            timeInterval = 1;
            totalBonus = level * bonus;
            cost = 25 + (int)(Math.Pow(level, 3));
            Timer(timeInterval);
            description = "Here is a friend to help you pet.";
        }

        private void Timer(double timeInterval)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(timeInterval);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(Object stateInfo, object e)
        {
            totalBonus += (level * bonus);
            cost = 25 + (int)(Math.Pow(level, 2));
            totalClicked += (level * bonus);
        }

    }
}
