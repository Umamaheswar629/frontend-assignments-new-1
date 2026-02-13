using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict
{
    public class EmpDict
    {
        Dictionary<int, Emp> Empdic = new Dictionary<int, Emp>();
        public void AddEmp(Emp emp)
        {
            Empdic.Add(emp.EmpId, emp);
        }
        //Indexer
        public Emp this[int id]
        {
            get { return Empdic[id]; }
            set { Empdic[id] = value; }
        }
        public void Display()
        {
            foreach (var item in Empdic)
            {
                Console.WriteLine(item.Value); //tostring is automatically called
            }
        }
    }
}