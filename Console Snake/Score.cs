public static class ScoreKeeper
{
    static int score;
    static int best;

    public static int Score { get => score; set => SetAndCompareScore(value); }
    public static int Best { get => best; set => best = value; }

    private static void SetAndCompareScore(int value)
    {
        score = value;

        if (value > Best)
        {
            Best = value;
        }
    }
}