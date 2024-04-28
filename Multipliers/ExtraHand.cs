using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace LlamaClicker.Multipliers
{
    [Serializable()]
    class ExtraHand
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

        public ExtraHand()
        {
            level = 0;
            bonus = 2;
            timeInterval = 1;
            Timer(timeInterval);
            cost = 10 + (int)(Math.Pow(level, 2));
            description = "Use an extra hand to pet the llama.";
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
            cost = 10 + (int)(Math.Pow(level, 2));
            totalClicked += (level * bonus);
        }

    }
}
