using System;

public class Pickup
{
    public static int positionX = 5;
    public static int positionY = 5;

    public static void SpawnPickup()
    {
        FindRandomPosition();

        if (positionY == SnakeControl.SnakeCurrentY && positionX == SnakeControl.SnakeCurrentX)
        {
            SpawnPickup();
            return;
        }

        for (int i = 0; i < SnakeControl.tailPoints.Count - 1; i++)
        {
            if (positionY == SnakeControl.tailPoints[i].Y && positionX == SnakeControl.tailPoints[i].X)
            {
                SpawnPickup();
                return;
            }
        }
    }

    private static void FindRandomPosition()
    {
        Random randomNum = new Random();
        positionX = randomNum.Next(0, Board.BoardSizeX - 1);
        positionY = randomNum.Next(0, Board.BoardSizeY - 1);
    }
}
