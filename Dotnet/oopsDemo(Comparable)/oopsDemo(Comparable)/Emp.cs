using System.ComponentModel;

namespace oopsDemo_Comparable_
{
    public class Emp:IComparable<Emp>
    {
        private int empid;
        public int EmpId
        {
            get { return empid; }
            set { empid = value; }
        }

        private string empName;
        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        private string empDept;
        public string EmpDept
        {
            get { return empDept; }
            set { empDept = value; }
        }

        private decimal empSalary;
        public decimal EmpSalary
        {
            get { return empSalary; }
            set { empSalary = value; }
        }

        public Emp() { }

        public Emp(int empid, string empName, string empDept, decimal empSalary)
        {
            EmpId = empid;
            EmpName = empName;
            EmpDept = empDept;
            EmpSalary = empSalary;
        }
        public override string ToString() =>
      $"EmpId: {EmpId}, EmpName: {EmpName}, EmpDept: {EmpDept}, EmpSalary: {EmpSalary}";
       public override bool Equals(object? obj)
        {
            Emp e = obj as Emp;
            return this.EmpId.Equals(e.EmpId);
        }

        public int CompareTo(Emp? other)
        {
            return this.EmpId.CompareTo(other.EmpId);
        }

    }
}

