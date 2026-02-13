using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Exercise 1");
        int N = 7;
        for (int i = 0; i < N; i++)
        {
            int runs = i * (i + 1) * (i + 2);
            Console.Write(runs + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Exercise 2");
        double ra = 10, xa = 0, ya = 0;
        double rb = 5, xb = 2, yb = 2;

        double d = Math.Sqrt((xa - xb) * (xa - xb) + (ya - yb) * (ya - yb));

        if (d + rb < ra)
            Console.WriteLine("B is in A");
        else if (d + ra < rb)
            Console.WriteLine("A is in B");
        else if (d < ra + rb)
            Console.WriteLine("A and B intersect");
        else
            Console.WriteLine("A and B do not intersect");

        Console.WriteLine("Exercise 3");
        double basicSalary = 18000;

        double hra = basicSalary * 0.20;
        double da = basicSalary * 0.10;
        double pf = 0;

        if (basicSalary >= 15000)
            pf = basicSalary * 0.12;

        double netSalary = basicSalary + hra + da - pf;
        Console.WriteLine(netSalary);

        Console.WriteLine("Exercise 4");
        int previousReading = 300;
        int currentReading = 800;
        string connectionType = "Domestic";

        int units = currentReading - previousReading;
        double bill = 0;

        if (units <= 100)
            bill = units * 1.5;
        else if (units <= 250)
            bill = 100 * 1.5 + (units - 100) * 2.5;
        else if (units <= 550)
            bill = 100 * 1.5 + 150 * 2.5 + (units - 250) * 4.5;
        else
            bill = 100 * 1.5 + 150 * 2.5 + 300 * 4.5 + (units - 550) * 7.5;

        if (connectionType == "Industrial")
            bill += 2500;
        else if (connectionType == "Business")
            bill += 1500;
        else if (connectionType == "Domestic")
            bill += 1000;

        Console.WriteLine(bill);

        Console.WriteLine("Exercise 5");
        int weight = 68;

        if (weight < 0 || weight > 120)
            Console.WriteLine("Invalid Input");
        else if (weight <= 48)
            Console.WriteLine("light fly");
        else if (weight <= 51)
            Console.WriteLine("fly");
        else if (weight <= 54)
            Console.WriteLine("bantam");
        else if (weight <= 57)
            Console.WriteLine("feather");
        else if (weight <= 60)
            Console.WriteLine("light");
        else if (weight <= 64)
            Console.WriteLine("light welter");
        else if (weight <= 69)
            Console.WriteLine("welter");
        else if (weight <= 75)
            Console.WriteLine("light middle");
        else if (weight <= 81)
            Console.WriteLine("middle");
        else if (weight <= 91)
            Console.WriteLine("light heavy");
        else
            Console.WriteLine("heavy");
    }
}
