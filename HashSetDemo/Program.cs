namespace HashSetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>() { "ASUS", "Lenovo", "ASUS", "Acer" };
            set.Add("Acer");
            set.Add("HP");

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            set.Remove("ASUS");

            Console.WriteLine("After deleting ASUS: ");
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}