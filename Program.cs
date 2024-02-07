using ASCIIFantasy;
using System;
using System.Numerics;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

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

        Map map = new Map(120, 28);
        map.DrawHouse1(10, 10);
        map.DrawHouse2(20, 10);
        map.DrawRoundTallGrass(10, 2);
        map.DrawNPC(55, 12);
        map.DrawTree(40, 15);

        Menu mainMenu = new Menu(new string[] { "NEW GAME", "LOAD GAME", "EXIT" });

        while (true)
        {
            bool inGame = false;

            while (!inGame)
            {
                mainMenu.Display();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string selectedOption = mainMenu.GetSelectedOption();

                    if (selectedOption == "NEW GAME")
                    {
                        // Faudra implémenter un reset de partie ici qui clean toute la map
                        inGame = true;
                        RunGame(map, player);
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
        }
    }

    static void RunGame(Map map, Player player)
    {
        AltMenu altMenu = new AltMenu(new string[] { "RESUME GAME", "INVENTORY", "TEAM", "SAVE GAME", "MAIN MENU", "EXIT GAME" });

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
                case ConsoleKey.Escape:
                    bool returnToMainMenu = ShowAltMenu(altMenu, player);
                    if (returnToMainMenu)
                    {
                        return;
                    }
                    break;
            }
        }
    }

    static bool ShowAltMenu(AltMenu altMenu, Player player)
    {
        bool altMenuActive = true;

        while (altMenuActive)
        {
            altMenu.Display();

            ConsoleKeyInfo altKeyInfo = Console.ReadKey();
            Console.Clear();

            if (altKeyInfo.Key == ConsoleKey.Enter)
            {
                string selectedAltOption = altMenu.GetSelectedOption();

                if (selectedAltOption == "RESUME GAME")
                {
                    altMenuActive = false;
                }
                else if (selectedAltOption == "INVENTORY")
                {
                    player.inventory.SelectGearToDisplay();
                }
                else if (selectedAltOption == "TEAM")
                {
                    player.SelectCharacter();
                }
                else if (selectedAltOption == "SAVE GAME")
                {
                    // Sauvegarde ici
                }
                else if (selectedAltOption == "MAIN MENU")
                {
                    return true;
                }
                else if (selectedAltOption == "EXIT GAME")
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                switch (altKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        altMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        altMenu.MoveDown();
                        break;
                }
            }
        }

        return false;
    }
}