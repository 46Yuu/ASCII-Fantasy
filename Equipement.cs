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

        /*public Gear()
        {
            GearPiece test4 = new GearPiece(GearPiece.GearType.Weapon,"test",bonusAttack:15);
            GearPiece test1 = new GearPiece(GearPiece.GearType.Head,"test",bonusHealth:12,bonusIntelligence:5);
            GearPiece test3 = new GearPiece(GearPiece.GearType.Chest,"test",bonusDefense:25,bonusLuck:2);
            GearPiece test5 = new GearPiece(GearPiece.GearType.Legs,"test");
            GearPiece test2 = new GearPiece(GearPiece.GearType.Feet,"test");
            pieces.Add(test4);
            pieces.Add(test1);
            pieces.Add(test3);
            pieces.Add(test5);
            pieces.Add(test2);
        }*/

        public void Equip(GearPiece piece)
        {
            switch (piece.type)
            {
                case GearPiece.GearType.Head:
                    this.head = piece;
                    break;
                case GearPiece.GearType.Chest:
                    this.chest = piece;
                    break;
                case GearPiece.GearType.Legs:
                    this.legs = piece;
                    break;
                case GearPiece.GearType.Feet:
                    this.feet = piece;
                    break;
                case GearPiece.GearType.Weapon:
                    this.weapon = piece;
                    break;
                default:
                    break;
            }
        }

    }
}
