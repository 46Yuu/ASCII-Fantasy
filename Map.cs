using System;

public class Map
{
    public const char TALL_GRASS = '#';

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
                ground[i, j] = ' ';
            }
        }

        // Borders
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

    public void DrawHouse1(int x, int y)
    {
        ground[x, y] = 'm';
        ground[x - 1, y] = '_';
        ground[x + 1, y] = '_';

        ground[x, y + 1] = '_';
        ground[x - 1, y + 1] = '_';
        ground[x + 1, y + 1] = '_';
        ground[x + 2, y + 1] = '\\';
        ground[x - 2, y + 1] = '\\';
        ground[x - 3, y + 1] = '/';

        ground[x, y + 2] = '"';
        ground[x - 1, y + 2] = '|';
        ground[x + 1, y + 2] = '"';
        ground[x + 2, y + 2] = '|';
        ground[x - 2, y + 2] = '_';
        ground[x - 3, y + 2] = '|';
    }

    public void DrawHouse2(int x, int y)
    {
        ground[x, y] = '[';
        ground[x + 1, y] = ']';
        ground[x + 2, y] = '_';
        ground[x + 3, y] = '_';
        ground[x + 4, y] = '_';

        ground[x - 1 , y + 1] = '/';
        ground[x + 4, y + 1] = '/';
        ground[x + 5, y + 1] = '\\';

        ground[x - 2, y + 2] = '/';
        ground[x - 1, y + 2] = '_';
        ground[x, y + 2] = '_';
        ground[x + 1, y + 2] = '_';
        ground[x + 2, y + 2] = '_';
        ground[x + 3, y + 2] = '/';
        ground[x + 4, y + 2] = '_';
        ground[x + 5, y + 2] = '_';
        ground[x + 6, y + 2] = '\\';

        ground[x - 2, y + 3] = '|';
        ground[x - 1, y + 3] = '[';
        ground[x, y + 3] = ']';
        ground[x + 1, y + 3] = '[';
        ground[x + 2, y + 3] = ']';
        ground[x + 3, y + 3] = '|';
        ground[x + 4, y + 3] = '|';
        ground[x + 5, y + 3] = '|';
        ground[x + 6, y + 3] = '|';
    }

    public void Draw1TallGrass(int x, int y)
    {
        ground[x, y] = TALL_GRASS;
    }

    public void DrawRoundTallGrass(int x, int y)
    {
        ground[x, y] = TALL_GRASS;
        ground[x + 1, y] = TALL_GRASS;
        ground[x - 1, y] = TALL_GRASS;
        ground[x + 2, y] = TALL_GRASS;

        ground[x, y + 1] = TALL_GRASS;
        ground[x - 1, y + 1] = TALL_GRASS;
        ground[x - 2, y + 1] = TALL_GRASS;
        ground[x + 1, y + 1] = TALL_GRASS;
        ground[x + 2, y + 1] = TALL_GRASS;
        ground[x + 3, y + 1] = TALL_GRASS;

        ground[x, y + 2] = TALL_GRASS;
        ground[x - 1, y + 2] = TALL_GRASS;
        ground[x - 2, y + 2] = TALL_GRASS;
        ground[x - 3, y + 2] = TALL_GRASS;
        ground[x + 1, y + 2] = TALL_GRASS;
        ground[x + 2, y + 2] = TALL_GRASS;
        ground[x + 3, y + 2] = TALL_GRASS;
        ground[x + 4, y + 2] = TALL_GRASS;

        ground[x, y + 3] = TALL_GRASS;
        ground[x - 1, y + 3] = TALL_GRASS;
        ground[x - 2, y + 3] = TALL_GRASS;
        ground[x + 1, y + 3] = TALL_GRASS;
        ground[x + 2, y + 3] = TALL_GRASS;
        ground[x + 3, y + 3] = TALL_GRASS;

        ground[x, y + 4] = TALL_GRASS;
        ground[x + 1, y + 4] = TALL_GRASS;
        ground[x - 1, y + 4] = TALL_GRASS;
        ground[x + 2, y + 4] = TALL_GRASS;
    }

    public void DrawNPC(int x, int y)
    {
        ground[x, y] = '8';
    }

    public void DrawTree(int x, int y)
    {
        ground[x, y + 4] = '|';

        ground[x , y] = '^';

        ground[x, y + 1] = '^';
        ground[x - 1, y + 1] = '^';
        ground[x + 1, y + 1] = '^';

        ground[x, y + 2] = '^';
        ground[x - 1, y + 2] = '^';
        ground[x - 2, y + 2] = '^';
        ground[x + 1, y + 2] = '^';
        ground[x + 2, y + 2] = '^';

        ground[x, y + 3] = '^';
        ground[x - 1, y + 3] = '^';
        ground[x - 2, y + 3] = '^';
        ground[x - 3, y + 3] = '^';
        ground[x + 1, y + 3] = '^';
        ground[x + 2, y + 3] = '^';
        ground[x + 3, y + 3] = '^';

    }

    public void MovePlayer(int moveX, int moveY)
    {
        // Faudra gérer ici le déclenchement combat aléatoire si on est en #
        ground[positionX, positionY] = ' ';

        int newPosX = positionX + moveX;
        int newPosY = positionY + moveY;

        if (newPosX >= 0 && newPosX < width && newPosY >= 0 && newPosY < height &&
            (ground[newPosX, newPosY] == ' ' || ground[newPosX, newPosY] == '#'))
        {
            positionX = newPosX;
            positionY = newPosY;
        }

        ground[positionX, positionY] = 'P';
    }
}