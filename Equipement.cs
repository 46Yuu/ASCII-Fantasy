using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    class Gear
    {

        GearPiece head; 

        GearPiece chest;

        GearPiece legs;

        GearPiece feet;

        GearPiece weapon;

        private  Gear()
        {
            head = new GearPiece();
            chest = new GearPiece();
            legs = new GearPiece();
            feet = new GearPiece();
            weapon = new GearPiece();
        }

        public void Equip(GearPiece piece)
        {
            switch (piece.type)
            {
                case GearPiece.GearType.Tete:
                    head = piece;
                    break;
                case GearPiece.GearType.Torse:
                    chest = piece;
                    break;
                case GearPiece.GearType.Jambe:
                    legs = piece;
                    break;
                case GearPiece.GearType.Pieds:
                    feet = piece;
                    break;
                case GearPiece.GearType.Arme:
                    weapon = piece;
                    break;
                default:
                    break;
            }
        }

    }
}
