using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//fieds and properties
//zero arg constructers
//parameterized 
// override the string for To String for formating
namespace OopsDemo
{
    internal class Emp
    {
        public int EmpId { get; set; } //auto implemted property
        //public string EmpName { get; set; }
        //public double EmpSalary { get; set; }

        //Above declearation of variables is not good way of declaring
        // use propsfull to private as well as accessible
        private decimal bal;

        public decimal Bal
        {
            get { return bal; } //Reading the value;
            /* supoose it is an atm the assign if blance is not possible so make set private kind  basically it is  called partial access*/
            //set { bal = value; } //Writing the value;
        }
        private string empName;

        const int MaxNameLength = 10;

        public string EmpName
        {
            get => empName;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(EmpName));
                if (value.Length > MaxNameLength)
                    throw new ArgumentOutOfRangeException(nameof(EmpName), $"Maximum length is {MaxNameLength}.");
                empName = value;
            }
        }
        private decimal empSalary;

        public decimal EmpSalary
        {

            get { return empSalary; }
            set { empSalary = value; }
        }


        //construter
        public Emp()
        {

        }
       
        public Emp(int empid,string name,decimal salary)
        {
            EmpId = empid;
            EmpName = name;
            EmpSalary = salary;
        }
        public override string ToString()
        {
                string res=string .Empty;
            res = $"Emp Id: {EmpId}, Emp Name: {EmpName}, Emp Salary: {EmpSalary}";
            return res ;
        }
    }
}

