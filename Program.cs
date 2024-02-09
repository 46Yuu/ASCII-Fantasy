using ASCIIFantasy;
using System;
using System.Numerics;
using System.Xml.Linq;

class Program
{
    public static int width = 120;
    public static int height = 28;

    static void Main()
    {
        Console.CursorVisible = false;
        MapArray.CreateInstance();
        Player.CreateInstance();
        EnemyList.CreateInstance();
        ListAttackGlobal.CreateInstance();
        Character character = new Character("Jean-Michel", Element.Neutral, 100, 100, 10, 10, 10, 10, 10);
        Player.instance.AddCharacter(character);
        character.AddAttack(ListAttackGlobal.instance.GetAttack(AttackType.Spell,"Fireball"));
        MapArray.instance.maps[99, 99] = new Map(width, height);
        MapArray.instance.activeMap =MapArray.instance.maps[99, 99];
        Menu mainMenu = new Menu(new string[] { "NEW GAME", "LOAD GAME", "EXIT" });

        while (true)
        {
            if (!MapArray.instance.activeMap.InDialogue)
            {
                mainMenu.Display();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string selectedOption = mainMenu.GetSelectedOption();

                    if (selectedOption == "NEW GAME")
                    {
                        RunGame();
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
                MapArray.instance.activeMap.DisplayDialog();
            }
        }
    }

    static void RunGame()
    {
        AltMenu altMenu = new AltMenu(new string[] { "RESUME GAME", "INVENTORY", "TEAM", "SAVE GAME", "MAIN MENU", "EXIT GAME" });

        while (true)
        {
            MapArray.instance.activeMap.DisplayMap();

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    MapArray.instance.activeMap.MovePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    MapArray.instance.activeMap.MovePlayer(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    MapArray.instance.activeMap.MovePlayer( -1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    MapArray.instance.activeMap.MovePlayer( 1, 0);
                    break;
                case ConsoleKey.E:
                    if (MapArray.instance.activeMap.InteractWithNPC())
                    {
                        MapArray.instance.activeMap.DisplayDialog();
                    }
                    break;
                case ConsoleKey.Escape:
                    bool returnToMainMenu = ShowAltMenu(altMenu, Player.instance);
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