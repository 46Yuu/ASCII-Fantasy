using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    
    public class Gear
    {
       public  List<GearPiece> pieces = new List<GearPiece>();
        public GearPiece? head { get; set; } = null;
        public GearPiece? chest { get; set; } = null;
        public GearPiece? legs { get; set; } = null;
        public GearPiece? feet { get; set; } = null;
        public GearPiece? weapon { get; set; } = null;

        public Gear()
        {
            GearPiece test1 = new GearPiece(GearPiece.GearType.Tete,"test", 0, 0, 0, 0, 0, 0, 0);
            GearPiece test2 = new GearPiece(GearPiece.GearType.Pieds,"test", 0, 0, 0, 0, 0, 0, 0);
            GearPiece test3 = new GearPiece(GearPiece.GearType.Torse,"test", 0, 0, 0, 0, 0, 0, 0);
            GearPiece test4 = new GearPiece(GearPiece.GearType.Arme,"test", 0, 0, 0, 0, 0, 0, 0);
            GearPiece test5 = new GearPiece(GearPiece.GearType.Jambe,"test", 0, 0, 0, 0, 0, 0, 0);
            pieces.Add(test1);
            pieces.Add(test2);
            pieces.Add(test3);
            pieces.Add(test4);
            pieces.Add(test5);
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
