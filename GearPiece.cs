using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    class GearPiece
    {
        public static GearPiece instance;
        public enum GearType
        {
            Tete,
            Torse,
            Jambe,
            Pieds,
            Arme
        }
        public GearType type;

        public int bonusHealth { get; set; }
        public int bonusMana { get; set; }
        public int bonusAttack { get; set; }
        public int bonusDefense { get; set; }
        public int bonusIntelligence { get; set; }
        public int bonusAgility { get; set; }
        public int bonusLuck { get; set; }


        public GearPiece CreateNewGear(GearType type, int _bonusHealth = 0, int _bonusMana = 0, int _bonusAttack = 0, int _bonusDefense = 0, int _bonusIntellingence = 0, int _bonusAgility = 0, int _bonusLuck = 0)
        {
            this.type = type;
            this.bonusHealth = _bonusHealth;
            this.bonusMana = _bonusMana;
            this.bonusAttack = _bonusAttack;
            this.bonusDefense = _bonusDefense;
            this.bonusIntelligence = _bonusIntellingence;
            this.bonusAgility = _bonusAgility;
            this.bonusLuck = _bonusLuck;

            return this;
        }

        public static GearPiece CreateInstance()
        {
            if(instance == null)
            {
                instance = new GearPiece();
            }
            return instance;
        }

    }
}
