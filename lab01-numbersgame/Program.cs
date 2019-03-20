using System;

namespace lab01_numbersgame
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Here we are creating a try block to call our first method.
            try
            {
                Console.WriteLine("Welcome to my game! Lets do some math!");
                StartSequence();
            }
            //This is a catch block, any exceptions will output the below information.
            catch (Exception e)
            {

                Console.WriteLine("There was an error");
                Console.WriteLine(e.Message);
            }
            //This finally block runs after the try and catch.
            finally
            {
                Console.WriteLine("The program has successfully completed");
            }
        }
        /// <summary>
        /// Start sequence prompts the user for input and calls all of our following methods.
        /// </summary>
        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Please enter a number greater than zero(as a digit, not a word): ");
                string userNumber = Console.ReadLine();
                int convertedUserNumber = Convert.ToInt32(userNumber);
                //We are setting all the called methods to variables so we can use the returns in our Console.WriteLines
                int[] inputArray = new int[convertedUserNumber];
                int[] populated = Populate(inputArray);
                int sum = GetSum(populated);
                int product = GetProduct(populated, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine($"Your array size is {convertedUserNumber}");
                Console.WriteLine($"the numbers in your array are{string.Join(", ", populated)}.");
                Console.WriteLine($"The sum of the array is {sum}.");
                int mult = product / sum;
                Console.WriteLine($"{mult} * {sum} = {product}");
                decimal dividend = product / quotient;
                Console.WriteLine($"{product} / {dividend} = {quotient}");


            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter your number as a number not a word.");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// This method populates our array that was created in the StartSequence method. The user defined the length and here the user is defining what is at each index.
        /// </summary>
        /// <param name="inputArray">This is the array created by the user</param>
        /// <returns>A populated array of a length defined by the user, then filled by the user</returns>
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
        /// <summary>
        /// Here we are adding all the items in the array together.
        /// </summary>
        /// <param name="createdArray">User defined and filled array from Populate();</param>
        /// <returns>an int that is the sum of all array elements</returns>
        static int GetSum(int[] createdArray)
        {
            int sum = 0;
            for (int i = 0; i < createdArray.Length; i++)
            {
                sum += createdArray[i];
            }
            //here we are creating a new exception that will, when thrown, bubble up to the main method.
            if (sum <= 20)
            {
                throw (new Exception($"Value of {sum} is too low."));
            }
            return sum;
        }
        /// <summary>
        /// Here the user chooses a number between 1 and the lenth of the array. This number-1 is the index of the number used to multiply with the sum received from the previous method. 
        /// </summary>
        /// <param name="createdArray">User defined and filled array from Populate();</param>
        /// <param name="sum">The sum received from GetSum();</param>
        /// <returns>The product of the indexed number and the sum received from the previous method</returns>
        static int GetProduct(int[] createdArray, int sum)
        {
            
            try
            {
                Console.WriteLine($"Please choose a number between 1 and {createdArray.Length}:");
                string pickedIndex = Console.ReadLine();
                int parsedPickedIndex = Convert.ToInt32(pickedIndex) - 1;
                int product = sum * createdArray[parsedPickedIndex];
                return product;
            }
            //An indexOutOfRange is thrown if you choose an index number beyond the length of the array.
            catch (IndexOutOfRangeException m)
            {
                Console.WriteLine(m.Message);
                throw;
            }
        }
        /// <summary>
        /// This method determines the quotient of the product of the previous method and a non 0 number chosen by the user. If a zero is chosen an exception is thrown.
        /// </summary>
        /// <param name="product">The result of the indexed number and the sum. The product is returned from Product();</param>
        /// <returns>A decimal, a possibly mixed int/float from dividing the product and a chosen number.</returns>
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide {product} by:");
                string chosenDividend = Console.ReadLine();
                int parsedDividend = Convert.ToInt32(chosenDividend);
                decimal quotient = decimal.Divide(product, parsedDividend);
                return quotient;
            }
            catch (DivideByZeroException o)
            {
                Console.WriteLine(o.Message);
                return 0;
                throw;
            }
        }

    }
}
