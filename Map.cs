using System;

public class Map
{
    private char[,] ground;
    private int width; // largeur
    private int height; // hauteur
    private int positionX;
    private int positionY;

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;
        ground = new char[width, height];
        positionX = width / 2;
        positionY = height / 2;
        InitializeMap();
    }

    private void InitializeMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                ground[i, j] = '.';
            }
        }
        ground[positionX, positionY] = 'P'; // Player
    }

    public void DisplayMap()
    {
        Console.Clear();
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write(ground[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void MovePlayer(int mooveX, int mooveY)
    {
        ground[positionX, positionY] = '.'; // ancienne position
        positionX += mooveX;
        positionY += mooveY;
        ground[positionX, positionY] = 'P'; // nouvelle position
    }
}