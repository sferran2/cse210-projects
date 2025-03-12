using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int userNumber = -1;
        
        while (userNumber !=0)
        {
            Console.Write("Enter a numbers (type O when finished):  ");

            string userRespond = Console.ReadLine();
            userNumber = int.Parse(userRespond);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }   
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        double average = 0;
        if (numbers.Count > 0)
        {
            average = (double)sum/ numbers.Count;
        }

        int maxNumber = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > maxNumber)
            {
                maxNumber = number;
            }
        }

        int? smallestPositive = null;
        foreach (int number in numbers)
        {
            if (number >0)
            {
                if (smallestPositive == null || number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }

        numbers.Sort();

        Console.WriteLine($"The sum of the numbers is: {sum}");
        Console.WriteLine($"The average of the numbers is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        Console.WriteLine("The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
    