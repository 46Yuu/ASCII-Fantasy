using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class StatsCharacter
    {
        public int health { get; set; }
        public int mana{ get; set; }
        public int attack{ get; set; }
        public int defense{ get; set; }
        public int intelligence{ get; set; }
        public int agility { get; set; }
        private int speed;
        public int luck { get; set; }
        public int actual_hp { get; set; }
        public int actual_mana { get; set; }

        private Dictionary<string, int> initialStats = new Dictionary<string, int>();
        public List<int> statsList = new List<int>();

        private int gearBonusHealth;
        private int gearBonusMana;
        private int gearBonusAttack;
        private int gearBonusDefense;
        private int gearBonusIntelligence;
        private int gearBonusAgility;
        private int gearBonusLuck;




        /*private int level = 1;
        private int xp = 0;
        private int xp_needed = 100;*/

        public StatsCharacter()
        {
            health = 0;
            mana = 0;
            attack = 0;
            defense = 0;
            intelligence = 0;
            agility = 0;
            luck = 0;
            actual_hp = health;
            actual_mana = mana;
            statsList.Add(health);
            statsList.Add(mana);
            statsList.Add(attack);
            statsList.Add(defense);
            statsList.Add(intelligence);
            statsList.Add(agility);
            statsList.Add(luck);
        }

        public StatsCharacter(int health, int mana, int attack, int defense, int intelligence, int agility, int luck)
        {
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defense = defense;
            this.intelligence = intelligence;
            this.agility = agility;
            this.luck = luck;
            this.actual_hp = health;
            this.actual_mana = mana;
            statsList.Add(health);
            statsList.Add(mana);
            statsList.Add(attack);
            statsList.Add(defense);
            statsList.Add(intelligence);
            statsList.Add(agility);
            statsList.Add(luck);
        }

        public void SetStats(int health, int mana, int attack, int defense, int intelligence, int agility, int luck)
        {
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defense = defense;
            this.intelligence = intelligence;
            this.agility = agility;
            this.luck = luck;
            this.actual_hp = health;
            this.actual_mana = mana;
        }

        public void IncrementHealth(int i)
        {
            actual_hp += i;
            if (actual_hp > health) actual_hp = health;
            else if (actual_hp < 0) actual_hp = 0;
        }

        public void IncrementMana(int i)
        {
            actual_mana += i;
        }

        public void IncrementAttack(int i)
        {
            attack += i;
        }

        public void IncrementDefense(int i)
        {
            defense += i;
        }


        public void IncrementIntel(int i)
        {
            intelligence += i;
        }

        public void IncrementAgility(int i)
        {
            agility += i;
        }

        public void IncrementLuck(int i)
        {
            luck += i;
        }
 

        public int GetBonusHealth()
        {
            return gearBonusHealth;
        }

        public int GetBonusMana()
        {
            return gearBonusMana;
        }
        public int GetBonusAttack()
        {
            return gearBonusAttack;
        }
        public int GetBonusDefense()
        {
            return gearBonusDefense;
        }

        public int GetBonusIntelligence()
        {
            return gearBonusIntelligence;
        }
        public int GetBonusAgility()
        {
            return gearBonusAgility;
        }

        public int GetBonusLuck()
        {
            return gearBonusLuck;
        }

        public void SetBonusHealth(int i)
        {
            gearBonusHealth = i;
        }

        public void SetBonusMana(int i)
        {
            gearBonusMana = i;
        }
        public void SetBonusAttack(int i)
        {
            gearBonusAttack = i;
        }
        public void SetBonusDefense(int i)
        {
            gearBonusDefense = i;
        }
        public void SetBonusIntelligence(int i)
        {
            gearBonusIntelligence = i;
        }
        public void SetBonusAgility(int i)
        {
            gearBonusAgility = i;
        }
        public void SetBonusLuck(int i)
        {
            gearBonusLuck = i;
        }


        public void ShowHealth()
        {
            Console.Write(" Health: ");
            int healthPercentage = (int)((double)actual_hp / health * 100);
            int totalSegments = 20;
            int filledSegments = healthPercentage / 5;
            if (healthPercentage > 50)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (healthPercentage > 25)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < filledSegments; i++)
                Console.Write("█");
            Console.ResetColor();
            for (int i = filledSegments; i < totalSegments; i++)
                Console.Write("_");
            Console.Write(" " + actual_hp + "/" + health);
        }

        public void ShowMana()
        {
            Console.Write(" Mana: ");
            int manaPercentage = (int)((double)actual_mana / mana * 100);
            int totalSegments = 20;
            int filledSegments = manaPercentage / 5;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < filledSegments; i++)
                Console.Write("█");
            Console.ResetColor();
            for (int i = filledSegments; i < totalSegments; i++)
                Console.Write("_");
            Console.WriteLine(" " + actual_mana + "/" + mana);
        }

        public void StoreInitialStats()
        {
            initialStats["attack"] = attack;
            initialStats["defense"] = defense;
            initialStats["intelligence"] = intelligence;
            initialStats["agility"] = agility;
            initialStats["luck"] = luck;
        }

        public void RestoreInitialStats()
        {
            attack = initialStats["attack"];
            defense = initialStats["defense"];
            intelligence = initialStats["intelligence"];
            agility = initialStats["agility"];
            luck = initialStats["luck"];
        }
    }
}
