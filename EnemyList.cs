using System;
using ASCIIFantasy;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class Enemy : Character
    {
        int difficultyLevel = 1;
        public Enemy() base(){}
        public void SetDifficulty(int level)
        {
            difficultyLevel = level;
        }
    }
        
    public class Slime : Enemy
    { 
        public Slime() : base()
        {
            Random rnd = new Random();
            this.name = "Slime";
            this.element = Element.Neutral;
            this.stats.hp = rnd.Next(10, 50);
            this.stats.attack = rnd.Next(1, 10);
            this.stats.defense = rnd.Next(1, 10);
            this.stats.agility = rnd.Next(1, 10);
            this.stats.luck = rnd.Next(1, 10);
        }    
    }
}
