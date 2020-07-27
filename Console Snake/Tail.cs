public class Tail
{
    int _x;
    int _y;

    public int X { get => _x; set => _x = value; }
    public int Y { get => _y; set => _y = value; }

    public Tail(int y, int x)
    {
        SetPosition(y, x);
    }

    public void SetPosition(int y, int x)
    {
        Y = y;
        X = x;
    }
}
