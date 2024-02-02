using ASCIIFantasy;
using System;

class GearList
{
    public List<GearPiece> listGear = new List<GearPiece>();

    GearPiece startHead = GearPiece.CreateInstance().CreateNewGear(
        GearPiece.GearType.Tete,
        "Starter Head",
        _bonusHealth: 1,
        _bonusIntelligence: 1
        );
    GearPiece startChest = GearPiece.instance.CreateNewGear(
        GearPiece.GearType.Torse,
        "Starter Chest",
        _bonusHealth: 1,
        _bonusDefense: 1
        );
    GearPiece startLegs = GearPiece.instance.CreateNewGear(
    GearPiece.GearType.Jambe,
    "Starter Legs",
    _bonusHealth: 1,
    _bonusDefense: 1 
    );
    GearPiece startBoots = GearPiece.instance.CreateNewGear(
    GearPiece.GearType.Pieds,
    "Starter Boots",
    _bonusHealth: 1,
    _bonusAgility: 1
    );
    GearPiece startWeaponSword = GearPiece.instance.CreateNewGear(
   GearPiece.GearType.Arme,
   "Starter Sword",
   _bonusAttack: 2
   );
    GearPiece startWeaponStaff = GearPiece.instance.CreateNewGear(
   GearPiece.GearType.Arme,
   "Starter Staff",
   _bonusIntelligence: 2
   );

    public void Start()
    {
        listGear.Add( startHead );
        listGear.Add( startChest );
        listGear.Add( startLegs );
        listGear.Add( startBoots );
        listGear.Add( startWeaponSword );
        listGear.Add( startWeaponStaff );
    }
}