using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaClicker.Models
{
    [Serializable()]
    class Game
    {
        public List<Achievement> achieved { get; set; } = new List<Achievement>();
        public List<object> multipliers { get; set; } = new List<object>();
        public int CurrentPetCount
        {
            get;
            set;
        }
        public int TotalPetCount
        {
            get;
            set;
        }
        // private List<Modifier> modifiers = new List<Modifier>();
        // public List<Modifier> Modifiers
        // {
        //     get { return modifiers; }
        //     set { modifiers = value; }
        // }

        public void CheckAchievements()
        {
            for (int i = 0; i < AchievementArchive.Achievements.Count; i++)
            {
                if (i == 0)
                {
                    if (TotalPetCount >= 1) achieved.Add(AchievementArchive.Achievements[i]);
                }
                else
                {
                    if (TotalPetCount >= Math.Pow(10, Math.Floor(i * 1.5 + 2))) achieved.Add(AchievementArchive.Achievements[i]);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Achieved=");
            foreach (Achievement a in achieved)
            {
                sb.Append($"{a.Title},");
            }
            sb.Append($"\nCurrentPetCount={CurrentPetCount}\nTotalPetCount={TotalPetCount}");
            return sb.ToString();
        }
    }
}
