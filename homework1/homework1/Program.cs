using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App started!\n\n");

            /*StreamWriter input = new StreamWriter("C:/Users/luka/Desktop/input.txt");
            input.WriteLine("Ovaj tekst je samo primjer za ulaz. Sadrži samo dvije rečenice. Dodatak ovoj recenici u smislu novih rijeci sa samo nekoliko ili tocnije pet recenica dodatnih.");
            input.Flush();
            input.Close();           

            StreamWriter keyWords = new StreamWriter("C:/Users/luka/Desktop/keywords.txt");
            keyWords.WriteLine("je");
            keyWords.WriteLine("samo");
            keyWords.WriteLine("za");
            keyWords.WriteLine("pet");
            keyWords.Flush();
            keyWords.Close();
            */

            StreamWriter output = new StreamWriter("C:/Users/luka/Desktop/output.txt");

            StreamReader inputRead = new StreamReader("C:/Users/luka/Desktop/input.txt");
            StreamReader keyWordsRead = new StreamReader("C:/Users/luka/Desktop/keywords.txt");

            ArrayList inputArray = new ArrayList();
            ArrayList keyWordArray = new ArrayList();
            string line;

            while ((line = inputRead.ReadLine()) != null)
            {
                string[] charArray = line.Split(null);
                foreach (string ch in charArray)
                {
                    inputArray.Add(ch);
                }

            }

            Dictionary<string, int> deleteMap = new Dictionary<string, int>();

            while ((line = keyWordsRead.ReadLine()) != null)
            {
                string[] charArray = line.Split(null);
                foreach (string ch in charArray)
                {
                    deleteMap.Add(ch, 0);
                    keyWordArray.Add(ch);
                }
            }

            int deleteWordCounter = 0;
            string stringForInput = "";

            foreach (string inputLine in inputArray)
            {
                if (keyWordArray.IndexOf(inputLine) == -1)
                {
                    if (inputLine.Contains("."))
                    {
                        stringForInput += inputLine + "\n";
                    }
                    else
                    {
                        stringForInput += inputLine + " ";
                    }
                }
                else
                {
                    deleteMap[inputLine]++;
                    deleteWordCounter++;
                }
            }

            output.WriteLine(stringForInput);
            output.Flush();
            output.Close();

            string outputString = "Broj obrisanih rijeci je " + deleteWordCounter + " (";

            foreach (KeyValuePair<string, int> entry in deleteMap)
            {
                outputString += " " + entry.Value + "x=" + entry.Key;
            }

            outputString += " )";

            Console.WriteLine(outputString);
            Console.WriteLine("\n\nApp finished! Press any key to continue...");
            Console.ReadKey();
        }
    }
}
