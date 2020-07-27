using System;

public static class Draw
{
    private const string snakeString = " o ";
    private const string tailString = " + ";
    private const string pickupString = " @ ";
    private const string gridString = " . ";

    public static void ClearBoard()
    {
        for (int i = 0; i < Board.BoardSizeY; i++)
        {
            for (int j = 0; j < Board.BoardSizeX; j++)
            {
                Board.boardArray[i, j] = gridString;
            }
        }
    }

    public static void DrawSnakeHead()
    {
        Board.boardArray[SnakeControl.SnakeCurrentY, SnakeControl.SnakeCurrentX] = snakeString;
    }

    private static void DrawSnakeTail()
    {
        for (int i = 0; i < SnakeControl.tailPoints.Count; i++)
        {
            Board.boardArray[SnakeControl.tailPoints[i].Y, SnakeControl.tailPoints[i].X] = tailString;
        }
    }

    private static void DrawPickup()
    {
        Board.boardArray[Pickup.positionY, Pickup.positionX] = pickupString;
    }

    public static void DrawTitle()
    {
        LineBreak();

        WriteAndColor("SNAKE: ", ConsoleColor.Green);

        VerticalLine();
        WriteAndColor("Best: ", ConsoleColor.DarkMagenta);
        WriteAndColor(ScoreKeeper.Best.ToString(), ConsoleColor.Green);

        VerticalLine();
        WriteAndColor("Score: ", ConsoleColor.DarkMagenta);
        WriteAndColor(ScoreKeeper.Score.ToString(), ConsoleColor.Green);

        LineBreak(2);
    }

    public static void DrawPreGameInstructions()
    {
        LineBreak();

        WriteAndColor("Play: ", ConsoleColor.Green);
        WriteAndColor("P", ConsoleColor.Yellow);

        VerticalLine();

        WriteAndColor("Quit: ", ConsoleColor.Green);
        WriteAndColor("Q", ConsoleColor.Yellow);

        LineBreak();

        WriteAndColor("Easy: ", ConsoleColor.Green);
        WriteAndColor("1", ConsoleColor.Yellow);

        VerticalLine();
        WriteAndColor("Medium: ", ConsoleColor.Green);
        WriteAndColor("2", ConsoleColor.Yellow);

        VerticalLine();
        WriteAndColor("Hard: ", ConsoleColor.Green);
        WriteAndColor("3", ConsoleColor.Yellow);

        LineBreak();
    }

    public static void DrawInGameInstructions()
    {
        LineBreak();

        WriteAndColor("Up: ", ConsoleColor.Green);
        WriteAndColor("W", ConsoleColor.Yellow);

        VerticalLine();
        WriteAndColor("Right: ", ConsoleColor.Green);
        WriteAndColor("D", ConsoleColor.Yellow);

        VerticalLine();
        WriteAndColor("Down: ", ConsoleColor.Green);
        WriteAndColor("S", ConsoleColor.Yellow);

        VerticalLine();
        WriteAndColor("Left: ", ConsoleColor.Green);
        WriteAndColor("A", ConsoleColor.Yellow);

        LineBreak();

        WriteAndColor("QUIT: ", ConsoleColor.Green);
        WriteAndColor("Q", ConsoleColor.Yellow);

        LineBreak();
    }

    public static void DrawBoard()
    {
        Console.Clear();

        DrawTitle();

        ClearBoard();

        DrawSnakeTail();
        DrawPickup();
        DrawSnakeHead();

        for (int i = 0; i < Board.BoardSizeY; i++)
        {
            for (int j = 0; j < Board.BoardSizeX; j++)
            {
                WriteAndColor(Board.boardArray[i, j], ConsoleColor.DarkGreen);
            }
            Console.Write("\n");
        }

        Input.InputLock = false;

        if (Input.GameRunning)
        {
            DrawInGameInstructions();
        }
        else
        {
            DrawPreGameInstructions();
        }
    }

    private static void WriteAndColor(string text, ConsoleColor color)
    {
        //switch statement handles colouring of symbols
        switch (text)
        {
            case pickupString:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case gridString:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case tailString:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case snakeString:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            default:
                Console.ForegroundColor = color;
                break;
        }

        Console.Write(text);
        Console.ResetColor();
    }

    private static void VerticalLine()
    {
        WriteAndColor(" | ", ConsoleColor.White);
    }

    private static void LineBreak(int numberOfLineBreaks = 1)
    {
        for (int i = 0; i < numberOfLineBreaks; i++)
        {
            Console.Write("\n");
        }
    }
}

