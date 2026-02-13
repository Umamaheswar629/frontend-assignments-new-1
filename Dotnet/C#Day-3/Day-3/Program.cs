using System.Data;

namespace Day_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            TryToParse(null);
            TryToParse("1233");
            TryToParse("348.0");
            Console.WriteLine($"{2.5:C}");
            string name = "uma";
            int age = 21;
            double marks = 89.5;
            string res = String.Format("Name:{0},Age{1},Marks {2}", name, age, marks);
            Console.WriteLine(res);
            int[][] arr = new int[3][];
            arr[0] = new int[] { 1, 2 };
            arr[1] = new int[] { 3, 4, 5 };
            arr[2]=new int [] { 5};
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine(arr[i][j]+" ");
                }
                Console.WriteLine();
            }
            int[] arr2 = { 5, 2, 9, 1, 7 };

            Array.Sort(arr2);
            Console.WriteLine("Sorted:");
            foreach (int i in arr2)
                Console.Write(i + " ");

            Console.WriteLine();

            Array.Reverse(arr);
            Console.WriteLine("Reversed:");
            foreach (int i in arr2)
                Console.Write(i + " ");

            Console.WriteLine();

            int index = Array.IndexOf(arr2, 5);
            Console.WriteLine("Index of 5: " + index);

            int length = arr2.Length;
            Console.WriteLine("Length: " + length);
        }

        public static void TryToParse(string value)
        {
            int num;
            bool res = Int32.TryParse(value, out num);
            if (res)
            {   
                Console.WriteLine("converted {0} to {1}.", value, num);
            }
            else
            {
                if (value == null) value = "null";
                Console.WriteLine("attempted failed.", value);
            }
        }
    }
}
