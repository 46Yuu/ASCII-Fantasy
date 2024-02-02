using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    
    public class Gear
    {
        GearPiece[] pieces = new GearPiece[5];
        GearPiece? head { get; set; } = null;
        GearPiece? chest { get; set; } = null;
        GearPiece? legs { get; set; } = null;
        GearPiece? feet { get; set; } = null;
        GearPiece? weapon { get; set; } = null;

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
