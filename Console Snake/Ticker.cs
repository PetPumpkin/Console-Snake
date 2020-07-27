using System;
using System.Timers;

public static class Ticker
{
    private static Timer aTimer;

    public delegate void Tick();

    public static event Tick OnTick;

    private static double timerInterval = 500;

    public static double TimerInterval { get => timerInterval; set => timerInterval = value; }

    public static void StartTicker()
    {
        aTimer = new Timer(TimerInterval);

        aTimer.Elapsed += OnTimerTick;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    static void OnTimerTick(Object source, ElapsedEventArgs e)
    {
        OnTick();
    }

    public static void StopTicker()
    {
        aTimer.Elapsed -= OnTimerTick;
        aTimer.Enabled = false;
        aTimer.Stop();
        aTimer.Dispose();
    }
}
