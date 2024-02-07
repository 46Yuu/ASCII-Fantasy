using ASCIIFantasy;
using System;

class ItemList
{
    public static Item  instance;

    public List<Item> listItem = new();

   Item starterPotion = Item.CreateInstance().CreateNewItem(Item.ItemType.Potion, "Starter Potion",5);
   Item smallPotion = Item.CreateInstance().CreateNewItem(Item.ItemType.Potion, "Small Potion",10);
   Item advencedPotion = Item.CreateInstance().CreateNewItem(Item.ItemType.Potion, "Advanced Potion",15);
   Item ultimatePotion = Item.CreateInstance().CreateNewItem(Item.ItemType.Potion, "Ultimate Potion",30);


    public ItemList()
    {
        listItem.Add(starterPotion);
        listItem.Add(smallPotion);
        listItem.Add(advencedPotion);
        listItem.Add(ultimatePotion);
    }

    public static Item CreateInstance()
    {
        if (instance == null)
        {
            instance = new();
        }
        return instance;
    }
}