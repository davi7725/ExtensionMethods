using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static int ReverseDigits(this int value)
        {
            string valueString = value.ToString();
            string reversedValueString = "";
            for (int i = valueString.Length-1; i >= 0; i--)
            {
                reversedValueString = reversedValueString + valueString[i];
            }
            int reversedValue = int.Parse(reversedValueString);

            return reversedValue;
        }

        public static string OrderLetters(this string value)
        {
            bool isSorted = false;

            while(isSorted == false)
            {
                isSorted = true;
                for(int i = 0; i<value.Length-1; i++)
                {
                    int result = value[i].CompareTo(value[i + 1]);
                    if ( result >= 1)
                    {
                        string firstPart = value.Substring(0, i);
                        char first = value[i + 1];
                        char second = value[i];
                        string last = value.Substring(i +2);
                        string tmpString = firstPart + first + second + last;
                        isSorted = false;
                        value = tmpString;
                    }
                }
            }
            return value;
        }

        public static Dictionary<string, List<string>> Anagrams(this string value)
        {
            Dictionary<string, List<string>> finalDictionary = new Dictionary<string, List<string>>();

            List<string> anagramList = new List<string>();
            List<string> wordList = new List<string>();

            StreamReader sr = new StreamReader("WORD.txt");
            string line;
            while (sr.Peek() > 0)
            {
                line = sr.ReadLine();
                if(line.Length == value.Length)
                {
                    wordList.Add(line);
                }
            }

            sr.Close();

            foreach(string word in wordList)
            {
                if(word.OrderLetters() == value.OrderLetters())
                {
                    anagramList.Add(word); 
                }
            }

            finalDictionary.Add(value, anagramList);

            return finalDictionary;
        }

        public static IEnumerable<int> Quicksort(this IEnumerable<int> intCollection)
        {
            if(intCollection.Count() != 0)
            {
                intCollection = Quicksort(intCollection.ToArray(), 0, intCollection.Count() - 1);
            }

            return intCollection;
        }

        private static int[] Quicksort(int[] arrayOfNumbers, int left, int right)
        {
            int pivot = arrayOfNumbers[left + (right - left) / 2];
            int i = left;
            int j = right;
            while(i<= j)
            {
                while(arrayOfNumbers[i] < pivot)
                {
                    i++;
                }
                while(arrayOfNumbers[j]>pivot)
                {
                    j--;
                }
                if(i<=j)
                {
                    int temp = arrayOfNumbers[i];
                    arrayOfNumbers[i] = arrayOfNumbers[j];
                    arrayOfNumbers[j] = temp;
                    i++;
                    j--;
                }
            }
            if(left<j)
            {
                Quicksort(arrayOfNumbers, left, j);
            }
            if(i<right)
            {
                Quicksort(arrayOfNumbers, i, right);
            }
            return arrayOfNumbers;
        }
        

        /*public static bool BinarySearch(this IEnumerable<int> ints, Func<int,bool> boolFunc)
        {
            int[] arr = ints.ToArray(); 

            bool foundTheData = false;
            int startIndex = 0;
            int endIndex = arr.Length - 1;
            int distance = 1000;

            while (distance > 1 && foundTheData == false)
            {
                distance = endIndex - startIndex;
                int half = (distance / 2) + startIndex;


                if (arr[half] > boolFunc()
                {
                    endIndex = half;
                }
                else if (arr[half] < cm1.Nr)
                {
                    startIndex = distance / 2 + startIndex;
                }
                else
                {
                    foundTheData = true;
                }
            }
        }*/
    }
}
