using ASCIIFantasy;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;

public class Map
{
    public const char TALL_GRASS = '#';

    private char[,] mapTile;
    private int width; // largeur
    private int height; // hauteur
    private int positionX;
    private int positionY;
    private int widthGap = 4;
    private int heightGap = 2;

    private bool inDialogue;
    private List<string> dialogues;
    private int currentDialogueIndex;
    private char nextCell;
        public bool InDialogue
    {
        get { return inDialogue; }
        set { inDialogue = value; }
    }

    public Map( int width, int height)
    {
        this.width = width;
        this.height = height;
        mapTile = new char[width, height];

        InitializeMap();

        dialogues = new List<string>
        {
            "NPC: Hello, adventurer!",
            "NPC: How can I assist you?",
            "NPC: Feel free to ask me any questions!"
        };

        inDialogue = false;
        currentDialogueIndex = 0;
    }
  
    private void InitializeNextMap()
    {
        nextCell = ' ';

        if (MapArray.instance.maps[99 + Player.instance.mapGlobalIndex[0]][99 + Player.instance.mapGlobalIndex[1]] != null)
        {
            MapArray.instance.activeMap = MapArray.instance.maps[99 + Player.instance.mapGlobalIndex[0]][99 + Player.instance.mapGlobalIndex[1]];
            MapArray.instance.activeMap.SetPlayer(Player.instance.positionX, Player.instance.positionY);
        }
        else
        {
            Map newMap = new Map(Program.width, Program.height);

        }
    }
    private void InitializeMap()
    {
        positionX = Player.instance.positionX;
        positionY = Player.instance.positionY;
        nextCell = ' ';

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                mapTile[i, j] = ' ';
            }
        }

        // Borders
        for (int i = 0; i < width; i++)
        {
            if (i < (width / 2) - widthGap || i > (width / 2) + widthGap)
            {

                mapTile[i, 0] = '-';
                mapTile[i, height - 1] = '-';
            }
            else
            {
                mapTile[i, 0] = ' ';
                mapTile[i, height - 1] = ' ';
            }
        }
        for (int j = 0; j < height; j++)
        {
            if (j < (height / 2) - heightGap || j > (height / 2) + heightGap)
            {
                mapTile[0, j] = '|';
                mapTile[width - 1, j] = '|';
            }
            else
            {
                mapTile[0, j] = ' ';
                mapTile[width - 1, j] = ' ';
            }
        }
        mapTile[positionX, positionY] = 'P'; // Player
        GenerateBuilding();
        MapArray.instance.maps[99 + Player.instance.mapGlobalIndex[0]][ 99 + Player.instance.mapGlobalIndex[1]] = this;
        MapArray.instance.activeMap = this;
    }

    public void DisplayMap()
    {
        Console.Clear();
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write(mapTile[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void DrawHouse1(int x, int y)
    {
        mapTile[x + 2, y] = '_';
        mapTile[x + 3, y] = 'm';
        mapTile[x + 4, y] = '_';

        mapTile[x, y + 1] = '/';
        mapTile[x + 1, y + 1] = '\\';
        mapTile[x + 2, y + 1] = '_';
        mapTile[x + 3, y + 1] = '_';
        mapTile[x + 4, y + 1] = '_';
        mapTile[x + 5, y + 1] = '\\';

        mapTile[x, y + 2] = '|';
        mapTile[x + 1, y + 2] = '_';
        mapTile[x + 2, y + 2] = '|';
        mapTile[x + 3, y + 2] = '"';
        mapTile[x + 4, y + 2] = '"';
        mapTile[x + 5, y + 2] = '|';
    }

    public void DrawHouse2(int x, int y)
    {
        mapTile[x + 2, y] = '[';
        mapTile[x + 3, y] = ']';
        mapTile[x + 4, y] = '_';
        mapTile[x + 5, y] = '_';
        mapTile[x + 6, y] = '_';

        mapTile[x + 1, y + 1] = '/';
        mapTile[x + 6, y + 1] = '/';
        mapTile[x + 7, y + 1] = '\\';

        mapTile[x, y + 2] = '/';
        mapTile[x + 1, y + 2] = '_';
        mapTile[x + 2, y + 2] = '_';
        mapTile[x + 3, y + 2] = '_';
        mapTile[x + 4, y + 2] = '_';
        mapTile[x + 5, y + 2] = '/';
        mapTile[x + 6, y + 2] = '_';
        mapTile[x + 7, y + 2] = '_';
        mapTile[x + 8, y + 2] = '\\';

        mapTile[x, y + 3] = '|';
        mapTile[x + 1, y + 3] = '[';
        mapTile[x + 2, y + 3] = ']';
        mapTile[x + 3, y + 3] = '[';
        mapTile[x + 4, y + 3] = ']';
        mapTile[x + 5, y + 3] = '|';
        mapTile[x + 6, y + 3] = '|';
        mapTile[x + 7, y + 3] = '|';
        mapTile[x + 8, y + 3] = '|';
    }

    public void Draw1TallGrass(int x, int y)
    {
        mapTile[x, y] = TALL_GRASS;
    }

    public void DrawRoundTallGrass(int x, int y)
    {
        mapTile[x, y] = TALL_GRASS;
        mapTile[x + 1, y] = TALL_GRASS;
        mapTile[x - 1, y] = TALL_GRASS;
        mapTile[x + 2, y] = TALL_GRASS;

        mapTile[x, y + 1] = TALL_GRASS;
        mapTile[x - 1, y + 1] = TALL_GRASS;
        mapTile[x - 2, y + 1] = TALL_GRASS;
        mapTile[x + 1, y + 1] = TALL_GRASS;
        mapTile[x + 2, y + 1] = TALL_GRASS;
        mapTile[x + 3, y + 1] = TALL_GRASS;

        mapTile[x, y + 2] = TALL_GRASS;
        mapTile[x - 1, y + 2] = TALL_GRASS;
        mapTile[x - 2, y + 2] = TALL_GRASS;
        mapTile[x - 3, y + 2] = TALL_GRASS;
        mapTile[x + 1, y + 2] = TALL_GRASS;
        mapTile[x + 2, y + 2] = TALL_GRASS;
        mapTile[x + 3, y + 2] = TALL_GRASS;
        mapTile[x + 4, y + 2] = TALL_GRASS;

        mapTile[x, y + 3] = TALL_GRASS;
        mapTile[x - 1, y + 3] = TALL_GRASS;
        mapTile[x - 2, y + 3] = TALL_GRASS;
        mapTile[x + 1, y + 3] = TALL_GRASS;
        mapTile[x + 2, y + 3] = TALL_GRASS;
        mapTile[x + 3, y + 3] = TALL_GRASS;

        mapTile[x, y + 4] = TALL_GRASS;
        mapTile[x + 1, y + 4] = TALL_GRASS;
        mapTile[x - 1, y + 4] = TALL_GRASS;
        mapTile[x + 2, y + 4] = TALL_GRASS;
    }

    public void DrawNPC(int x, int y)
    {
        mapTile[x, y] = '8';
    }

    public void DrawTree(int x, int y)
    {
        mapTile[x, y + 4] = '|';

        mapTile[x, y] = '^';

        mapTile[x, y + 1] = '^';
        mapTile[x - 1, y + 1] = '^';
        mapTile[x + 1, y + 1] = '^';

        mapTile[x, y + 2] = '^';
        mapTile[x - 1, y + 2] = '^';
        mapTile[x - 2, y + 2] = '^';
        mapTile[x + 1, y + 2] = '^';
        mapTile[x + 2, y + 2] = '^';

        mapTile[x, y + 3] = '^';
        mapTile[x - 1, y + 3] = '^';
        mapTile[x - 2, y + 3] = '^';
        mapTile[x - 3, y + 3] = '^';
        mapTile[x + 1, y + 3] = '^';
        mapTile[x + 2, y + 3] = '^';
        mapTile[x + 3, y + 3] = '^';

    }

    public void SetPlayer(int posX, int posY)
    {
        mapTile[positionX, positionY] = nextCell;
        positionX = posX;
        positionY = posY;
        nextCell = mapTile[positionX, positionY];
        mapTile[positionX, positionY] = 'P';
    }
    public void MovePlayer( int moveX, int moveY)
    {
        int nextPosX = positionX + moveX;
        int nextPosY = positionY + moveY;
        if (nextPosX != 0 && nextPosX != width && nextPosY != 0 && nextPosY != height)
        {
            if (mapTile[nextPosX, nextPosY] == ' ' || mapTile[nextPosX, nextPosY] == '#')
            {
                mapTile[positionX, positionY] = nextCell;
                nextCell = mapTile[nextPosX, nextPosY];
                positionX = nextPosX;
                positionY = nextPosY;
                Player.instance.positionX = positionX;
                Player.instance.positionY = positionY;
                mapTile[positionX, positionY] = 'P';
            }
        }
        else if (nextPosX == 0 || nextPosX == width)
        {
            if (nextPosY <= height / 2 + heightGap && nextPosY >= height / 2 - heightGap)
            {
                SwapZone();
            }
        }
        else if (nextPosY == 0 || nextPosY == height)
        {
            if (nextPosX <= width / 2 + widthGap && nextPosX >= width / 2 - widthGap)
            {
                SwapZone();

            }
        }

    }

    public void DisplayDialog()
    {
        while (InDialogue && HasMoreDialogues())
        {
            string currentDialogue = GetCurrentDialogue();
            Console.WriteLine(currentDialogue);
            Console.WriteLine("\n");
            Console.WriteLine("Appuyez sur Entrée pour continuer...");

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
            } while (keyInfo.Key != ConsoleKey.Enter);

            NextDialogue();
        }

        InDialogue = false;
        Console.Clear();
    }



    public string GetCurrentDialogue()
    {
        return dialogues[currentDialogueIndex];
    }

    public void NextDialogue()
    {
        Console.Clear();
        currentDialogueIndex++;

        if (currentDialogueIndex >= dialogues.Count)
        {
            inDialogue = false;
            currentDialogueIndex = 0;
        }
    }

    public bool HasMoreDialogues()
    {
        return currentDialogueIndex <= dialogues.Count;
    }

    public int CurrentDialogueIndex
    {
        get { return currentDialogueIndex; }
    }

    public int PlayerPositionX { get { return positionX; } }
    public int PlayerPositionY { get { return positionY; } }

    public bool IsNPCNearby(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height && mapTile[x, y] == '8';
    }

    public bool InteractWithNPC()
    {
        int playerX = PlayerPositionX;
        int playerY = PlayerPositionY;

        if ((IsNPCNearby(playerX - 1, playerY) ||
             IsNPCNearby(playerX + 1, playerY) ||
             IsNPCNearby(playerX, playerY - 1) ||
             IsNPCNearby(playerX, playerY + 1)) && InDialogue == false)
        {
            InDialogue = true;
            currentDialogueIndex = 0;
            return true;
        }

        return false;
    }

    public void GenerateBuilding()
    {
        Random random = new Random();

        int buildingRndNbr = random.Next(4, 10);
        int kindOfBuilding = 0;
        for (int o = 0; o < buildingRndNbr; o++)
        {
            kindOfBuilding = random.Next(1, 3);
            bool canBuild = false;
            int x = 0;
            int y = 0;
            while (!canBuild)
            {
                x = random.Next(1, width);
                y = random.Next(1, height);
                if (x + 9 >= width || y + 5 >= height || x + 6 >= width || y + 3 >= height)
                {
                    continue;
                }
                if (kindOfBuilding == 1)
                {
                    for (int j = x; j < x + 6; j++)
                    {
                        for (int k = y; k < y + 3; k++)
                        {
                            if (mapTile[j, k] == ' ')
                            {
                                canBuild = true;
                            }
                            else
                            {
                                canBuild = false;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = x; j < x + 9; j++)
                    {
                        for (int k = y; k < y + 5; k++)
                        {
                            if (mapTile[j, k] == ' ')
                            {
                                canBuild = true;
                            }
                            else
                            {
                                canBuild = false;
                            }
                        }
                    }
                }
            }
            if (kindOfBuilding == 1)
            {
                DrawHouse1(x, y);
            }
            else
            {
                DrawHouse2(x, y);
            }
        }
    }

    public void SwapZone()
    {

        if (positionX == 1)
        {
            Player.instance.positionX = width - 1;
            Player.instance.mapGlobalIndex[0] = Player.instance.mapIndexX - 1;
            Player.instance.mapIndexX--;

        }
        else if (positionX == width-1)
        {
            Player.instance.positionX = 1;
            Player.instance.mapGlobalIndex[0] = Player.instance.mapIndexX + 1;
            Player.instance.mapIndexX++;

        }
        else if (positionY == 1)
        {
            Player.instance.positionY = height - 1;
            Player.instance.mapGlobalIndex[1] = Player.instance.mapIndexY - 1;
            Player.instance.mapIndexY--;

        }
        else if (positionY == height-1)
        {
            Player.instance.positionY = 1;
            Player.instance.mapGlobalIndex[1] = Player.instance.mapIndexY + 1;
            Player.instance.mapIndexY++;

        }
        InitializeNextMap();
    }

}