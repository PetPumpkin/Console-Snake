using System.IO;
using System;

public static class SaveLoadScore
{

    private static string path = @"sc.ore";

    public static void SaveScore()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(ScoreKeeper.Best.ToString());
        }
    }

    public static void LoadScore()
    {
        if (File.Exists(path))
        {
            ScoreKeeper.Best = Int32.Parse(File.ReadAllText(path));
        }
    }
}