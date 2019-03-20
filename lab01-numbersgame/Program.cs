using System;

namespace lab01_numbersgame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to my game! Lets do some math!");
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
                Console.WriteLine(convertedUserNumber);
                int[] inputArray = new int[convertedUserNumber];
                int[] populated = Populate(inputArray);
                int sum = GetSum(populated);
                GetProduct(populated, sum);
                //GetQuotient();

            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter your number as a number not a word");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int[] Populate(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                Console.WriteLine($"Please enter number {i+1} of {inputArray.Length} of your array.");
                string arrayNumber = Console.ReadLine();
                inputArray[i] = Convert.ToInt32(arrayNumber);
            }

            return inputArray;
        }

        static int GetSum(int[] createdArray)
        {
            int sum = 0;
            for (int i = 0; i < createdArray.Length; i++)
            {
                sum += createdArray[i];
            }
            if (sum < 20)
            {
                throw (new Exception($"Value of {sum} is too low."));
            }
            return sum;
        }

        static int GetProduct(int[] createdArray, int sum)
        {
            
            try
            {
                Console.WriteLine($"Please choose a number between 1 and {createdArray.Length+1}");
                string pickedIndex = Console.ReadLine();
                int parsedPickedIndex = Convert.ToInt32(pickedIndex) - 1;
                int product = sum * createdArray[parsedPickedIndex];
                return product;
            }
            catch (IndexOutOfRangeException m)
            {
                Console.WriteLine(m.Message);
                throw;
            }
        }

    }
}
