using System;

public class Game
{
    public static void PreGame()
    {
        Console.Clear();
        Draw.DrawTitle();
        Draw.DrawPreGameInstructions();

        Input.GameRunning = false;
        Input.WaitForInput();


    }

    public static void BeginGame()
    {
        //Clean up screen and game settings if a previous game was played
        Console.Clear();
        Input.GameRunning = true;

        Ticker.StartTicker();

        ScoreKeeper.Score = 0;

        if (SnakeControl.tailPoints.Count > 0)
        {
            SnakeControl.tailPoints.RemoveRange(0, SnakeControl.tailPoints.Count - 1);
        }
        Input.CurrentDirectionPressed = "none";

        //Set up game settings

        Board.SetBoardSize(10);

        Pickup.SpawnPickup();

        SnakeControl.SnakeSetup();

        Ticker.OnTick += UpdateBoard;

        SnakeControl.OnTailCollision += EndGame;
    }

    static void UpdateBoard()
    {
        SnakeControl.UpdateSnakePosition();
        SnakeControl.CheckCollisionWithTail();
        SnakeControl.CheckCollisionWithPickup();

        Draw.DrawBoard();
    }

    private static void EndGame()
    {
        Input.GameRunning = false;

        Ticker.StopTicker();

        Ticker.OnTick -= UpdateBoard;
        SnakeControl.OnTailCollision -= EndGame;
    }

    public static void QuitGame()
    {
        SaveLoadScore.SaveScore();
        Environment.Exit(0);
    }
}
