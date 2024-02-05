using ASCIIFantasy;
using System;

class GearList
{
    public List<GearPiece> listGear = new List<GearPiece>();
    public static GearList instance;

    GearPiece startHead = GearPiece.CreateInstance().CreateNewGear(
        GearPiece.GearType.Head,
        "Starter Head",
        _bonusHealth: 1,
        _bonusIntelligence: 1
        );

    GearPiece startChest = GearPiece.instance.CreateNewGear(
        GearPiece.GearType.Chest,
        "Starter Chest",
        _bonusHealth: 1,
        _bonusDefense: 1
        );

    GearPiece startLegs = GearPiece.instance.CreateNewGear(
    GearPiece.GearType.Legs,
    "Starter Legs",
    _bonusHealth: 1,
    _bonusDefense: 1
    );

    GearPiece startBoots = GearPiece.instance.CreateNewGear(
    GearPiece.GearType.Feet,
    "Starter Boots",
    _bonusHealth: 1,
    _bonusAgility: 1
    );

    GearPiece startWeaponStaff = GearPiece.instance.CreateNewGear(
   GearPiece.GearType.Weapon,
   "Starter Staff",
   _bonusIntelligence: 2
   );

    GearPiece startWeaponSword = GearPiece.instance.CreateNewGear(
   GearPiece.GearType.Weapon,
   "Starter Sword",
   _bonusAttack: 2
   );


    public GearList()
    {
        listGear.Add(startHead);
        listGear.Add(startChest);
        listGear.Add(startLegs);
        listGear.Add(startBoots);
        listGear.Add(startWeaponSword);
        listGear.Add(startWeaponStaff);
    }

    public static GearList CreateInstance()
    {
        if (instance == null)
        {
            instance = new GearList();
        }
        return instance;
    }
}