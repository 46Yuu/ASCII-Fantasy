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
                ground[i, j] = ' '; // Initialize with empty space
            }
        }

        // Draw borders
        for (int i = 0; i < width; i++)
        {
            ground[i, 0] = '-';
            ground[i, height - 1] = '-';
        }
        for (int j = 0; j < height; j++)
        {
            ground[0, j] = '|';
            ground[width - 1, j] = '|';
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

    public void DrawSmallHouse(int x, int y)
    {
        ground[x, y] = 'H'; // House
        ground[x, y - 1] = 'A'; // Roof
        ground[x - 1, y] = '|'; // Left wall
        ground[x + 1, y] = '|'; // Right wall
    }
    public void DrawSmallHouse2(int x, int y)
    {
        ground[x, y] = 'C'; // Country House
        ground[x, y - 1] = 'V'; // Roof
        ground[x - 1, y] = '|'; // Left wall
        ground[x + 1, y] = '|'; // Right wall
        ground[x - 1, y - 1] = '/'; // Country details
        ground[x + 1, y - 1] = '\\'; // Country details
    }

    public void DrawTallGrass(int x, int y)
    {
        ground[x, y] = '#';
    }

    public void DrawNPC(int x, int y)
    {
        ground[x, y] = 'o'; // Head
        ground[x, y + 1] = '|'; // Body
        ground[x - 1, y + 1] = '/'; // Left arm
        ground[x + 1, y + 1] = '\\'; // Right arm
        ground[x - 1, y + 2] = '/'; // Left leg
        ground[x + 1, y + 2] = '\\'; // Right leg
    }


    public void MovePlayer(int mooveX, int mooveY)
    {
        ground[positionX, positionY] = ' '; // ancienne position
        positionX += mooveX;
        positionY += mooveY;
        ground[positionX, positionY] = 'P'; // nouvelle position
    }
}