using System;
using System.Collections.Generic;
using System.Linq;

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
            
            Console.WriteLine("Guess the four digit number combination - You have 10 attempts\n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Attempt - {0}\n", i + 1);
                String userInput = Console.ReadLine();

                List<int> userCombination = userInput.ToCharArray()
                    .Where(n => char.IsNumber(n))
                    .Select(n => int.Parse(n.ToString()))
                    .ToList();


                if (userCombination.Count != 4)
                {
                    Console.WriteLine("\nInvalid input. Please enter four digit number only !!!!\n");
                }
                else
                {
                    int plusResult = 0;
                    int minusResult = 0;

                    for (int j = 0; j < userCombination.Count; j++)
                    {
                        if (computerGeneratedCombination.Contains(userCombination[j]))
                        {
                            if (computerGeneratedCombination[j] == userCombination[j])
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
                
                    Console.WriteLine("\nTry Again\n");
                }
                if (i == 9) // If user reach here and the attempts are 10. User should not be allowed to continue
                {
                    Console.WriteLine("\nYou Lost!!!!\n");
                    break;
                }
            }
            Console.Read();
        }
    }
}
