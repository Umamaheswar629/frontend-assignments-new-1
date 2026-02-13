namespace oopsDemo_Comparable_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Emp> emplist = new List<Emp>
            { new Emp{EmpId=101,EmpName="uma",EmpDept="IT",EmpSalary=90800},
            new Emp{EmpId=102,EmpName="uma",EmpDept="TECH",EmpSalary=90800},
            new Emp{EmpId=103,EmpName="papiredy",EmpDept="IT",EmpSalary=92800000 }
            };
            foreach (Emp emp in emplist)
            {
                Console.WriteLine(emp);
            }
            if (emplist[0].Equals(emplist[1])){
                Console.WriteLine("same");
            }
            else
            {
                Console.WriteLine("not same");
            }
            //sorting
            Console.WriteLine("After Sorting");
            emplist.Sort();
            foreach (Emp emp in emplist)
            {
                Console.WriteLine(emp);
            }
            //sorting via dept
            emplist.Sort(new Class1());
            Console.WriteLine("Deptment sorting");
            foreach (Emp emp in emplist)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
