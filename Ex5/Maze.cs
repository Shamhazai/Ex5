
class Maze
{
    static void Main()
    {
        Console.SetWindowPosition(0, 0);
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.WriteLine("Лабиринт загадок...\n Никто не выйдет!\n");
        Console.WriteLine("W - наверх\nA - влево S - вниз D - вправо\nEsc - выход\nP - путь до конца\n");
        Console.ReadKey();
        int i, j;
        int n = 0, n1 = 0;
        var wall = '█';
        var player = 'M';


        var end = 'E';
        var pressedHint = false;
        var exit = false;
        int count = 0;


        string[] str = File.ReadAllLines($"../../../Res/maze.txt");
        int[,] map = new int[str.Length, str[0].Split(' ').Length];
        for (i = 0; i < str.Length; i++)
        {
            string[] str2 = str[i].Split(' ');
            for (j = 0; j < str2.Length; j++)
                map[i, j] = Int32.Parse(str2[j]);
            n = str2.Length;
        }

        // файл с решением лабиринта
        string[] sol = File.ReadAllLines($"../../../Res/maze_sol.txt");
        int[,] map_sol = new int[sol.Length, sol[0].Split(' ').Length];
        for (i = 0; i < sol.Length; i++)
        {
            string[] sol2 = sol[i].Split(' ');
            for (j = 0; j < sol2.Length; j++)
                map_sol[i, j] = Int32.Parse(sol2[j]);
            n1 = sol2.Length;
        }

        Console.Clear();
        ConsoleKeyInfo key;
        Console.CursorVisible = false;
        int x = 0;
        int y = 0;
        int indexX = -1;
        int indexY = -1;
        int playerX = -1;
        int playerY = -1;
        for (i = 0; i < str.Length; i++)
        {
            for (j = 0; j < str.Length; j++)
            {
                if (map[i, j] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player);
                    Console.ForegroundColor = ConsoleColor.White;
                    playerX = i;
                    playerY = j;
                }
            }
        }

        // первоначальная прорисовка карты
        Console.SetCursorPosition(0, 0);
        for (i = 0; i < str.Length; i++)
        {
            for (j = 0; j < n; j++)
            {
                if (map[i, j] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(end);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (map[i, j] == 1)
                {
                    Console.Write(wall);
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }

        Console.SetCursorPosition(x += playerY, y += playerX);

        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(player);
        Console.ForegroundColor = ConsoleColor.White;

        // игровой цикл, получаем действие игрока и обновляем поле в цикле
        while (true)
        {

            key = Console.ReadKey(true);
            if (key.KeyChar == 119 || key.KeyChar == 87)
            {
                if (map[playerX - 1, playerY] != 1)
                {

                    Console.Write(' ');
                    Console.SetCursorPosition(x, --y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player);
                    Console.ForegroundColor = ConsoleColor.White;
                    count++;

                    playerX--;


                }
            }
            else if (key.KeyChar == 115 || key.KeyChar == 83)//S или s
            {

                if (map[playerX + 1, playerY] != 1)
                {

                    Console.Write(' ');
                    Console.SetCursorPosition(x, ++y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player);
                    Console.ForegroundColor = ConsoleColor.White;
                    count++;

                    playerX++;

                }

            }
            else if (key.KeyChar == 97 || key.KeyChar == 65)//A или a
            {

                if (map[playerX, playerY - 1] != 1)
                {
                    Console.Write(' ');
                    Console.SetCursorPosition(--x, y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player);
                    Console.ForegroundColor = ConsoleColor.White;
                    count++;
                   
                    playerY--;

                }

            }
            else if (key.KeyChar == 100 || key.KeyChar == 68)//D
            {

                if (map[playerX, playerY + 1] != 1)
                {
                    Console.Write(' ');
                    Console.SetCursorPosition(++x, y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player);
                    Console.ForegroundColor = ConsoleColor.White;
                    count++;
  
                    playerY++;

                }
            }
            else if ((key.KeyChar == 112 || key.KeyChar == 80))//P - путь до конца
            {
                pressedHint = true;
                Console.SetCursorPosition(0, 0);
                for (i = 0; i < str.Length; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (map[i, j] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(end);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (map[i, j] == 1)
                        {
                            Console.Write(wall);
                        }
                        else if (map_sol[i, j] == 0)
                        {
                            Console.Write('*');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(player);
                Console.ForegroundColor = ConsoleColor.White;

            }

            if (!pressedHint)
            {
                Console.SetCursorPosition(0, 0);
                for (i = 0; i < str.Length; i++)
                {

                    for (j = 0; j < n; j++)
                    {

    
                        if (map[i, j] == 3)
                        {
                            indexX = i;
                            indexY = j;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(end);
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else if (map[i, j] == 2)
                        {

                            Console.Write(' ');

                        }
                        else if (map[i, j] == 1)
                        {
                            Console.Write(wall);
                        }
                        else if (map[i, j] == 0)
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(player);
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (((indexX == playerX) && (indexY == playerY)) || (key.KeyChar == 27))//Esc
            {
                if (key.KeyChar == 27)
                {
                    exit = true;
                }
                break;
            }
            Console.SetCursorPosition(playerY, playerX);
        }
        Console.SetCursorPosition(x, y += 2);
        Console.WriteLine();

        if (!pressedHint && !exit)
        {
            Console.WriteLine("Вы прошли лабиринт!");
        }
        else if (pressedHint)
        {
            Console.WriteLine("Попробуйте еще раз!");
        }
        else if (exit)
        {
            Console.WriteLine("Пока!");
        }
        Console.WriteLine($"Вы прошли {count} шагов!");

        Console.ReadKey(true);
        Console.ReadKey(true);
        Console.ReadKey(true);
        Console.ReadKey(true);
    }
}

