using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class Item
    {
        public static Item instance;

        public string itemName;
        public int numberItem;
        public int power;
        public enum ItemType
        {
            Potion,
            ItemBuff
        }

        public ItemType type;

        public void  Use (Character character)
        {
            switch (type)
            {
                case ItemType.Potion:
                    character.stats.IncrementHealth(power) ;
                    break;
                case ItemType.ItemBuff:
                    break;
                default:
                    break;
            }
        }

        public Item CreateNewItem(ItemType type,string _name,int _power,int number = 0)
        {
            Item item = new();
            item.type = type;
            item.itemName = _name;
            item.numberItem = number;
            item.power = _power;
            return item;
        }

        public  static Item CreateInstance()
        {
            if (instance == null)
            {
                instance = new Item();
            }
            return instance;
        }

    }
}
