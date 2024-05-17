```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        byte right = 0;
        byte left = 1;
        byte down = 2;
        byte up = 3;
        int lastFoodTime = 0;
        int foodDisappearTime = 8000;
        int negativePoints = 0;

        Position[] directions = new Position[]
        {
            new Position(0, 1), // right
            new Position(0, -1), // left
            new Position(1, 0), // down
            new Position(-1, 0), // up
        };

        double sleepTime = 100;
        int direction = right;
        Random randomNumbersGenerator = new Random();
        Console.BufferHeight = Console.WindowHeight;

        List<Position> obstacles = new List<Position>()
        {
            new Position(12, 12),
            new Position(14, 20),
            new Position(7, 7),
            new Position(19, 19),
            new Position(6, 9),
        };

        foreach (Position obstacle in obstacles)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacle.col, obstacle.row);
            Console.Write("=");
        }

        Queue<Position> snakeElements = new Queue<Position>();
        for (int i = 0; i <= 5; i++)
        {
            snakeElements.Enqueue(new Position(0, i));
        }

        Position food;
        do
        {
            food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                randomNumbersGenerator.Next(0, Console.WindowWidth));
        }
        while (snakeElements.Contains(food) || obstacles.Contains(food));

        Console.SetCursorPosition(food.col, food.row);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("@");

        foreach (Position position in snakeElements)
        {
            Console.SetCursorPosition(position.col, position.row);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("*");
        }
    }

    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
```