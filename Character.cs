using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace ASCIIFantasy
{
    public class Character
    {
        protected string name;
        public StatsCharacter stats { get; set; }
        protected Dictionary<string, Attack> listAttack = new Dictionary<string, Attack>();
        public Gear characterGear { get; }


        public Character()
        {
            name = "Jean-mi";
            stats = new StatsCharacter();
            characterGear = new Gear();
            AddGearStats();
        }

        public Character(string n, int hp, int man, int atk, int def, int intel, int agi, int luc)
        {
            name = n;
            stats = new StatsCharacter(hp, man, atk, def, intel, agi, luc);
            AddAttack("Melee");
            characterGear = new Gear();
            AddGearStats();
        }

        public void AddAttack(string name)
        {
            Attack attack = new Attack(name);
            listAttack.Add(name, attack);
        }

        public Attack GetAttack(string name)
        {
            if (listAttack.ContainsKey(name))
            {
                return listAttack[name];
            }
            else
            {
                throw new Exception("Attack not found");
            }
        }

        public StatsCharacter GetStats()
        {
            return stats;
        }

        public List<string> GetListSpells()
        {
            List<string> ret = new List<string>();
            foreach (var p in listAttack)
            {
                if (p.Key != "Melee")
                {
                    ret.Add(p.Key);
                }
            }
            return ret;
        }

        public List<int> GetListCost()
        {
            List<int> ret = new List<int>();
            foreach (var p in listAttack)
            {
                if (p.Key != "Melee")
                {
                    ret.Add(p.Value.GetCost());
                }
            }
            return ret;
        }

        public string GetName()
        {
            return name;
        }

        public Gear GetGear()
        {
            return characterGear;
        }
        public void SetName(string n)
        {
            name = n;
        }


        public override string ToString()
        {
            return $"Name: {name}\nHealth: {stats.GetActualHealth()} / {stats.GetMaxHealth()}\nMana: {stats.GetActualMana()} / {stats.GetMaxMana()}\nAttack: {stats.GetAttack()}\nDefense: {stats.GetDefense()}\nAgility: {stats.GetAgility()}\nIntelligence: {stats.GetIntel()}\nLuck: {stats.GetLuck()}\n";
        }

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
