using System;

public static class Input
{
    private static bool gameRunning = false;

    public static bool GameRunning { get => gameRunning; set => gameRunning = value; }

    private static string currentDirectionPressed = "none";

    private static bool inputLock;

    public static string CurrentDirectionPressed { get => currentDirectionPressed; set => currentDirectionPressed = value; }
    public static bool InputLock { get => inputLock; set => inputLock = value; }


    public static void WaitForInput()
    {
        while (true)
        {
            while (!GameRunning)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(false);

                switch (keyPressed.Key)
                {
                    case ConsoleKey.P:
                        Game.BeginGame();
                        break;
                    case ConsoleKey.Q:
                        Game.QuitGame();
                        break;
                    case ConsoleKey.D1:
                        Ticker.TimerInterval = 500;
                        break;
                    case ConsoleKey.D2:
                        Ticker.TimerInterval = 250;
                        break;
                    case ConsoleKey.D3:
                        Ticker.TimerInterval = 100;
                        break;
                }
            }


            while (GameRunning)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(false);

                if (!InputLock)
                {
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.W:
                            if (CurrentDirectionPressed != "down")
                            {
                                CurrentDirectionPressed = "up";
                                inputLock = true;
                            }
                            break;
                        case ConsoleKey.D:
                            if (CurrentDirectionPressed != "left")
                            {
                                CurrentDirectionPressed = "right";
                                inputLock = true;
                            }

                            break;
                        case ConsoleKey.S:
                            if (CurrentDirectionPressed != "up")
                            {
                                CurrentDirectionPressed = "down";
                                inputLock = true;
                            }

                            break;
                        case ConsoleKey.A:
                            if (CurrentDirectionPressed != "right")
                            {
                                CurrentDirectionPressed = "left";
                                inputLock = true;
                            }
                            break;
                        case ConsoleKey.Q:
                            Game.QuitGame();
                            break;
                        case ConsoleKey.P:
                            if (!GameRunning)
                            {
                                Game.BeginGame();
                            }
                            break;
                    }
                }
            }
        }
    }
}
