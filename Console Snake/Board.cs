using System;

public class Board
{
    static int _boardSizeX;

    static int _boardSizeY;

    public static string[,] boardArray;

    public static int BoardSizeX { get => _boardSizeX; set => _boardSizeX = value; }
    public static int BoardSizeY { get => _boardSizeY; set => _boardSizeY = value; }

    public static void SetBoardSize(int size)
    {
        BoardSizeX = size;
        BoardSizeY = size;

        boardArray = new string[BoardSizeY, BoardSizeX];

        Draw.ClearBoard();
    }
}
