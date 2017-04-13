using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProg = new Program();
            myProg.Run();
        }

        public void Run()
        {
            int x = 1234560;
            Console.WriteLine(x.ReverseDigits());

            string abc = "zyxwvutsrqponmlkjihgfedcba";
            Console.WriteLine(abc.OrderLetters());

            string word = "cinema";
            foreach(string s in word.Anagrams()["cinema"])
            {
                Console.WriteLine(s);
            }

            int[] numbersArray = { 2, 5, 8, 9, 1 };

            Console.WriteLine(numbersArray.Quicksort().First());

            Console.ReadKey();
        }        
    }
}
