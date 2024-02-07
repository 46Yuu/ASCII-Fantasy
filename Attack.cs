using ASCIIFantasy;

namespace ASCIIFantasy
{
    public enum AttackType 
    {
        Physical,
        Spell,
        Buff,
        Heal,
    }
    public enum Element
    {
        Fire,
        Water,
        Grass,
        Neutral,
    }

    public class Attack
    {
        public AttackType type { get; set; }
        protected Element element { get; set; }
        public int cost { get; set; }
        protected int power; 
        public string attack_name { get; set; }
        protected static Random rnd = new Random();

        public Attack(string _name, Element _element, int _power, int _cost)
        {
            attack_name = _name;
            element = _element;
            power = _power;
            cost = _cost;
        }

        public virtual void Use(Character attacker, Character receiver){ }

        public void IsCharacterDead(Character character)
        {
            if (character.GetStats().actual_hp <= 0)
            {
                character.GetStats().actual_hp = 0;
                character.isDead = true;
            }
        }   

        // Verifies if the attack is a critical hit.
        protected bool IsCriticalHit(int luck)
        {
            return rnd.Next(100) + 1 <= luck;
        }

        // Verifies if the receiver of the attack dodged.
        protected bool IsDodged(int agility)
        {
            return rnd.Next(100) + 1 <= agility;
        }

    }
}