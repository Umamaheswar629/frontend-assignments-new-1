using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        Reactor myReactor = new Reactor();
        ReactorMonitor myReactorMonitor =
            new ReactorMonitor(myReactor);

        Console.WriteLine("Setting reactor temperature to 100 degrees Centigrade");
        myReactor.Temperature = 100;

        Console.WriteLine("Setting reactor temperature to 500 degrees Centigrade");
        myReactor.Temperature = 500;

        Console.WriteLine("Setting reactor temperature to 2000 degrees Centigrade");
        myReactor.Temperature = 2000;

        Console.ReadLine();
    }
}
