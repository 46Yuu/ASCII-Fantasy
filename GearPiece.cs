using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class GearPiece
    {
        public static GearPiece instance;
        

        public string gearName { get; set; }
        public enum GearType
        {
            Head,
            Chest,
            Legs,
            Feet,
            Weapon
        }
        public GearType type;

        public int bonusHealth { get; set; }
        public int bonusMana { get; set; }
        public int bonusAttack { get; set; }
        public int bonusDefense { get; set; }
        public int bonusIntelligence { get; set; }
        public int bonusAgility { get; set; }
        public int bonusLuck { get; set; }


/*        public GearPiece(GearType type, string name, int bonusHealth = 0, int bonusMana = 0, int bonusAttack = 0, int bonusDefense = 0, int bonusIntelligence = 0, int bonusAgility = 0, int bonusLuck = 0)
        {
            this.type = type;
            this.gearName = name;
            this.bonusHealth = bonusHealth;
            this.bonusMana = bonusMana;
            this.bonusAttack = bonusAttack;
            this.bonusDefense = bonusDefense;
            this.bonusIntelligence = bonusIntelligence;
            this.bonusAgility = bonusAgility;
            this.bonusLuck = bonusLuck;
        }*/
        public GearPiece CreateNewGear(GearType type, string _name, int _bonusHealth = 0, int _bonusMana = 0, int _bonusAttack = 0, int _bonusDefense = 0, int _bonusIntelligence = 0, int _bonusAgility = 0, int _bonusLuck = 0)
        {
            this.type = type;
            this.gearName = _name;
            this.bonusHealth = _bonusHealth;
            this.bonusMana = _bonusMana;
            this.bonusAttack = _bonusAttack;
            this.bonusDefense = _bonusDefense;
            this.bonusIntelligence = _bonusIntelligence;
            this.bonusAgility = _bonusAgility;
            this.bonusLuck = _bonusLuck;

            return this;
        }

        public static GearPiece CreateInstance()
        {
            if (instance == null)
            {
                instance = new GearPiece();
            }
            return instance;
        }

    }
}
