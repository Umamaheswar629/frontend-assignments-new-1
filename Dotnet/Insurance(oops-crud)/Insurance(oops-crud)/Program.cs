using Insurance_oops_crud_;

namespace InsuranceSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<insurance> policies = new List<insurance>();

            while (true)
            {
                Console.WriteLine("\n--- Insurance Policy System ---");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. Display Policies");
                Console.WriteLine("3. Sort Policies");
                Console.WriteLine("4. Search Policy");
                Console.WriteLine("5. Binary Search by PolicyId");
                Console.WriteLine("6. Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddPolicy(policies); break;
                    case 2: DisplayPolicies(policies); break;
                    case 3: SortPolicies(policies); break;
                    case 4: SearchPolicies(policies); break;
                    case 5: BinarySearchPolicy(policies); break;
                    case 6: return;
                }
            }
        }
        static void AddPolicy(List<insurance> policies)
        {
            insurance  p= new insurance();
            Console.WriteLine("policy Id:");
            p.PolicyId=int.Parse(Console.ReadLine());
            Console.WriteLine("Holder Name");
            p.PolicyHolderName=Console.ReadLine();
            Console.Write("Policy Type: ");
            p.PolicyType = Console.ReadLine();
            Console.Write("Premium Amount: ");
            p.PremiumAmount = decimal.Parse(Console.ReadLine());
            policies.Add(p);
            Console.WriteLine("policy is added");
        }
        static void DisplayPolicies(List<insurance> policies) {
            Console.WriteLine("\nID    Name            Type       Premium");
            

    }
}