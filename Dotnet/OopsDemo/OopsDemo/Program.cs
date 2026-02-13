namespace OopsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Emp e1= new Emp();
            Emp e2= new Emp(102,"raju",455000.78m);
            Console.WriteLine(e2);
          //  e1.Bal = 1000;
            Console.WriteLine(e1.Bal);
            e1.EmpName = "uma";
            Console.WriteLine(e1.EmpName);
            e1.EmpSalary = 3000.99m;
            Console.WriteLine(e1.EmpSalary);

        }
        

    }
}
