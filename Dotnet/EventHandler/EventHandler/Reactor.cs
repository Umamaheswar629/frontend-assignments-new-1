using System;

class Reactor
{
    private int temperature;

    // Step 1: Delegate
    public delegate void MeltdownHandler(object reactor, MeltdownEventArgs myMEA);

    // Step 2: Event
    public event MeltdownHandler OnMeltdown;

    public int Temperature
    {
        set
        {
            temperature = value;

            if (temperature > 1000)
            {
                MeltdownEventArgs myMEA =
                    new MeltdownEventArgs("Reactor meltdown in progress!");

                // Step 3: Raise the event
                if (OnMeltdown != null)
                {
                    OnMeltdown(this, myMEA);
                }
            }
        }
    }
}
