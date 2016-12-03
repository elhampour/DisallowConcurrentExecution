using System;

namespace CoreJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Before Sleep" + DateTime.Now.ToString());
            System.Threading.Thread.Sleep(6000);
            Console.WriteLine("After Sleep" + DateTime.Now.ToString());
        }
    }
}
