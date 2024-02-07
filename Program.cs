using ASCIIFantasy;
using System;

class Program
{
    static void Main()
    {
        Character player1 = new Character("Player1", Element.Neutral, 100, 100, 10, 10, 10, 10, 10);
        Character player2 = new Character("Player2", Element.Neutral, 100, 100, 10, 10, 10, 10, 10);
        Player player = new Player();
        GearList.CreateInstance();
        player.listCharacters.Add(player1);
        player.listCharacters.Add(player2);
        player2.Equip(GearList.instance.listGear[0]);
        player2.Equip(GearList.instance.listGear[1]);
        player2.Equip(GearList.instance.listGear[2]);
        player1.Equip(GearList.instance.listGear[3]);
        player1.Equip(GearList.instance.listGear[4]);
        player.inventory.AddGear(GearList.instance.listGear[6]);
        //player.inventory.AddItem(ItemList.instance.listItem[0], 5);

        /*player.SelectCharacter();*/ //ouvrir menu selection personnage
        //player.inventory.SelectGearToDisplay(); //ouvrir menu selection objet
        

        /*CreateCharacter();*/

        Console.CursorVisible = false;

        Map map = new Map(120, 28);
        map.DrawHouse1(10, 10);
        map.DrawHouse2(20, 10);
        map.DrawRoundTallGrass(10, 2);
        map.DrawNPC(55, 12);
        map.DrawTree(40, 15);

        Menu mainMenu = new Menu(new string[] { "NEW GAME", "LOAD GAME", "EXIT" });

        while (true)
        {
            if (!map.InDialogue)
            {
                mainMenu.Display();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string selectedOption = mainMenu.GetSelectedOption();

                    if (selectedOption == "NEW GAME")
                    {
                        RunGame(map);
                    }
                    else if (selectedOption == "LOAD GAME")
                    {
                        // Faudra implémenter le chargement de partie ici
                    }
                    else if (selectedOption == "EXIT")
                    {
                        Console.WriteLine("Thank you for playing !");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            mainMenu.MoveUp();
                            break;
                        case ConsoleKey.DownArrow:
                            mainMenu.MoveDown();
                            break;
                    }
                }
            }
            else
            {
                map.DisplayDialog();
            }
        }
    }

    static void RunGame(Map map)
    {

        while (true)
        {
            map.DisplayMap();

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    map.MovePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    map.MovePlayer(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    map.MovePlayer(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    map.MovePlayer(1, 0);
                    break;
                case ConsoleKey.E:
                    if (map.InteractWithNPC())
                    {
                        map.DisplayDialog();
                    }
                    break;
            }
        }
    }

/*    static void CreateCharacter()
    {
        Character player1 = new Character("Player1", Element.Neutral, 100, 100, 10, 10, 10, 10, 10);
        Character player2 = new Character("Player2", Element.Neutral, 100, 100, 10, 10, 10, 10, 10);
        Player player = new Player();
        GearList.CreateInstance();
        player.listCharacters.Add(player1);
        player.listCharacters.Add(player2);
        player2.Equip(GearList.instance.listGear[0]);
        player2.Equip(GearList.instance.listGear[1]);
        player2.Equip(GearList.instance.listGear[2]);
        player1.Equip(GearList.instance.listGear[3]);
        player1.Equip(GearList.instance.listGear[4]);
        player.inventory.AddGear(GearList.instance.listGear[6]);
        player.inventory.AddItem(ItemList.instance.listItem[0], 5);

        player.SelectCharacter();
    }*/
}