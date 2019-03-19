using System;

namespace lab01_numbersgame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
            finally
            {
                Console.WriteLine("The program has successfully completed");
            }
        }
        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Please enter a number greater than zero(as a digit, not a word): ");
                string userNumber = Console.ReadLine();
                int convertedUserNumber = Convert.ToInt32(userNumber);
                int[] array = new int[convertedUserNumber];

            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter your number as a number not a word");
            }
        }
        

    }
}
