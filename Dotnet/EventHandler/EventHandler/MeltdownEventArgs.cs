using System;

class MeltdownEventArgs : EventArgs
{
    private string message;

    public MeltdownEventArgs(string message)
    {
        this.message = message;
    }

    public string Message
    {
        get
        {
            return message;
        }
    }
}
