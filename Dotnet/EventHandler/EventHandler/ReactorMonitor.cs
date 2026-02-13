using System;

class ReactorMonitor
{
    public ReactorMonitor(Reactor myReactor)
    {
        // Subscribe to the event
        myReactor.OnMeltdown +=
            new Reactor.MeltdownHandler(DisplayMessage);
    }

    public void DisplayMessage(object myReactor, MeltdownEventArgs myMEA)
    {
        Console.WriteLine(myMEA.Message);
    }
}
