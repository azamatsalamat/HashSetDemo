namespace HashSetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("Azamat");
            set.Add("Salamat");
            set.Add("Acer Nitro 5");

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}