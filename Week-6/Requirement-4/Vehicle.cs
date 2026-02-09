using System;
using System.Globalization;

namespace Requirement_4
{
    public class Vehicle
    {
        private string registrationNo;
        private string name;
        private string type;
        private double weight;
        private Ticket ticket;

        public string RegistrationNo { get => registrationNo; set => registrationNo = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public double Weight { get => weight; set => weight = value; }
        public Ticket Ticket { get => ticket; set => ticket = value; }

        public Vehicle() { }

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            this.registrationNo = registrationNo;
            this.name = name;
            this.type = type;
            this.weight = weight;
            this.ticket = ticket;
        }

        public static Vehicle CreateVehicle(string detail)
        {
            string[] data = detail.Split(',');

            string regNo = data[0];
            string name = data[1];
            string type = data[2];
            double weight = double.Parse(data[3]);

            string ticketNo = data[4];
            DateTime parkedTime = DateTime.ParseExact(
                data[5],
                "dd-MM-yyyy HH:mm:ss",
                CultureInfo.InvariantCulture
            );
            double cost = double.Parse(data[6]);

            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);
            return new Vehicle(regNo, name, type, weight, ticket);
        }
    }
}
