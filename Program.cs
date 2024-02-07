using ASCIIFantasy;
using System;

class Program
{
    public static int width = 120;
    public static int height = 28;

    static void Main()
    {
        Console.CursorVisible = false;
        MapArray.CreateInstance();
        Player.CreateInstance();
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
            }
        }
    }
}