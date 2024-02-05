using System;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        Map map = new Map(120, 28);
        map.DrawHouse1(10, 10);
        map.DrawHouse2(20, 10);
        map.DrawRoundTallGrass(10, 2);
        map.DrawNPC(30, 20);
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
                DisplayDialog(map);
            }
        }
    }

    static void RunGame(Map map)
    {
        bool isEPressed = false;

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
                    isEPressed = true;
                    break;
            }

            if (isEPressed && !map.InDialogue)
            {
                map.InDialogue = true;
                DisplayDialog(map);
                isEPressed = false;  // Réinitialise l'état de la touche "E" après le dialogue
            }
        }
    }

    static void DisplayDialog(Map map)
    {

        while (map.InDialogue && map.HasMoreDialogues())
        {
            string currentDialogue = map.GetCurrentDialogue();
            Console.WriteLine(currentDialogue);
            Console.WriteLine("Appuyez sur Entrée pour continuer...");

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
            } while (keyInfo.Key != ConsoleKey.Enter);

            map.NextDialogue();
        }

        map.InDialogue = false;
        Console.Clear();
    }
}