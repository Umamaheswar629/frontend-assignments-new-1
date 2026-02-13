using System.Collections;

namespace oppsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // in arraylist we dont provide any templete called non genric 
            ArrayList mylist = new ArrayList();
            mylist.Add(1);
            mylist.Add("uma");
            mylist.Add(3.13);
            mylist.Add(true);

            foreach (var i in mylist)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("genric Counterpart");
            //in list we provide the templete which datatype must be used called generic
            List<int> num=new List<int>();
            List<int> numbers = new List<int> { 12, 13, 146, 6 };
            Console.WriteLine("List of intergers");
            foreach(int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("After Sort");
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            numbers.Sort();

            num.Add(1);
            num.Add(4);
            foreach (int i in num)
            {
                Console.WriteLine(i);
            }
        }
    }
}