using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    class GearPiece
    {
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
    }
}
