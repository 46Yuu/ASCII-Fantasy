using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    
    class Gear
    {
        Array gearList[];
        GearPiece head {  get; set; } 
        GearPiece chest { get; set; }
        GearPiece legs { get; set; }
        GearPiece feet { get; set; }
        GearPiece weapon { get; set; }

        private  Gear()
        {
            head = GearPiece.CreateInstance().CreateNewGear(GearPiece.GearType.Tete);
            chest = GearPiece.instance.CreateNewGear(GearPiece.GearType.Torse);
            legs = GearPiece.instance.CreateNewGear(GearPiece.GearType.Jambe);
            feet = GearPiece.instance.CreateNewGear(GearPiece.GearType.Pieds);
            weapon = GearPiece.instance.CreateNewGear(GearPiece.GearType.Arme);
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
