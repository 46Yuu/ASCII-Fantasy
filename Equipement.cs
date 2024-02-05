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

            pieces.Add(head);
            pieces.Add(chest);
            pieces.Add(legs);
            pieces.Add(feet);
            pieces.Add(weapon);
        }

        public void Equip(GearPiece piece)
        {
            if(piece == null) throw new ArgumentNullException(nameof(piece),"Piece Null");
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
