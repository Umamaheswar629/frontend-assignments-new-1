namespace Dict
{
   public class Emp
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public Emp()
        {

        }
        public Emp(int empId, string empName, double salary)
        {
            EmpId = empId;
            EmpName = empName;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"EmpId:{EmpId},name:{EmpName},Salary:{Salary}";
        }
    }
}