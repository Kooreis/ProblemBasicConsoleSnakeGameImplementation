```C#
while (true)
{
    negativePoints++;

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo userInput = Console.ReadKey();
        if (userInput.Key == ConsoleKey.LeftArrow)
        {
            if (direction != right) direction = left;
        }
        if (userInput.Key == ConsoleKey.RightArrow)
        {
            if (direction != left) direction = right;
        }
        if (userInput.Key == ConsoleKey.UpArrow)
        {
            if (direction != down) direction = up;
        }
        if (userInput.Key == ConsoleKey.DownArrow)
        {
            if (direction != up) direction = down;
        }
    }

    Position snakeHead = snakeElements.Last();
    Position nextDirection = directions[direction];

    Position snakeNewHead = new Position(snakeHead.row + nextDirection.row,
        snakeHead.col + nextDirection.col);

    if (snakeNewHead.row < 0 ||
        snakeNewHead.col < 0 ||
        snakeNewHead.row >= Console.WindowHeight ||
        snakeNewHead.col >= Console.WindowWidth ||
        snakeElements.Contains(snakeNewHead) ||
        obstacles.Contains(snakeNewHead))
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Game over!");
        int userPoints = (snakeElements.Count - 6) * 100 - negativePoints;
        if (userPoints < 0) userPoints = 0;
        userPoints = Math.Max(userPoints, 0);
        Console.WriteLine("Your points are: {0}", userPoints);
        return;
    }

    snakeElements.Enqueue(snakeNewHead);
    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    if (direction == right) Console.Write("*");
    if (direction == left) Console.Write("*");
    if (direction == up) Console.Write("*");
    if (direction == down) Console.Write("*");
}
```