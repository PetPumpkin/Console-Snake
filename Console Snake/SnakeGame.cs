using System;
using System.Timers;

namespace SnakeGame
{
    public class SnakeGame
    {
        public static void Main(string[] args)
        {
            SaveLoadScore.LoadScore();

            Game.PreGame();
        }
    }
}