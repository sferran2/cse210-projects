using System;

class Program
{
    static void Main(string[] args)
    {
    
        int x = int.Parse(percentageFromUser);
        string letter = "";
        string sign = ""; 
        

        if ( x >= 90)
        {
            letter = "A";
        }

        else if ( x>=80)
        {
           letter = "B";
        }
        else if ( x>=70)
        {
           letter = "C";
        }
        else if ( x>=60)
        {
           letter = "D"; 
        }
        else if (x<60)
        {
           letter = "F"; 
        }

        int lastDigit = x % 10; 

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = ""; 
        }

       
        if (letter == "A" && sign == "+")
        {
            sign = ""; 
        }
        else if (letter == "F")
        {
            sign = "";
        }
   

        Console.WriteLine($"Your grade is: {letter}{sign}");
        
  
      if (x >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard, and you'll do better next time!");
        }

    }
}