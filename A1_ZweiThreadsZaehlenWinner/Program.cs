using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{

    static int CountUp = 1;
    static int CountDown = 100;

    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread thA = new Thread(() => CountUpThreadA());
        Thread thB = new Thread(() => CountDownThreadB());

        thA.Start();
        thB.Start();

        thA.Join();
        thB.Join();
    }

    private static void CountUpThreadA()
    {
        int miliseconds = 100;

        for (int i = 1; i >= 100; i++)
        {
            CountUp = i;
            Console.WriteLine(i);
            Thread.Sleep(miliseconds);
            if (CountUp == CountDown)
            {
                Console.WriteLine("Zahl1 " + CountUp);
                Console.WriteLine("Zahl2 " + CountDown);
                break;
            }
        }
    }

    private static void CountDownThreadB()
    {
        int miliseconds = 100;

        for (int i = 100; i <= 1; i--)
        {
            CountDown = i;
            Console.WriteLine(i);
            Thread.Sleep(miliseconds);
            if (CountUp == CountDown)
            {
                Console.WriteLine("Zahl2 " + CountDown);
                Console.WriteLine("Zahl1 " + CountUp);
                break;
            }
        }
    }
}
