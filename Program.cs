using ASCIIFantasy;
using System;

class Program
{
    public static int width = 120;
    public static int height = 28;

    static void Main()
    {
        Console.CursorVisible = false;
        MapArray mapArray = new MapArray();
        Player.CreateInstance();
        MapArray.maps[99, 99] = new Map(width, height);
        MapArray.activeMap =MapArray.maps[99, 99];
        Menu mainMenu = new Menu(new string[] { "NEW GAME", "LOAD GAME", "EXIT" });

        while (true)
        {
            if (!MapArray.activeMap.InDialogue)
            {
                mainMenu.Display();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string selectedOption = mainMenu.GetSelectedOption();

                    if (selectedOption == "NEW GAME")
                    {
                        RunGame( MapArray.activeMap);
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
                MapArray.activeMap.DisplayDialog();
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
                    map.MovePlayer( -1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    map.MovePlayer( 1, 0);
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
}