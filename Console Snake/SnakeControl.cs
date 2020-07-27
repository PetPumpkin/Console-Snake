using System;
using System.Collections.Generic;

public class SnakeControl
{
    private static int _snakeCurrentX;
    private static int _snakeCurrentY;

    public static int SnakeCurrentX { get => _snakeCurrentX; set => _snakeCurrentX = value; }
    public static int SnakeCurrentY { get => _snakeCurrentY; set => _snakeCurrentY = value; }

    public static List<Tail> tailPoints = new List<Tail>();

    public delegate void TailCollision();

    public static event TailCollision OnTailCollision;

    public static void SnakeSetup()
    {
        SnakeCurrentX = Board.BoardSizeX / 2;
        SnakeCurrentY = Board.BoardSizeY / 2;
    }

    public static void CheckCollisionWithPickup()
    {
        if (SnakeCurrentX == Pickup.positionX && SnakeCurrentY == Pickup.positionY)
        {
            tailPoints.Add(new Tail(SnakeCurrentY, SnakeCurrentX));
            Pickup.SpawnPickup();

            ScoreKeeper.Score++;
        }
    }

    public static void CheckCollisionWithTail()
    {
        for (int i = 0; i < tailPoints.Count - 1; i++)
        {
            if (SnakeCurrentX == tailPoints[i].X && SnakeCurrentY == tailPoints[i].Y)
            {
                OnTailCollision?.Invoke();
            }
        }
    }

    private static void UpdateTailPositions()
    {
        if (tailPoints.Count != 0)
        {
            for (int i = tailPoints.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    tailPoints[i].SetPosition(SnakeCurrentY, SnakeCurrentX);
                }
                else
                {
                    tailPoints[i].SetPosition(tailPoints[i - 1].Y, tailPoints[i - 1].X);
                }
            }
        }
    }

    public static void UpdateSnakePosition()
    {
        UpdateTailPositions();

        switch (Input.CurrentDirectionPressed)
        {
            case "up":
                SnakeCurrentY--;


                if (SnakeCurrentY < 0)
                {
                    SnakeCurrentY = Board.BoardSizeY - 1;
                }

                break;

            case "right":
                SnakeCurrentX++;

                if (SnakeCurrentX > Board.BoardSizeX - 1)
                {
                    SnakeCurrentX = 0;
                }
                break;

            case "down":
                SnakeCurrentY++;

                if (SnakeCurrentY > Board.BoardSizeY - 1)
                {
                    SnakeCurrentY = 0;
                }
                break;

            case "left":
                SnakeCurrentX--;

                if (SnakeCurrentX < 0)
                {
                    SnakeCurrentX = Board.BoardSizeX - 1;
                }
                break;

            default:
                break;
        }


    }


}