/*using System;

class Program
{
    static void Main()
    {

        Map map = new Map(120, 28); // Taille de la carte en colomnes et lignes

        while (true)
        {
            //map.DrawHouse(10, 10);
            map.DisplayMap();

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            // Déplacement
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
                default:
                    Console.WriteLine("Unrecognized key. Use the arrows to move.");
                    break;
            }
        }
    }
}*/