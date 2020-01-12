using System;

namespace Problem4.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] contacts = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < contacts.Length; i++)
            {
                Console.WriteLine(smartphone.Call(contacts[i]));
            }

            for (int i = 0; i < sites.Length; i++)
            {
                Console.WriteLine(smartphone.Browse(sites[i]));
            }
        }
    }
}
