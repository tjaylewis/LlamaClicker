using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaClicker.Models
{
    class AchievementArchive
    {
        private static List<Achievement> achievements = new List<Achievement>();

        public static List<Achievement> Achievements
        {
            get { return achievements; }
            set { achievements = value; }
        }

        public static void InitAchievementArchive()
        {
            achievements.Add(new Achievement("Pat", "Pet a llama 1 time in one session"));
            achievements.Add(new Achievement("Pat Pat Pat Pat", "Pet a llama 1,000 times in one session"));
            achievements.Add(new Achievement("PatPatPatPatPatPatPatPat", "Pet a llama 100,000 times in one session"));
            achievements.Add(new Achievement("Small-Time Petting Zoo", "Pet a llama 1 million times in one session"));
            achievements.Add(new Achievement("Affluent Petting Zoo", "Pet a llama 100 million times in one session"));
            achievements.Add(new Achievement("World Renowned Petting Zoo", "Pet a llama 1 billion times in one session"));
            achievements.Add(new Achievement("Cosmic Petting Zoo", "Pet a llama 100 billion times in one session"));
            achievements.Add(new Achievement("Galactic Petting Zoo", "Pet a llama 1 trillion times in one session"));
            achievements.Add(new Achievement("Universal Petting Zoo", "Pet a llama 100 trillion times in one session"));
            achievements.Add(new Achievement("Timeless Petting Zoo", "Pet a llama 1 quadrillion times in one session"));
            achievements.Add(new Achievement("Infinite Petting Zoo", "Pet a llama 100 quadrillion times in one session"));
            achievements.Add(new Achievement("Immortal Petting Zoo", "Pet a llama 1 quintillion times in one session"));
            achievements.Add(new Achievement("Don't Stop Me Now", "Pet a llama 100 quintillion times in one session"));
            achievements.Add(new Achievement("You Should Stop Now", "Pet a llama 1 sextillion times in one session"));
            achievements.Add(new Achievement("How long are you going to continue this??", "Pet a llama 100 sextillion times in one session"));
            achievements.Add(new Achievement("Don't your hands hurt by now?", "Pet a llama 1 septillion times in one session"));
            achievements.Add(new Achievement("Pat Overload", "Pet a llama 100 septillion times in one session"));
            achievements.Add(new Achievement("The Land of Pats and Wool", "Pet a llama 1 octillion times in one session"));
            achievements.Add(new Achievement("They who controls the wool controls the universe", "Pet a llama 100 octillion times in one session"));
            achievements.Add(new Achievement("Im losing creativity for these titles", "Pet a llama 1 nonillion times in one session"));
            achievements.Add(new Achievement("-Insert Achievement Title Here-", "Pet a llama 100 nonillion times in one session"));
            achievements.Add(new Achievement("We're gonna need a bigger pen", "Pet a llama 1 decillion times in one session"));
            achievements.Add(new Achievement("Im just gonna take a nap in all this wool, ill talk to you when i wake up..", "Pet a llama 100 decillion times in one session"));
            achievements.Add(new Achievement("ZzZzzZZz", "Pet a llama 1 undecillion times in one session"));
            achievements.Add(new Achievement("ZZzzzz", "Pet a llama 100 undecillion times in one session"));
            achievements.Add(new Achievement("zZz", "Pet a llama 1 duodecillion times in one session"));
            achievements.Add(new Achievement("zzzzzz", "Pet a llama 100 duodecillion times in one session"));
            achievements.Add(new Achievement("...5 more minutes...", "Pet a llama 1 tredecillion times in one session"));
            achievements.Add(new Achievement("I noticed you're almost out of Llama Food", "Pet a llama 100 tredecillion times in one session"));
            achievements.Add(new Achievement("Llama Prophet", "Pet a llama 1 quattuordecillion times in one session"));
            achievements.Add(new Achievement("Llama Herald", "Pet a llama 100 quattuordecillion times in one session"));
            achievements.Add(new Achievement("Llama Ascendant", "Pet a llama 1 quindecillion times in one session"));
            achievements.Add(new Achievement("Saint Llama", "Pet a llama 100 quindecillion times in one session"));
            achievements.Add(new Achievement("Llama Pope", "Pet a llama 1 sexdecillion times in one session"));
            achievements.Add(new Achievement("Deity of Llamas", "Pet a llama 100 sexdecillion times in one session"));
            achievements.Add(new Achievement("Llamaphile", "Pet a llama 1 septendecillion times in one session"));
        }
    }
}
