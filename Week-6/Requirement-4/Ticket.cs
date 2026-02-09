using System;

namespace Requirement_4
{
    public class Ticket
    {
        private string ticketNo;
        private DateTime parkedTime;
        private double cost;

        public string TicketNo { get => ticketNo; set => ticketNo = value; }
        public DateTime ParkedTime { get => parkedTime; set => parkedTime = value; }
        public double Cost { get => cost; set => cost = value; }

        public Ticket() { }

        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            this.ticketNo = ticketNo;
            this.parkedTime = parkedTime;
            this.cost = cost;
        }
    }
}

