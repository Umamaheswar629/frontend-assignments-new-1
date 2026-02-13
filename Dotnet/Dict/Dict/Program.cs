namespace Dict
{
    public class Program
    {
        static void Main(string[] args)
        {
            Emp e1 = new Emp(1, "ravi", 30000);
            Emp e2 = new Emp(2, "raju", 340000);
            EmpDict dict=new EmpDict();
            dict.AddEmp(e1);
             dict.AddEmp(e2);
            dict.Display();

        }
    }
}
