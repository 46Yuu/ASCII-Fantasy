using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;

namespace ASCIIFantasy
{


    public class Character
    {
        public string name { get; set; }
        protected Element element;
        public StatsCharacter stats { get; set; }
        protected List<Attack> listAttack = new List<Attack>();
        public Gear characterGear { get; }
        public bool isDead { get; set; } = false;

        public Character()
        {
            name = "Jean-Michel";
            element = Element.Neutral;
            stats = new StatsCharacter();
            characterGear = new Gear();
            AddGearStats();
        }

        public Character(string n, Element _element, int hp, int man, int atk, int def, int intel, int agi, int luc)
        {
            name = n;
            stats = new StatsCharacter(hp, man, atk, def, intel, agi, luc);
            element = _element;
            Physical melee = new Physical("Melee", Element.Neutral, 0, 0);
            listAttack.Add(melee);
            characterGear = new Gear();
            AddGearStats();
        }

        public void AddAttack(Attack atk)
        {
            listAttack.Add(atk);
        }

        public Attack GetAttack(string name)
        {
            foreach (Attack attack in listAttack)
            {
                if (attack.attack_name == name)
                    return attack;
            }
            throw new Exception("Attack not found");
        }


        public List<string> GetListSpells()
        {
            List<string> ret = new List<string>();
            foreach (Attack p in listAttack)
            {
                if (p.attack_name != "Melee")
                {
                    ret.Add(p.attack_name);
                }
            }
            return ret;
        }

        public List<int> GetListCost()
        {
            List<int> ret = new List<int>();
            foreach (Attack p in listAttack)
            {
                if (p.attack_name != "Melee")
                {
                    ret.Add(p.cost);
                }
            }
            return ret;
        }

        public Gear GetGear()
        {
            return characterGear;
        }

        public override string ToString()
        {
            return $"Name: {name}\nHealth: {stats.actual_hp} / {stats.health}\nMana: {stats.actual_mana} / {stats.mana}\n" +
                $"Attack: {stats.attack}\nDefense: {stats.defense}\nAgility: {stats.agility}\nIntelligence: {stats.intelligence}\n" +
                $"Luck: {stats.luck}\n";

        }

        public Element GetElement() { return element; }

        public void AddGearStats()
        {
            if (characterGear != null)
            {

                int tempAttack = 0;
                int tempHealth = 0;
                int tempMana = 0;
                int tempDef = 0;
                int tempAgi = 0;
                int tempLuck = 0;
                int tempIntel = 0;
                foreach (GearPiece piece in characterGear.pieces)
                {
                    if (piece != null)
                    {

                        tempAttack += piece.bonusAttack;
                        tempHealth += piece.bonusHealth;
                        tempMana += piece.bonusMana;
                        tempDef += piece.bonusDefense;
                        tempAgi += piece.bonusAgility;
                        tempLuck += piece.bonusLuck;
                        tempIntel += piece.bonusIntelligence;
                    }
                }
                stats.SetBonusHealth(tempHealth);
                stats.SetBonusMana(tempMana);
                stats.SetBonusAttack(tempAttack);
                stats.SetBonusDefense(tempDef);
                stats.SetBonusIntelligence(tempIntel);
                stats.SetBonusAgility(tempAgi);
                stats.SetBonusLuck(tempLuck);
            }
        }

        public void Equip(GearPiece piece)
        {
            if (characterGear.pieces[(int)piece.type] != null)
            {
                characterGear.pieces[(int)piece.type].isEquiped = false;
            }
            switch (piece.type)
            {
                case GearPiece.GearType.Head:
                    characterGear.head = piece;
                    characterGear.pieces[0] = characterGear.head;
                    Debug.WriteLine("Equipped " + characterGear.head.gearName);
                    break;
                case GearPiece.GearType.Chest:
                    characterGear.chest = piece;
                    characterGear.pieces[1] = characterGear.chest;
                    Debug.WriteLine("Equipped " + characterGear.chest.gearName);
                    break;
                case GearPiece.GearType.Legs:
                    characterGear.legs = piece;
                    characterGear.pieces[2] = characterGear.legs;
                    Debug.WriteLine("Equipped " + characterGear.legs.gearName);
                    break;
                case GearPiece.GearType.Feet:
                    characterGear.feet = piece;
                    characterGear. pieces[3] = characterGear.feet;
                    Debug.WriteLine("Equipped " + characterGear.feet.gearName);
                    break;
                case GearPiece.GearType.Weapon:
                    characterGear.weapon = piece;
                    characterGear.pieces[4] = characterGear.weapon;
                    Debug.WriteLine("Equipped " + characterGear.weapon.gearName);
                    break;
            }
            piece.isEquiped = true;
            AddGearStats();
        }


    }
}
