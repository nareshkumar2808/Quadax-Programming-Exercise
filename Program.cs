using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> computerGeneratedCombination = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                computerGeneratedCombination.Add(random.Next(1, 7));
            }
            Console.WriteLine("Computer Generated Number - XXXX\n");
            Console.WriteLine(string.Join(";",computerGeneratedCombination));

            Console.WriteLine("Guess the combination - You have 10 attempts\n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Attempt - {0}\n", i + 1);
                String userInput = Console.ReadLine();
                List<char> userChar = new List<char>();
                userChar.AddRange(userInput);
                List<int> userCombination = userChar.ConvertAll(n => int.Parse(n.ToString()));

                int plusResult = 0;
                int minusResult = 0;

                for (int j = 0; j < userCombination.Count; j++)
                {
                    if (computerGeneratedCombination.Contains(userCombination[j]))
                    {
                        if (j < 4 && computerGeneratedCombination[j] == userCombination[j])
                        {
                            plusResult++;
                        }
                        else
                        {
                            minusResult++;
                        }
                    }
                }
                while (plusResult > 0)
                {
                    Console.Write("+");
                    plusResult--;
                }
                while (minusResult > 0)
                {
                    Console.Write("-");
                    minusResult--;
                }
                if (computerGeneratedCombination.SequenceEqual(userCombination))
                {
                    Console.WriteLine("\nYou Won!!!!\n");
                    break;
                }
                if (i == 9)
                {
                    Console.WriteLine("\nYou Lost!!!!\n");
                    break;
                }
                Console.WriteLine("\nTry Again\n");
            }
            Console.Read();
        }
    }
}
