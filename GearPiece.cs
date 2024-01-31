using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    class GearPiece
    {
        private enum GearType
        {
            Tete,
            Torse,
            Jambe,
            Pieds,
            Arme
        }
        private GearType type;

        private int bonusHealth { get; set; }
        private int bonusMana { get; set; }
        private int bonusAttack { get; set; }
        private int bonusDefense { get; set; }
        private int bonusIntelligence { get; set; }
        private int bonusAgility { get; set; }
        private int bonusLuck { get; set; }
    }
}
